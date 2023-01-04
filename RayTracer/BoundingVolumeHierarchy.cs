using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    internal class BoundingVolumeHierarchy
    {
        Scene scene;
        List<BVHNode> meshRoots;
        int trianglesPerLeaf = 100;
        // muss fuer jede Szene neu aufgebaut werden
        public BoundingVolumeHierarchy(Scene scene) 
        {
            this.scene = scene;
            meshRoots = new List<BVHNode>();
            // lege fuer jedes mesh ein root bvh node an (wir erschaffen einen bvh wald)
            for(int i = 0; i < scene.meshes.Count; i++)
            {
                Mesh mesh = scene.meshes[i];
                BVHNode root = new BVHNode(i);

                buildBVH(root, mesh.triangles, 'X');

                meshRoots.Add(root);
            }
        }

        public void rebuildBVH()
        {
            meshRoots.Clear();

            for(int i = 0; i < scene.meshes.Count; i++)
            {
                Mesh mesh = scene.meshes[i];
                BVHNode root = new BVHNode(i);

                buildBVH(root, mesh.triangles, 'X');

                meshRoots.Add(root);
            }
        }

        // axis = 'X', 'Y' oder 'Z'
        public void buildBVH(BVHNode node, List<Triangle> triangles, char axis)
        {
            node.aabb = Util.getBoxAroundTriangles(triangles);

            if(triangles.Count <= trianglesPerLeaf)
            {
                node.isLeaf = true;
                node.triangles = triangles;
            }
            else
            {
                // sortiere nach achse
                triangles.Sort((Triangle t1, Triangle t2) =>
                {
                    if (axis == 'X')
                        return t1.centroid.X.CompareTo(t2.centroid.X);
                    else if (axis == 'Y')
                        return t1.centroid.Y.CompareTo(t2.centroid.Y);
                    else
                        return t1.centroid.Z.CompareTo(t2.centroid.Z);
                });

                int medianIndex = triangles.Count / 2;

                // kopiere in zwei unabhängige mengen
                List<Triangle> leftTriangles = new List<Triangle>();
                List<Triangle> rightTriangles = new List<Triangle>();

                for(int i = 0; i < triangles.Count; i++)
                {
                    if(i < medianIndex)
                    {
                        leftTriangles.Add(triangles[i]);
                    }
                    else
                    {
                        rightTriangles.Add(triangles[i]);
                    }
                }

                BVHNode leftChild = new BVHNode(node.meshIndex);
                BVHNode rightChild = new BVHNode(node.meshIndex);

                node.leftChild = leftChild;
                node.rightChild = rightChild;

                char newAxis = axis == 'X' ? 'Y' : (axis == 'Y' ? 'Z' : 'X');

                buildBVH(leftChild, leftTriangles, newAxis);
                buildBVH(rightChild , rightTriangles, newAxis);
            }
        }

        public void applyTransformation(Matrix4x4 transformation)
        {
            rebuildBVH();
        }

        // TODO: mit PriorityQueue beschleunigen
        private bool intersect(Ray ray, BVHNode bvhNode)
        {
            bool hitBVHNode = false;

            if(Util.intersect(ray, bvhNode.aabb))
            {
                // teste dann direkt mit den dreiecken
                if (bvhNode.isLeaf)
                {
                    foreach (Triangle triangle in bvhNode.triangles)
                    {
                        hitBVHNode |= Util.intersect(ray, triangle);
                    }

                    if (hitBVHNode)
                    {
                        ray.hitInfo.meshIndex = bvhNode.meshIndex;
                    }
                }
                else
                {
              
                    hitBVHNode |= intersect(ray, bvhNode.leftChild);

                    // TODO: wenn der einschlagspunkt (mit t bestimmt) in left child VOR rightChild liegt
                    hitBVHNode |= intersect(ray, bvhNode.rightChild);
                }
            }
            return hitBVHNode;
        }

        public bool intersect(Ray ray)
        {
            foreach(BVHNode root in meshRoots)
            {
                intersect(ray, root);
            }
            return ray.hitSomething;
        }
    }
}
