using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Lab6
{
    public class ObjReorienter
    {
        private string filename, newfilename;
        private List<string> lines;

        public ObjReorienter(string flname, string nflname)
        {
            filename = flname;
            newfilename = nflname;
        }

        public void Read()
        {
            lines = new();
            using (StreamReader sr = new StreamReader(filename))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (line == null) continue;
                    lines.Add(line);
                }
            }
        }
        public void RotateXplus90()
        {
            Read();
            using (StreamWriter sw = new StreamWriter(newfilename, false, Encoding.Default))
            {
                foreach (string line in lines){
                    {
                        string[] items = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        if (items[0] == "vn"||items[0] == "v")
                        {
                            sw.Write(items[0]+" ");
                            sw.Write(items[1]+" ");
                            sw.Write(items[3]);
                            sw.WriteLine(Convert.ToString(double.Parse(items[3].Replace(".", ",")) * -1).Replace(",", ".")+" ");
                        }
                        else sw.WriteLine(line);
                    }
                }
            }

            filename = newfilename;
        }
        public void RotateXminus90()
        {
            List<string> lines = new List<string>();
            Read();
            using (StreamWriter sw = new StreamWriter(newfilename, false, Encoding.Default))
            {
                foreach (string line in lines){
                    {
                        string[] items = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        if (items[0] == "vn"||items[0] == "v")
                        {
                            sw.Write(items[0]+" ");
                            sw.Write(items[1]);
                            sw.Write(Convert.ToString(double.Parse(items[3].Replace(".", ",")) * -1).Replace(",", ".")+" ");
                            sw.WriteLine(items[2]);
                        }
                        else sw.WriteLine(line);
                    }
                }
            }

            filename = newfilename;
        }
        public void RotateYplus90()
        {
            Read();
            using (StreamWriter sw = new StreamWriter(newfilename, false, Encoding.Default))
            {
                foreach (string line in lines){
                    string[] items = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    if (items[0] == "vn"||items[0] == "v")
                    {
                        sw.Write(items[0]+" ");
                        sw.Write(Convert.ToString(double.Parse(items[3].Replace(".", ",")) * -1).Replace(",", ".")+" ");
                        sw.Write(items[2]+" ");
                        sw.WriteLine(items[1]);
                    }
                    else sw.WriteLine(line);
                }
            }
            filename = newfilename;
        }
        public void RotateYminus90()
        {
            Read();
            using (StreamWriter sw = new StreamWriter(newfilename, false, Encoding.Default))
            {
                foreach (string line in lines){
                    {
                        string[] items = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        if (items[0] == "vn"||items[0] == "v")
                        {
                            sw.Write(items[0]+" ");
                            sw.Write(items[3]+" ");
                            sw.Write(items[2]+" ");
                            sw.WriteLine(Convert.ToString(double.Parse(items[3].Replace(".", ",")) * -1).Replace(",", "."));
                        }
                        else sw.WriteLine(line);
                    }
                }
            }

            filename = newfilename;
        }
        public void RotateZplus90()
        {
            Read();
            using (StreamWriter sw = new StreamWriter(newfilename, false, Encoding.Default))
            {
                foreach (string line in lines){
                    {
                        string[] items = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        if (items[0] == "vn"||items[0] == "v")
                        {
                            sw.Write(items[0]+" ");
                            sw.Write(items[2]+" ");
                            sw.Write(Convert.ToString(double.Parse(items[1].Replace(".", ",")) * -1).Replace(",", ".")+" ");
                            sw.WriteLine(items[3]);
                        }
                        else sw.WriteLine(line);
                    }
                }
            }

            filename = newfilename;
        }
        public void RotateZminus90()
        {
            Read();
            using (StreamWriter sw = new StreamWriter(newfilename, false, Encoding.Default))
            {
                foreach (string line in lines){
                    {
                        string[] items = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        if (items[0] == "vn"||items[0] == "v")
                        {
                            sw.Write(items[0]+" ");
                            sw.Write(Convert.ToString(double.Parse(items[2].Replace(".", ",")) * -1).Replace(",", ".")+" ");
                            sw.Write(items[1]);
                            sw.WriteLine(items[3]);
                        }
                        else sw.WriteLine(line);
                    }
                }
            }

            filename = newfilename;
        }
    }
}