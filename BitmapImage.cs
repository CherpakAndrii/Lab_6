using System;
using System.IO;

namespace Lab6
{
    class BitmapImage
    {
        private string path;

        public BitmapImage(string path)
        {
            this.path = path;
        }

        public BitmapImage()
        {
            path = Environment.CurrentDirectory;
        }

        public void CreateImage(byte[,][] bytesArray, int width, int height)
        {
            using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                //BITMAPFILEHEADER

                binaryWriter.Write("B");
                binaryWriter.Write("M");
                binaryWriter.Write((UInt32) width * height + 54); // 54 - header value in bytes
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

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            binaryWriter.Write(bytesArray[i, j][k]);
                        }
                    }

                    int zeroBytes = (3 * width) % 4;
                    while (zeroBytes != 0)
                    {
                        binaryWriter.Write((byte)0);
                        zeroBytes++;
                    }
                }
            }
        }
    }
}
