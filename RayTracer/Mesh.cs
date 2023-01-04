using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayTracing
{
    internal class Mesh
    {
        // zuerst die originale (wie sie aus der obj-Datei geladen wurden)
        public List<Vector3> vertices, verticesTransformed;
        public List<Vector3> vertexNormals, vertexNormalsTransformed;

        // nur die transformierten Triangles spielen eine rolle
        public List<Triangle> triangles;

        public List<Vector2> textureCoordinates;

        public List<Face> faces;
        public Material material;

        // um unterschiedliche normalen für den gleichen VERTEX zu verhindern
        private Dictionary<int, int> vertexIndicesToNormalIndices;

        public String name;

        // only supports obj
        public Mesh(String name, String filePathToObj) 
        {
            this.name = name;
            vertexIndicesToNormalIndices= new Dictionary<int, int>();

            material = new Material("");

            vertices = new List<Vector3>();
            verticesTransformed = new List<Vector3>();

            vertexNormals = new List<Vector3>();
            vertexNormalsTransformed = new List<Vector3>();

            triangles = new List<Triangle>();

            textureCoordinates = new List<Vector2>();
            faces = new List<Face>();

            string[] lines = System.IO.File.ReadAllLines(filePathToObj);

            foreach(string line in lines)
            {
                string[] parts = line.Split(' ');

                if (parts[0] == "v" || parts[0] == "vn")
                {
                    float x = float.Parse(parts[1], CultureInfo.InvariantCulture);
                    float y = float.Parse(parts[2], CultureInfo.InvariantCulture);
                    float z = float.Parse(parts[3], CultureInfo.InvariantCulture);

                    if (parts[0] == "v")
                    {
                        vertices.Add(new Vector3(x, y, z));
                        verticesTransformed.Add(new Vector3(x, y, z));
                    }
                    else
                    {
                        vertexNormals.Add(new Vector3(x, y, z));
                        vertexNormalsTransformed.Add(new Vector3(x, y, z));
                    }
                }
                else if (parts[0] == "f")
                {
                    Face face = new Face();

                    for(int i = 1; i < parts.Length; i++)
                    {
                        string[] components = parts[i].Split('/');
                        Console.Write(components[0]);

                        // vertex indices gibts immer garantiert
                        face.vertexIndices[i-1] = int.Parse(components[0]) - 1;


                        if(components.Length >= 2)
                        {
                            if (components[1] != "")
                            {
                                face.textureCoordinateIndices[i - 1] = int.Parse(components[1]) - 1;
                            }
                        }
                        
                        // wenn man 3 teile hat, hat man zwei slashes, also auf jedenfall vertex normals
                        if(components.Length == 3)
                        {
                            int key = face.vertexIndices[i - 1];
                            // es ist schon eine normal da, d.h. wir müssen nicht parsen
                            if (vertexIndicesToNormalIndices.ContainsKey(key)){
                                face.vertexNormalIndices[i - 1] = vertexIndicesToNormalIndices[key];
                            }
                            else
                            {
                                int normalValue = int.Parse(components[2]) - 1;
                                face.vertexNormalIndices[i - 1] = normalValue;
                                
                                // in dictionary eintragen
                                vertexIndicesToNormalIndices[key] = normalValue;
                            }
                        }
                    }

                    faces.Add(face);
                    Triangle triangle = new Triangle(face, verticesTransformed[face.vertexIndices[0]], verticesTransformed[face.vertexIndices[1]], verticesTransformed[face.vertexIndices[2]]);
                    triangles.Add(triangle);
                }
            }
            Console.WriteLine(filePathToObj + " DONE!");
        }

        // zum analysieren der transformierten Geometrie in einem 3D-Programm z.B. Blender
        public String toObj()
        {
            String res = "";

            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            // alle vertices schreiben
            foreach (Vector3 vertexTransformed in verticesTransformed)
            {
                res += $"v {vertexTransformed.X} {vertexTransformed.Y} {vertexTransformed.Z}\n";
            }

            // alle texture coordinates schreiben
            foreach(Vector2 textureCoords in textureCoordinates)
            {
                res += $"vt {textureCoords.X} {textureCoords.Y}\n";
            }

            // alle vertex normals schreiben
            foreach (Vector3 vertexNormal in vertexNormalsTransformed)
            {
                res += $"vn {vertexNormal.X} {vertexNormal.Y} {vertexNormal.Z}\n";
            }

            // alle faces schreiben
            foreach(Face face in faces)
            {
                String faceLine = "f ";
                for(int i = 0; i < 3; i++) {

                    // das obj.Format ist wieder 1-indexed
                    if (textureCoordinates.Count == 0 && vertexNormals.Count == 0)
                    {
                        faceLine += (face.vertexIndices[i] + 1);
                    }

                    else if (textureCoordinates.Count == 0)
                    {
                        faceLine += $"{face.vertexIndices[i] + 1}//{face.vertexNormalIndices[i] + 1}";
                    }

                    else if (vertexNormals.Count == 0)
                    {
                        faceLine += $"{face.vertexIndices[i] + 1}/{face.textureCoordinateIndices[i] + 1}";
                    }

                    // vertices, texture coordinates und vertex normals sind vorhanden
                    else
                    {
                        faceLine += $"{face.vertexIndices[i] + 1}/{face.textureCoordinateIndices[i] + 1}/{face.vertexNormalIndices[i] + 1}";
                    }


                    if (i < 2)
                    {
                        faceLine += " ";
                    }
                }
                res += faceLine + "\n";
            }

            return res;
        }

        public void applyTransformation(Matrix4x4 transformation)
        {
            // wird immer überschrieben
            for(int i = 0; i < vertices.Count; i++)
            {
                verticesTransformed[i] = Vector3.Transform(vertices[i], transformation);
            }

            Matrix4x4 normalMatrix = new Matrix4x4();
            bool inversionSuccessful = Matrix4x4.Invert(transformation, out normalMatrix);
            normalMatrix = Matrix4x4.Transpose(normalMatrix);

            for(int i = 0; i < vertexNormalsTransformed.Count; i++)
            {
                vertexNormalsTransformed[i] = Vector3.Transform(vertexNormals[i], normalMatrix);
            }

            // auch die dreiecke ändern sich
            for(int i = 0; i < faces.Count; i++)
            {
                Face face = faces[i];
                triangles[i] = new Triangle(face, verticesTransformed[face.vertexIndices[0]], verticesTransformed[face.vertexIndices[1]], verticesTransformed[face.vertexIndices[2]]);
            }
        }
    }
}
