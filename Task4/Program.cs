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
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    list.Add(int.Parse(line));
                }
            }
            int[] arr = list.ToArray();
            var mid=arr.OrderBy(x=>x).Skip(arr.Length/2).First();
            var result = arr.Select(x => Math.Abs(x - mid)).Sum();
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
