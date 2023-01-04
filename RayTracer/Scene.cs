using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    internal class Scene
    {

        public List<Material> materials;
        public List<Mesh> meshes;
        public List<Light> lights;

        BoundingVolumeHierarchy bvh;
        public bool bvhActivated = false;
        public Scene(List<Mesh> meshes, List<Material> materials, List<Light> lights) 
        {
            this.meshes = meshes;
            this.materials = materials;
            this.lights = lights;

            bvh = new BoundingVolumeHierarchy(this);
        }

        public void applyTransformation(Matrix4x4 transformation)
        {
            foreach(Mesh mesh in meshes) {
                mesh.applyTransformation(transformation);
            }
            foreach(Light light in lights)
            {
                light.applyTransformation(transformation);
            }

            bvh.applyTransformation(transformation);
        }

        // TODO: beschleunige mit einem BVH, der vorher fuer jedes Mesh aufgebaut wird, aber nur wenn aktiviert
        public bool intersect(Ray ray)
        {
            if(!bvhActivated)
            {
                for(int i = 0; i <  meshes.Count; i++)
                {
                    Mesh mesh = meshes[i];
                    foreach (Triangle triangle in mesh.triangles)
                    {
                        if (Util.intersect(ray, triangle))
                        {
                            ray.hitInfo.meshIndex = i;
                        }
                    }
                }
                return ray.hitSomething;
            }
            else
            {
                return bvh.intersect(ray);
            }
        }
    }
}
