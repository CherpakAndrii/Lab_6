using System;
using System.IO;

namespace Lab6
{
    class Program
    {
        static void Main()
        {
            RTree tree = RTreeFactory.FillRTree("cow3.obj");
            Camera cam = new Camera(new Point(0, 0, 2), 1000, 1000);
            Byte[][][] image = cam.GetImage(tree);  // тут я створюю матрицю пікселів та заповнюю її
            // Picture.ToFile(image);   // Макс, це твоє. Очевидно, виводимо в файл
            DeleteThisShit(image);
        }
        static void DeleteThisShit(Byte[][][] image)
        {
            StreamWriter sw = new StreamWriter("cow.txt", false);
            foreach (Byte[][] row in image)
            {
                foreach (Byte[] column in row)
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
