namespace Lab6
{
    public static class CheckForIntersections
    {
        public static bool Intersection(Point p1, Point p2, RTree tree)
        {
            double x1_1 = tree.xMin;
            double x1_2 = tree.xMax;
            double y1_1 = (x1_1 - p1.X) * (p2.Y - p1.Y) / (p2.X - p1.X) + p1.Y;
            double y1_2 = (x1_2 - p1.X) * (p2.Y - p1.Y) / (p2.X - p1.X) + p1.Y;
            double z1_1 = (x1_1 - p1.X) * (p2.Z - p1.Z) / (p2.X - p1.X) + p1.Z;
            double z1_2 = (x1_2 - p1.X) * (p2.Z - p1.Z) / (p2.X - p1.X) + p1.Z;
            if (y1_1 > tree.yMin && y1_1 < tree.yMax && z1_1 > tree.zMin && z1_1 < tree.zMax ||
                y1_2 > tree.yMin && y1_2 < tree.yMax && z1_2 > tree.zMin && z1_2 < tree.zMax) return true;
            
            double y2_1 = tree.yMin;
            double y2_2 = tree.yMax;
            double x2_1 = (y2_1 - p1.Y) * (p2.X - p1.X) / (p2.Y - p1.Y) + p1.X;
            double x2_2 = (y2_2 - p1.Y) * (p2.X - p1.X) / (p2.Y - p1.Y) + p1.X;
            double z2_1 = (y2_1 - p1.Y) * (p2.Z - p1.Z) / (p2.Y - p1.Y) + p1.Z;
            double z2_2 = (y2_2 - p1.Y) * (p2.Z - p1.Z) / (p2.Y - p1.Y) + p1.Z;
            if (x2_1 > tree.xMin && x2_1 < tree.xMax && z2_1 > tree.zMin && z2_1 < tree.zMax ||
                x2_2 > tree.xMin && x2_2 < tree.xMax && z2_2 > tree.zMin && z2_2 < tree.zMax) return true;
            
            double z3_1 = tree.zMin;
            double z3_2 = tree.zMax;
            double y3_1 = (z3_1 - p1.Z) * (p2.Y - p1.Y) / (p2.Z - p1.Z) + p1.Y;
            double y3_2 = (z3_2 - p1.Z) * (p2.Y - p1.Y) / (p2.Z - p1.Z) + p1.Y;
            double x3_1 = (z3_1 - p1.Z) * (p2.X - p1.X) / (p2.Z - p1.Z) + p1.X;
            double x3_2 = (z3_2 - p1.Z) * (p2.X - p1.X) / (p2.Z - p1.Z) + p1.X;
            if (y1_1 > tree.yMin && y3_1 < tree.yMax && x3_1 > tree.xMin && x3_1 < tree.xMax ||
                y1_2 > tree.yMin && y3_2 < tree.yMax && x3_2 > tree.xMin && x3_2 < tree.xMax) return true;
            
            return false;
        }

        public static bool Intersection(Point p1, Point p2,Face face)
        {
            Vector dir = new Vector(p1, p2);
            Vector e1 = new Vector(face.v2.X - face.v1.X, face.v2.Y - face.v1.Y, face.v2.Z - face.v1.Z);
            Vector e2 = new Vector(face.v3.X - face.v1.X, face.v3.Y - face.v1.Y, face.v3.Z - face.v1.Z);
            Vector pvec = Cross(dir, e2);
            double det = Dot(e1, pvec);
            if (det < 1e-8 && det > -1e-8) 
            {
            return false;
            }
            double inv_det = 1 / det;
            Vector tvec = new Vector(p1.X - face.center.X, p1.Y - face.center.Y, p1.Z - face.center.Z);
            double u = Dot(tvec, pvec) * inv_det;
            if (u < 0 || u > 1) 
            {
                return false;
            }
            Vector qvec = Cross(tvec, e1);
            double v = Dot(dir, qvec) * inv_det;
            if (v < 0 || u + v > 1) {
                return false;
            }
            return true;
        }
        static double Dot(Vector v1, Vector v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z; 
        }
        static Vector Cross(Vector v1, Vector v2)
        {
            return new Vector(v1.Y * v2.Z - v1.Z * v2.Y, v1.Z * v2.X - v1.X * v2.Z, v1.X * v2.Y - v1.Y * v2.X);
        }
    }
}