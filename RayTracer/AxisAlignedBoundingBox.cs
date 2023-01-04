using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    internal class AxisAlignedBoundingBox
    {
        public Vector3 min, max;
        public AxisAlignedBoundingBox(Vector3 min, Vector3 max)
        {
            this.min = min;
            this.max = max;
        }

        public override string ToString()
        {
            return $"min: {min}, max: {max}";
        }
    }
}
