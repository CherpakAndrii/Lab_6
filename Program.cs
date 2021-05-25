using System;

namespace Lab6
{
    class Program
    {
        static void Main()
        {
            RTree tree = RTreeFactory.FillRTree("cow.obj");
            // Byte[][][] image = tree.GetImage();  // тут я створюю матрицю пікселів та заповнюю її
            // Picture.Reverse(image);  // на минулому кроці матриця вийшла перевернутою та віддзеркаленою, фіксимо це.
            // Picture.ToFile(image);   // Макс, це твоє. Очевидно, виводимо в файл
        }
    }
}
