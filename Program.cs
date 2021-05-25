using System;
using System.IO;

namespace Lab6
{
    class Program
    {
        static void Main()
        {
            RTree tree = RTreeFactory.FillRTree("cow3.obj");
            Camera cam = new Camera(new Point(0, 0, 2), 100, 100);
            Byte[][][] image = cam.GetImage(tree);  // тут я створюю матрицю пікселів та заповнюю її
            // Picture.Reverse(image);  // на минулому кроці матриця вийшла перевернутою та віддзеркаленою, фіксимо це.
            // Picture.ToFile(image);   // Макс, це твоє. Очевидно, виводимо в файл
        }
    }
}
