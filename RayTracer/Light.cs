using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayTracing
{

    // TODO: hier die drei Farbwerte einspeichern
    // und die Position
    internal class Light
    {
        public Vector3 position, positionTransformed, I_a, I_d, I_s;
        public String name;

        public Light(String name) {
            this.name = name;
        }

        public void applyTransformation(Matrix4x4 transformation)
        {
            positionTransformed = Vector3.Transform(position, transformation);
        }
    }
}
