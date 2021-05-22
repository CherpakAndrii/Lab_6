using System;

namespace Lab6
{
    public class Vector
    {
        public double X, Y, Z, Module;
            private double GetModule()
        {
            return Math.Pow(Math.Pow(X, 2)+Math.Pow(Y, 2)+Math.Pow(Z, 2), 0.5);
        }

        public Vector(double x, double y, double z)
        {
            (X, Y, Z) = (x, y, z);
            Module = GetModule();
        }

        public Vector(Point p1, Point p2, Point p3)
        {
            Vector newVect = (new Vector(p1, p2) * new Vector(p1, p3)).ToOrt();
            (X, Y, Z) = (newVect.X, newVect.Y, newVect.Z);
            Module = GetModule();
        }

        public Vector ToOrt()
        {
            return new Vector(X / Module, Y / Module, Z / Module);
        }
        public static Vector operator *(Vector v1, Vector v2)
        {
            return new Vector(v1.Y * v2.Z - v1.Z * v2.Y, v1.Z * v2.X - v1.X * v2.Z, v1.X * v2.Y - v1.Y * v2.X);
        }

        public Vector(Point p1, Point p2)
        {
            (X, Y, Z) = (p2.X - p1.X, p2.Y - p1.Y, p2.Z - p1.Z);
            Module = GetModule();
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }
        
        public static Vector operator *(Vector v1, double num)
        {
            return new Vector(v1.X*num, v1.Y*num, v1.Z*num);
        }
    }
}