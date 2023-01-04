using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    internal class Face
    {
        public int[] vertexIndices;
        public int[] vertexNormalIndices;
        public int[] textureCoordinateIndices;

        public Face()
        {
            vertexIndices = new int[3];
            vertexNormalIndices = new int[3];
            textureCoordinateIndices = new int[3];
        }
    }
}
