using System.Collections.Generic;

namespace Lab6
{
    public class RTree
    {
        public bool IsParent = false;
        public int Size = 0;
        private const int MaxSize = 25;
        public double xMax, xMin, yMax, yMin, zMax, zMin;
        public List<Face> Faces = new();
        public RTree Child1, Child2;

        public void Add(Face f)
        {
            Size++;
            if (Size == 1)
            {
                xMax = f.xMax;
                xMin = f.xMin;
                yMax = f.yMax;
                yMin = f.yMin;
                zMax = f.zMax;
                zMin = f.zMin;
                Faces.Add(f);
            }
            else
            {
                xMax = Max(f.xMax,xMax);
                xMin = Min(f.xMin, xMin);
                yMax = Max(f.yMax, yMax);
                yMin = Min(f.yMin, yMin);
                zMax = Max(f.zMax, zMax);
                zMin = Min(f.zMin, zMin);
                if (IsParent)
                {
                    if (OptimalInclude(Child1, Child2, f)) Child1.Add(f);
                    else Child2.Add(f);
                }
                else
                {
                    Faces.Add(f);
                    if (Size > MaxSize) Divide();
                }
            }
        }
        private static int CompareByCoordinateX(Face f1, Face f2)
        {
            if (f1.xMax > f2.xMax) return 1;
            if (f2.xMin < f1.xMin) return -1;
            if (f1.yMax > f2.yMax) return 1;
            if (f2.yMin < f1.yMin) return -1;
            if (f1.zMax > f2.zMax) return 1;
            return -1;
        }

        private static int CompareByCoordinateY(Face f1, Face f2)
        {
            if (f1.yMax > f2.yMax) return 1;
            if (f2.yMin < f1.yMin) return -1;
            if (f1.xMax > f2.xMax) return 1;
            if (f2.xMin < f1.xMin) return -1;
            if (f1.zMax > f2.zMax) return 1;
            return -1;
        }
        private static int CompareByCoordinateZ(Face f1, Face f2)
        {
            if (f1.zMax > f2.zMax) return 1;
            if (f2.zMin < f1.zMin) return -1;
            if (f1.xMax > f2.xMax) return 1;
            if (f2.xMin < f1.xMin) return -1;
            if (f1.yMax > f2.yMax) return 1;
            return -1;
        }

        private void Divide()
        {
            IsParent = true;
            Child1 = new RTree();
            Child2 = new RTree();
            if (xMax-xMin>=yMax-yMin && xMax-xMin>=zMax-zMin) Faces.Sort(CompareByCoordinateX);
            else if (yMax - yMin >= xMax - xMin && yMax - yMin >= zMax - zMin) Faces.Sort(CompareByCoordinateY);
            else Faces.Sort(CompareByCoordinateZ);
            Child1.Add(Faces[0]);
            Child2.Add(Faces[Size-1]);
            Faces.RemoveAt(Size-1);
            Faces.RemoveAt(0);
            foreach (Face face in Faces)
            {
                if (OptimalInclude(Child1, Child2, face)) Child1.Add(face);
                else Child2.Add(face);
            }
        }
        public static bool OptimalInclude(RTree n1, RTree n2, Face f)
        {
            //imagine that we add a face to the first node
            double newXMax1 = Max(n1.xMax, f.xMax);
            double newXMin1 = Min(n1.xMax, f.xMin);
            double newYMax1 = Max(n1.yMax, f.yMax);
            double newYMin1 = Min(n1.yMax, f.yMin);
            double newZMax1 = Max(n1.zMax, f.zMax);
            double newZMin1 = Min(n1.zMax, f.zMin);
            double v1 = (newXMax1 - newXMin1) * (newYMax1 - newYMin1) * (newZMax1 - newZMin1) + (n2.xMax - n2.xMin) * (n2.yMax - n2.yMin) * (n2.zMax - n2.zMin);
            //imagine that we add a face to the second node
            double newXMax2 = Max(n2.xMax, f.xMax);
            double newXMin2 = Min(n2.xMax, f.xMin);
            double newYMax2 = Max(n2.yMax, f.yMax);
            double newYMin2 = Min(n2.yMax, f.yMin);
            double newZMax2 = Max(n2.zMax, f.zMax);
            double newZMin2 = Min(n2.zMax, f.zMin);
            double v2 = (n1.xMax - n1.xMin) * (n1.yMax - n1.yMin) * (n1.zMax - n1.zMin) + (newXMax2 - newXMin2) * (newYMax2 - newYMin2) * (newZMax2 - newZMin2);
            //in which case the volume will be smaller?
            return v1 == v2 ? n1.Size < n2.Size : v1 < v2;
        }

        private static double Max(double d1, double d2)
        {
            return d1 > d2 ? d1 : d2;
        }
        private static double Min(double d1, double d2)
        {
            return d1 < d2 ? d1 : d2;
        }
    }
}
