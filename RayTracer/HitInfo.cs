using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    internal class HitInfo
    {
        public Vector3 barycentricCoordinates;
        public Face face;
        public int meshIndex;
    }
}
