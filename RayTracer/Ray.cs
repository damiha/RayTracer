using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayTracing
{
    internal class Ray
    {
        public Vector3 origin;
        public Vector3 direction;
        public float t;
        public Boolean hitSomething;

        public HitInfo hitInfo;

        public Ray(Vector3 origin, Vector3 direction)
        {
            this.origin = origin;
            this.direction= direction;

            hitInfo = new HitInfo();

            t = float.PositiveInfinity;
            hitSomething = false;
        }
    }
}
