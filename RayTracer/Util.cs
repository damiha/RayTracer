using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    internal class Util
    {

        public static float clamp(float value, float min, float max)
        {
            return Math.Min(max, Math.Max(value, min));
        }
        public static Vector3 clamp(Vector3 value, float min, float max)
        {
            return new Vector3(clamp(value.X, min, max), clamp(value.Y, min, max), clamp(value.Z, min, max)); 
        }
        public static Vector3 getBarycentricCoordinates(Vector3 P, Vector3 A, Vector3 B, Vector3 C)
        {
            Vector3 faceNormal = Vector3.Cross(B - A, C - A);
            float totalArea = faceNormal.LengthSquared();

            float areaOppositeC = Vector3.Dot(faceNormal, Vector3.Cross(B - A, P - A));
            float areaOppositeB = Vector3.Dot(faceNormal, Vector3.Cross(P - A, C - A));
            float areaOppositeA = Vector3.Dot(faceNormal, Vector3.Cross(C-B, P - B));


            return new Vector3(areaOppositeA / totalArea, areaOppositeB/ totalArea, areaOppositeC / totalArea);
        }

        public static bool areBarycentricCoordinatesValid(Vector3 barycentricCoordinates)
        {
            float x = barycentricCoordinates.X;
            float y = barycentricCoordinates.Y;
            float z = barycentricCoordinates.Z;

            return 0 <= x && x <= 1 && 0 <= y && y <= 1 && 0 <=z && z <= 1;
        }

        public static bool intersect(Ray ray, Triangle triangle)
        {
            float distanceToPlane = Vector3.Dot(triangle.faceNormal, triangle.v1);

            float dn = Vector3.Dot(triangle.faceNormal, ray.direction);

            // nicht paralell, also getroffen
            if (dn != 0.0f)
            {
                float t = (distanceToPlane - Vector3.Dot(ray.origin, triangle.faceNormal)) / dn;

                // nur, wenn noch näherer getroffen wurde und nicht hinter der Kamera
                if (t >= 0.0f && t < ray.t)
                {
                    Vector3 intersectionPoint = ray.origin + t * ray.direction;
                    Vector3 barycentricCoordinates = getBarycentricCoordinates(intersectionPoint, triangle.v0, triangle.v1, triangle.v2);

                    if (areBarycentricCoordinatesValid(barycentricCoordinates))
                    {
                        ray.t = t;
                        ray.hitSomething = true;

                        ray.hitInfo.barycentricCoordinates = barycentricCoordinates;
                        ray.hitInfo.face = triangle.face;

                        return true;
                    }
                }
            }
            return false;
        }

        // hier wird nichts im ray gesetzt (also nicht hitSomething oder t)
        public static bool intersect(Ray ray, AxisAlignedBoundingBox aabb)
        {
            float t_xMin = ray.direction.X != 0.0f ? (aabb.min.X - ray.origin.X) / ray.direction.X : float.PositiveInfinity;
            float t_yMin = ray.direction.Y != 0.0f ? (aabb.min.Y - ray.origin.Y) / ray.direction.Y : float.PositiveInfinity;
            float t_zMin = ray.direction.Z != 0.0f ? (aabb.min.Z - ray.origin.Z) / ray.direction.Z : float.PositiveInfinity;

            float t_xMax = ray.direction.X != 0.0f ? (aabb.max.X - ray.origin.X) / ray.direction.X : float.NegativeInfinity;
            float t_yMax = ray.direction.Y != 0.0f ? (aabb.max.Y - ray.origin.Y) / ray.direction.Y : float.NegativeInfinity;
            float t_zMax = ray.direction.Z != 0.0f ? (aabb.max.Z - ray.origin.Z) / ray.direction.Z : float.NegativeInfinity;

            float t_inX = Math.Min(t_xMin, t_xMax);
            float t_outX = Math.Max(t_xMin, t_xMax);

            float t_inY = Math.Min(t_yMin, t_yMax);
            float t_outY = Math.Max(t_yMin, t_yMax);

            float t_inZ = Math.Min(t_zMin, t_zMax);
            float t_outZ = Math.Max(t_zMin, t_zMax);

            float t_in = Math.Max(t_inX, Math.Max(t_inY, t_inZ));
            float t_out = Math.Min(t_outX, Math.Min(t_outY, t_outZ));

            if(t_in > t_out || t_out < 0)
            {
                return false;
            }
            return true;
        }

        // komponentenweise min
        private static Vector3 componentMin(Vector3 v1, Vector3 v2)
        {
            return new Vector3(Math.Min(v1.X, v2.X), Math.Min(v1.Y, v2.Y), Math.Min(v1.Z, v2.Z));
        }

        private static Vector3 componentMax(Vector3 v1, Vector3 v2)
        {
            return new Vector3(Math.Max(v1.X, v2.X), Math.Max(v1.Y, v2.Y), Math.Max(v1.Z, v2.Z));
        }

        public static AxisAlignedBoundingBox getBoxAroundTriangles(List<Triangle> triangles)
        {
            Vector3 min = new Vector3(float.PositiveInfinity);
            Vector3 max = new Vector3(float.NegativeInfinity);

            foreach(Triangle triangle in triangles)
            {
                min = componentMin(min, triangle.v0);
                min = componentMin(min, triangle.v1);
                min = componentMin(min, triangle.v2);

                max = componentMax(max, triangle.v0);
                max = componentMax(max, triangle.v1);
                max = componentMax(max, triangle.v2);
            }

            //Console.WriteLine($"Min: {min}, Max: {max}");
            return new AxisAlignedBoundingBox(min, max);
        }

        public static (int width, int height) getWindowDimensions(Resolution resolution)
        {
            switch(resolution)
            {
                case Resolution.p_720:
                    return (1280, 720);

                case Resolution.p_480:
                    return (854, 480);

                case Resolution.p_360:
                    return (640, 360);

                case Resolution.p_240:
                    return (426, 240);

                default:
                    return (256, 144);
            }
        }

        public static float toRadians(float angleDegrees)
        {
            return ((float)Math.PI / 180.0f) * angleDegrees;
        }

        public static Color getColor(Vector3 color)
        {
            return Color.FromArgb(255, (int)(color.X * 255.0f), (int)(color.Y * 255.0f), (int)(color.Z * 255.0f));
        }
        public static Vector3 getColor(Color color)
        {
            return new Vector3(color.R / 255.0f, color.G / 255.0f, color.B / 255.0f);
        }
    }
}
