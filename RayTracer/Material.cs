using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    internal class Material
    {
        public Vector3 K_a, K_d, K_s;
        // specularity
        public int specularity = 1;
        public String name;
        public Material(String name) {
            this.name = name;
        }
    }
}
