using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayTracing
{

    enum ShadingType
    {
        Flat_Shading = 0,
        Gouraud_Shading = 1,
        Phong_Shading = 2,

    }

    enum SceneType
    {
        Teapot = 0,
        Suzanne = 1,
        Textured_Cube = 2,
        Sphere = 3,
    }

    public enum Resolution
    {
        p_720 = 0,
        p_480 = 1,
        p_360 = 2,
        p_240 = 3,
        p_144 = 4
    }
    internal class RayTracer
    {
        // entspricht auch der auflösung der Anzeige
        // für 720p statt 480p vorbereiten
        readonly int WIDTH = 1280;
        readonly int HEIGHT = 720;

        public Resolution resolution = Resolution.p_480;
        public ShadingType shadingType = ShadingType.Flat_Shading;

        public bool isDone = false;
        public float currentRenderProgress = 0.0f;

        public bool drawFacets;

        Mesh teapot, sphere, suzanne, cube;
        Material orangePorcelan;
        Light light;

        public Scene currentScene;

        // an dieser z-Position ist der Bildschirm platziert
        public float focalLength = 1.0f;

        // werden von UI initialisiert
        public float cameraPosX = 0, cameraPosY = 0, cameraPosZ = 0;
        public float cameraRotX = 0, cameraRotY = 0;

        Matrix4x4 modelViewMatrix;

        public RayTracer()
        {
            orangePorcelan = new Material("Porcelan");
            orangePorcelan.K_a = new Vector3(0.3f, 0.1f, 0.1f);
            orangePorcelan.K_d = new Vector3(0.8f, 0.4f, 0.1f);
            orangePorcelan.K_s = new Vector3(1.0f);
            orangePorcelan.specularity = 32;

            // TODO: prüfe, dass die namen eindeutig sind
            teapot = new Mesh("Teapot", "../../meshes/teapot.obj");
            sphere = new Mesh("Sphere", "../../meshes/sphere.obj");
            suzanne = new Mesh("Suzanne", "../../meshes/suzanne.obj");
            cube = new Mesh("Cube", "../../meshes/cube.obj");

            teapot.material = orangePorcelan;
            sphere.material = orangePorcelan;
            suzanne.material = orangePorcelan;
            cube.material = orangePorcelan;

            light = new Light("Point Light");
            light.position = new Vector3(5.0f, 5.0f, 2.5f);
            light.I_a = light.I_d = light.I_s = new Vector3(1.0f);

            List<Material> materials = new List<Material>() { orangePorcelan };
            List<Mesh> meshes = new List<Mesh>(){ sphere };
            List<Light> lights = new List<Light>(){ light };

            currentScene = new Scene(meshes, materials, lights);
            drawFacets = false;
        }

        private void setModelViewMatrixFromSettings() {

            modelViewMatrix = Matrix4x4.Identity;

            Matrix4x4 translationMatrix = Matrix4x4.CreateTranslation(-cameraPosX, -cameraPosY, -cameraPosZ);
            Matrix4x4 rotationXMatrix = Matrix4x4.CreateRotationX(Util.toRadians(cameraRotX));
            Matrix4x4 rotationYMatrix = Matrix4x4.CreateRotationY(Util.toRadians(cameraRotY));

            Matrix4x4 rotationMatrix =  rotationYMatrix * rotationXMatrix;

            modelViewMatrix =  translationMatrix * rotationMatrix;
        }

        private Ray generateRay(float normalizedDeviceX, float normalizedDeviceY)
        {
            Vector3 origin = new Vector3(0);

            // kamera schaut in negative z richtung
            Vector3 direction = new Vector3(normalizedDeviceX, normalizedDeviceY, -focalLength);

            return new Ray(origin, direction);
        }

        public Bitmap getRenderedImageAtResolution(int width, int height)
        {
            Bitmap previewImage = new Bitmap(width, height);
            isDone = false;

            int totalNumberOfPixels = width * height;

            DateTime start = DateTime.Now;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // y in [-1, 1]
                    float normalizedDeviceY = (-2.0f * y) / height + 1.0f;
                    // x in [-16:9, 16:9]
                    float normalizedDeviceX = ((2.0f * x) / width - 1.0f) * (16.0f / 9.0f);

                    Ray rayThroughPixel = generateRay(normalizedDeviceX, normalizedDeviceY);

                    if (currentScene.intersect(rayThroughPixel))
                    {
                        // TODO: muss später durch getFinalColor (RECURSIVE RAYTRACER) ersetzt werden!
                        Color c = computeLightContribution(rayThroughPixel);
                        previewImage.SetPixel(x, y, c);
                    }
                    else
                    {
                        previewImage.SetPixel(x, y, Color.Black);
                    }

                    // nach jedem pixel updaten
                    currentRenderProgress = ((y * width + x) / ((float) totalNumberOfPixels)) * 100.0f;
                }
            }

            DateTime end = DateTime.Now;
            TimeSpan timeSpan = end - start;
            Console.WriteLine($"Render took: {timeSpan.TotalMilliseconds}ms");

            isDone = true;
            return previewImage;
        }

        private Vector3 computeDiffuseColor(Vector3 position, Vector3 normal, Material material, Light light)
        {
            Vector3 toLight = Vector3.Normalize(light.positionTransformed - position);
            float diffuseCoefficient = Util.clamp(Vector3.Dot(toLight, normal), 0.0f, 1.0f);
            return Util.clamp(diffuseCoefficient * material.K_d * light.I_d, 0.0f, 1.0f);
        }

        private Vector3 computeSpecularColor(Vector3 position, Vector3 normal, Material material, Light light)
        {
            Vector3 toLight = Vector3.Normalize(light.positionTransformed - position);
            // 2 * (L dot N) * N - L
            Vector3 reflectiveVector = Vector3.Normalize(2.0f * Vector3.Dot(toLight, normal) * normal - toLight);

            if(Vector3.Dot(reflectiveVector, normal) < 0.0f)
            {
                return new Vector3(0.0f);
            }

            Vector3 toCamera = Vector3.Normalize(-position);

            // -position ist der vektor vom objekt zur kamera
            float specularCoefficient = Util.clamp(Vector3.Dot(reflectiveVector, toCamera), 0.0f, 1.0f);

            return Util.clamp((float) Math.Pow(specularCoefficient, material.specularity) * material.K_s * light.I_s, 0.0f, 1.0f);
        }

        private Vector3 computeShading(Vector3 position, Vector3 normal, Material material, Light light)
        {
            return computeDiffuseColor(position, normal, material, light) + computeSpecularColor(position, normal, material, light);
        }

        // gibt die transformierten eckpunkte des dreiecks zurück
        private (Vector3 v0, Vector3 v1, Vector3 v2) verticesFromFace (int meshIndex, Face face)
        {
            Vector3 v0 = currentScene.meshes[meshIndex].verticesTransformed[face.vertexIndices[0]];
            Vector3 v1 = currentScene.meshes[meshIndex].verticesTransformed[face.vertexIndices[1]];
            Vector3 v2 = currentScene.meshes[meshIndex].verticesTransformed[face.vertexIndices[2]];

            return (v0, v1, v2);
        }

        private (Vector3 v0Normal, Vector3 v1Normal, Vector3 v2Normal) vertexNormalsFromFace(int meshIndex, Face face)
        {
            // TODO: später vertex normals transformed abfragen
            Vector3 v0Normal = currentScene.meshes[meshIndex].vertexNormalsTransformed[face.vertexNormalIndices[0]];
            Vector3 v1Normal = currentScene.meshes[meshIndex].vertexNormalsTransformed[face.vertexNormalIndices[1]];
            Vector3 v2Normal = currentScene.meshes[meshIndex].vertexNormalsTransformed[face.vertexNormalIndices[2]];

            return (v0Normal, v1Normal, v2Normal);
        }

        private Color computeLightContribution(Ray ray)
        {
            Vector3 positionOnMesh = ray.origin + ray.t * ray.direction;
            Vector3 barycentricCoords = ray.hitInfo.barycentricCoordinates;

            (Vector3 v0, Vector3 v1, Vector3 v2) = verticesFromFace(ray.hitInfo.meshIndex, ray.hitInfo.face);
            Vector3 centroid = (v0 + v1 + v2) / 3.0f;
            Vector3 faceNormal = Vector3.Normalize(Vector3.Cross(v1 - v0, v2 - v0));

            // für Gouraud Shading und Phong Shading
            (Vector3 v0Normal, Vector3 v1Normal, Vector3 v2Normal) = vertexNormalsFromFace(ray.hitInfo.meshIndex, ray.hitInfo.face);

            Material meshMaterial = currentScene.meshes[ray.hitInfo.meshIndex].material;

            Vector3 finalColor = new Vector3(0.0f);

            foreach(Light light in currentScene.lights)
            {
                finalColor += (meshMaterial.K_a * light.I_a);

                if(shadingType == ShadingType.Flat_Shading)
                {
                    finalColor += computeShading(centroid, faceNormal, meshMaterial, light);
                }

                else if(shadingType == ShadingType.Gouraud_Shading)
                {
                    
                    Vector3 v0Color = computeShading(v0, v0Normal, meshMaterial, light);
                    Vector3 v1Color = computeShading(v1, v1Normal, meshMaterial, light);
                    Vector3 v2Color = computeShading(v2, v2Normal, meshMaterial, light);

                    if (drawFacets)
                    {
                        if (barycentricCoords.X == Math.Max(barycentricCoords.X, Math.Max(barycentricCoords.Y, barycentricCoords.Z)))
                        {
                            finalColor += v0Color;
                        }
                        else if (barycentricCoords.Y == Math.Max(barycentricCoords.X, Math.Max(barycentricCoords.Y, barycentricCoords.Z)))
                        {
                            finalColor += v1Color;
                        }
                        else
                        {
                            finalColor += v2Color;
                        }
                    }
                    else
                    {
                        finalColor += ((barycentricCoords.X * v0Color) + (barycentricCoords.Y * v1Color) + (barycentricCoords.Z * v2Color));

                    }
                }
                else if(shadingType == ShadingType.Phong_Shading) {
                    Vector3 interpolatedNormal = ((barycentricCoords.X * v0Normal) + (barycentricCoords.Y * v1Normal) + (barycentricCoords.Z * v2Normal));

                    finalColor += computeShading(positionOnMesh, interpolatedNormal, meshMaterial, light);
                }
                // TODO: specular und andere shading typen implementieren
            }
            finalColor = Util.clamp(finalColor, 0.0f, 1.0f);
            finalColor *= 255.0f;

            //Console.WriteLine(finalColor.ToString());
            return Color.FromArgb(255, (int) finalColor.X, (int) finalColor.Y, (int) finalColor.Z);
        }

        public Bitmap getFinalImage()
        {
            setModelViewMatrixFromSettings();
            currentScene.applyTransformation(modelViewMatrix);

            if (resolution == Resolution.p_720)
            {
                return getRenderedImageAtResolution(WIDTH, HEIGHT);
            }
            else
            {
                Bitmap finalImage = new Bitmap(WIDTH, HEIGHT);

                (int width, int height) = Util.getWindowDimensions(resolution);
                Bitmap previewImage = getRenderedImageAtResolution(width, height);

                // TODO: verbessere durch bilineare Interpolation
                for(int y = 0; y < HEIGHT; y++)
                {
                    for(int x = 0; x < WIDTH; x++)
                    {
                        int xInPreview = (int)((x * 1.0f / WIDTH) * width);
                        int yInPreview = (int)((y * 1.0f / HEIGHT) * height);

                        finalImage.SetPixel(x, y, previewImage.GetPixel(xInPreview, yInPreview));
                    }
                }
                return finalImage;
            }
        }

        public void setResolution(Resolution newResolution)
        {
            this.resolution = newResolution;
        }

        public void setShadingType(ShadingType newShadingType)
        {
            Console.WriteLine($"{newShadingType}");
            this.shadingType = newShadingType;
        }

        public void setCurrentScene(SceneType sceneType)
        {
            if (sceneType == SceneType.Teapot)
            {
                currentScene.meshes = new List<Mesh>() { teapot };
            }
            else if (sceneType == SceneType.Suzanne)
            {
                currentScene.meshes = new List<Mesh>() { suzanne};
            }
            else if (sceneType == SceneType.Sphere)
            {
                currentScene.meshes = new List<Mesh>() { sphere };
            }
            else if(sceneType == SceneType.Textured_Cube)
            {
                currentScene.meshes = new List<Mesh>() { cube };
            }
        }

        public void setBVHActivated(bool bvhActivated)
        {
            currentScene.bvhActivated = bvhActivated;
        }

        public void setDrawFacets(bool value)
        {
            drawFacets = value;
        }

        public float getRenderProgress()
        {
            return currentRenderProgress;
        }
    }
}
