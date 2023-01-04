using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    internal class Triangle
    {
        public Vector3 v0, v1, v2, faceNormal, centroid;

        // Dreiecke können zu Faces gehören (Regelfall) müssen es aber nicht
        public Face face;
        public Triangle(Vector3 v0, Vector3 v1, Vector3 v2) {
            this.v0 = v0;
            this.v1 = v1;
            this.v2 = v2;

            this.faceNormal = Vector3.Cross(v1 - v0, v2 - v0);
            faceNormal = Vector3.Normalize(faceNormal);

            // mittelpunkt des dreiecks
            centroid = (v0 + v1 + v2) / 3.0f;
        }

        public Triangle(Face face, Vector3 v0, Vector3 v1, Vector3 v2) : this(v0, v1, v2)
        {
            this.face = face;
        }
    }
}
