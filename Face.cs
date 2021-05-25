namespace Lab6
{
    public class Face
    {
        public Point v1, v2, v3, center;
        public double xMin, xMax, yMin, yMax, zMin, zMax;
        public Vector NormalVector;

        public Face(Point p1, Point p2, Point p3)
        {
            v1 = p1;
            v2 = p2;
            v3 = p3;
            xMin = _min(v1.X, v2.X, v3.X);
            xMax = _max(v1.X, v2.X, v3.X);
            yMin = _min(v1.Y, v2.Y, v3.Y);
            yMax = _max(v1.Y, v2.Y, v3.Y);
            zMin = _min(v1.Z, v2.Z, v3.Z);
            zMax = _max(v1.Z, v2.Z, v3.Z);
            center = new Point((v1.X + v2.X + v3.X) / 3, (v1.Y + v2.Y + v3.Y) / 3, (v1.Z + v2.Z + v3.Z) / 3);
            NormalVector = new Vector(p1, p2, p3);
        }
        private static double _max(double d1, double d2, double d3)
        {
            if (d1 >= d2 && d1 >= d3) return d1;
            if (d2 >= d1 && d2 >= d3) return d2;
            return d3;
        }
        private static double _min(double d1, double d2, double d3)
        {
            if (d1 <= d2 && d1 <= d3) return d1;
            if (d2 <= d1 && d2 <= d3) return d2;
            return d3;
        }
    }
}
