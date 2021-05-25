using System;
using System.Collections.Generic;
using System.IO;

namespace Lab6
{
    public class RTreeFactory
    {
        public static RTree FillRTree(string filename)
        {
            RTree tree = new();
            StreamReader sr = new(filename);
            List<Point> points = new List<Point>();
            for (int ctr = 0; !sr.EndOfStream; ctr++)
            {
                string str = sr.ReadLine();
                if (str == null) continue;
                try
                {
                    string[] items = str.Split(" ");
                    if (items[0] == "v")
                    {
                        points.Add(
                           new Point(double.Parse(items[1]), double.Parse(items[2]), double.Parse(items[3])));
                    }
                    if (items[0] == "f")
                    {
                        int p1 = int.Parse(items[1].Split('/', StringSplitOptions.RemoveEmptyEntries)[0]);
                        int p2 = int.Parse(items[2].Split('/', StringSplitOptions.RemoveEmptyEntries)[0]);
                        int p3 = int.Parse(items[3].Split('/', StringSplitOptions.RemoveEmptyEntries)[0]);
                        tree.Add(new Face(points[p1-1], points[p2-1], points[p3-1]));
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine($"Oops, damaged line {ctr} in file... We can't continue(");
                    Environment.Exit(2);
                }
            }
            sr.Dispose();
            return tree;
        }
    }
}
