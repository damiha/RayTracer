using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace RayTracing
{
    internal class BVHNode
    {
        public AxisAlignedBoundingBox aabb;
        public bool isLeaf;
        public int meshIndex;

        // wenn isLeaf = false
        public BVHNode leftChild, rightChild;

        // wenn isLeaf = true
        public List<Triangle> triangles;

        public BVHNode(int meshIndex)
        {
            this.meshIndex= meshIndex;
        }
    }
}
