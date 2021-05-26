using System;
using System.Collections.Generic;

namespace Lab6
{
    public class Camera
    {
        private Point Center, Focus;
        private int height, width;
        public byte[][][] image;
        private double pixelsize = 0.002;

        public Camera(Point center, int h, int w)
        {
            Center = center;
            height = h;
            width = w;
            image = new byte[height][][];
            for (int i = 0; i < height; i++)
            {
                image[i] = new byte[width][];
                for (int j = 0; j < width; j++)
                {
                    image[i][j] = new byte[3];
                    for (int k = 0; k < 3; k++) image[i][j][k] = 0;
                }
            }
            Focus = new Point(Center.X, Center.Y, Center.Z * 7 / 8);
        }
        public byte[][][] GetImage(RTree tree)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Point pixel = new Point(Center.X + pixelsize*(width / 2 - j), Center.Y - pixelsize*(height / 2 + j), 2);
                    Face nearest = GetNearestFace(Focus, pixel, tree);
                    if (nearest == null) continue;
                    Light lightPoint = new Light(1000, 1000, 1000);
                    double coef = lightPoint.GetLightCoef(nearest, tree);
                    image[i][j][0] = (byte)
                        (lightPoint.Red * coef);
                    image[i][j][1] = (byte)(lightPoint.Green * coef);
                    image[i][j][2] = (byte)(lightPoint.Blue * coef);
                }
            }
            return image;
        }
        public static Face GetNearestFace(Point p1, Point p2, RTree tree)
        {
            List<Face> faceList = new();
            FindFaces(p1, p2, tree, ref faceList);
            List<Face> IntersectedFaceList = new();
            foreach (Face face in faceList) if (CheckForIntersections.Intersection(p1, p2, face)) IntersectedFaceList.Add(face);
            Face nearest = GetNearestFromList(p1, IntersectedFaceList);
            return nearest;
        }
        private static Face GetNearestFromList(Point p, List<Face> faces)
        {
            Face nearest = null;
            double minDistance = Double.MaxValue;
            foreach (Face face in faces)
            {
                Vector v = new Vector(p, face.center);
                if (v.Module < minDistance)
                {
                    minDistance = v.Module;
                    nearest = face;
                }
            }
            return nearest;
        }
        private static void FindFaces(Point p1, Point p2, RTree tree, ref List<Face> faceList)
        {
            if (!CheckForIntersections.Intersection(p1, p2, tree)) return;
            if (!tree.IsParent) foreach (Face f in tree.Faces) faceList.Add(f);
            else
            {
                FindFaces(p1, p2, tree.Child1, ref faceList);
                FindFaces(p1, p2, tree.Child2, ref faceList);
            }
        }
    }
}