using System;
using System.IO;

namespace Task2
{
    internal class Program
    {
        public static int CheckPoint(int ox, int oy, int r, int px, int py)
        {
            int dx = px - ox;
            int dy = py - oy;
            int distSquared = dx * dx + dy * dy;
            if (distSquared < r * r)
            {
                return 1;
            }
            else if (distSquared > r * r)
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }

        static void Main(string[] args)
        {
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

            string path2 = args[2];
            int px;
            int py;
            using (StreamReader sr = new StreamReader(path2))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    float point = float.Parse(line);
                    px = (int)point;
                    py = (int)((point - px) * 10 + 0.5);
                    Console.WriteLine(CheckPoint(ox, oy, r, px, py));
                }
            }
        }
    }
}
