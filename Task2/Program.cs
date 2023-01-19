using System;
using System.IO;

namespace Task2
{
    internal class Program
    {
        public static int CheckPoint(int ox, int oy, int r, int px, int py)
        {
            int? answer = null;
            if ((ox - px) * (ox - px) + (oy - py) * (oy - py) < r * r)
            {
                answer = 1;
            }
            if ((ox - px) * (ox - px) + (oy - py) * (oy - py) > r * r)
            {
                answer = 2;
            }
            if ((ox - px) * (ox - px) + (oy - py) * (oy - py) == r * r)
            {
                answer = 0;
            }
            return (int)answer;
        }

        static void Main(string[] args)
        {
            //string path1 = "окр.txt";
            string path1 = args[1];
            float o;
            int r;
            string[] text = File.ReadAllText(path1).Split('\n');
            {
                o = float.Parse(text[0]);
                r = int.Parse(text[1]);
            }
            int ox = (int)o;
            int oy = (int)((o - ox) * 10 + 0.5);
            //----------------------------------------------
            //string path2 = "точки.txt";
            string path2 = args[2];
            float[] arr = new float[100];
            int px;
            int py;
            using (StreamReader sr = new StreamReader(path2))
            {

                for (int i = 0; i < arr.Length; i++)
                {
                    string line = sr.ReadLine();
                    arr[i] = float.Parse(line);
                    px = (int)arr[i];
                    py = (int)((arr[i] - px) * 10 + 0.5);
                    Console.WriteLine(CheckPoint(ox, oy, r, px, py));
                    if (sr.EndOfStream)
                    {
                        break;
                    }
                }
            }
        }
    }
}
