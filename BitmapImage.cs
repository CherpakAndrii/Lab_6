using System;
using System.IO;

namespace Lab6
{
    class BitmapImage
    {
        private string path = Path.Combine(Environment.CurrentDirectory, "image.bmp");

        public BitmapImage() { }

        public BitmapImage(string path)
        {
            this.path = path;
        }

        public void CreateImage(byte[][][] bytesArray)
        {
            int width = bytesArray[0].Length;
            int heigth = bytesArray.Length;
            using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                //BITMAPFILEHEADER

                binaryWriter.Write("B");
                binaryWriter.Write("M");
                binaryWriter.Write((UInt32) 3 * (width * height) + 54); // 54 - header value in bytes
                binaryWriter.Write((UInt16) 0);
                binaryWriter.Write((UInt16) 0);
                binaryWriter.Write((UInt32) 54); // header value

                //BITMAPINFOHEADER

                binaryWriter.Write((UInt32) 40);
                binaryWriter.Write((UInt32) width);
                binaryWriter.Write((UInt32) height);
                binaryWriter.Write((UInt16) 1);
                binaryWriter.Write((UInt16) 24);
                binaryWriter.Write((UInt32) 0);
                binaryWriter.Write((UInt32) 0);
                binaryWriter.Write((UInt32) 0);
                binaryWriter.Write((UInt32) 0);
                binaryWriter.Write((UInt32) 0);
                binaryWriter.Write((UInt32) 0);

                //Data

                byte[] zeroBytes = new byte[(4 - 3*width % 4) % 4];
                for (int ctr = 0; ctr < zeroBytes.Length; ctr++) zeroBytes[ctr] = 0;

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        binaryWriter.Write(bytesArray[i][j]);
                    }
                    if (zeroBytes.Length != 0)
                    {
                        binaryWriter.Write(zeroBytes);
                    }
                }
            }
        }
    }
}
