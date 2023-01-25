using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = args[0];
            List<int> list = new List<int>(1);
            int mid = 0;
            int count = 0;
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    list.Add(int.Parse(line));
                }
            }
            int[] arr = list.ToArray();

            mid = (int)list.Average();
          
            for (int i = 0; i < arr.Length; i++)
            {
                count += Math.Abs(arr[i] - mid);
            }
            Console.WriteLine(count);
            Console.ReadKey();
        }
    }
}
