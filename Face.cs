namespace Lab6
{
    public class Face
    {
        public Point v1, v2, v3;
        public double xMin, xMax, yMin, yMax, zMin, zMax;

        public Face(Point p1, Point p2, Point p3)
        {
            v1 = p1;
            v2 = p2;
            v3 = p3;
            xMin = Min(v1.X, v2.X, v3.X);
            xMax = Max(v1.X, v2.X, v3.X);
            yMin = Min(v1.Y, v2.Y, v3.Y);
            yMax = Max(v1.Y, v2.Y, v3.Y);
            zMin = Min(v1.Z, v2.Z, v3.Z);
            zMax = Max(v1.Z, v2.Z, v3.Z);
            //a lot of attributes and methods will be added later, such as normal vector...
        }

        private double Max(double d1, double d2, double d3)
        {
            if (d1 >= d2 && d1 >= d3) return d1;
            if (d2 >= d1 && d2 >= d3) return d2;
            return d3;
        }
        private double Min(double d1, double d2, double d3)
        {
            if (d1 <= d2 && d1 <= d3) return d1;
            if (d2 <= d1 && d2 <= d3) return d2;
            return d3;
        }
    }
}
