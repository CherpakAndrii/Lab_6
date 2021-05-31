using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab6
{
    class Program
    {
        static void Main()
        {
            RTree tree = RTreeFactory.FillRTree("test.obj");
            Camera cam = new Camera(new Point(0, 0, 2), 400, 200);
            Byte[][][] image = cam.GetImage(tree);  // тут я створюю матрицю пікселів та заповнюю її
            // Picture.ToFile(image);   // Макс, це твоє. Очевидно, виводимо в файл
            DeleteThisShit(image);
        }
        static void DeleteThisShit(Byte[][][] image)
        {
            StreamWriter sw = new StreamWriter("cow.txt", false);
            foreach (byte[][] row in image)
            {
                foreach (byte[] column in row)
                {
                    if ((double)(column[0]+column[1]+column[2])/3==0) sw.Write(" ");
                    else if ((double)(column[0]+column[1]+column[2])/3<0.5) sw.Write(".");
                    else sw.Write("S");
                }
                sw.WriteLine();
            }
            sw.Dispose();
        }
    }
}
