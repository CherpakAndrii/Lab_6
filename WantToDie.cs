using System;

namespace Lab6
{
    static class WantToDie
    {
        //если бы я понимал чо тут происходит я не понимаю чо тут происходит
        bool IntersectionOrIdk(Point orig, Point dir,Face face) 
        {
            Vector e1 = new Vector(face.v2.X - face.v1.X, face.v2.Y - face.v1.Y, face.v2.Z - face.v1.Z);
            Vector e2 = new Vector(face.v3.X - face.v1.X, face.v3.Y - face.v1.Y, face.v3.Z - face.v1.Z);
            Vector pvec = Cross(dir, e2);
            float det = Dot(e1, pvec);
            if (det < 1e-8 && det > -1e-8) 
            {
                return false;
            }
            float inv_det = 1 / det;
            Vector tvec = new Vector(orig.X - face.v0.X, orig.Y - face.v0.Y, orig.Z - face.v0.Z);
            float u = Dot(tvec, pvec) * inv_det;
            if (u < 0 || u > 1) 
            {
                return false;
            }
            Vector qvec = Cross(tvec, e1);
            float v = Dot(dir, qvec) * inv_det;
            if (v < 0 || u + v > 1) {
                return false;
            }
            return true;
        }
        static float Dot(Vector v1, Vector v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z; 
        }
        static Vector Cross(Vector v1, Vector v2)
        {
            return new Vector(v1.Y * v2.Z - v1.Z * v2.Y, v1.Z * v2.X - v1.X * v2.Z, v1.X * v2.Y - v1.Y * v2.X);
        }
    }
}