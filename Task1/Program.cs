using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(args[1]);
            int m = int.Parse(args[2]);
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = i + 1;
            }
            int startArr = 0;
            do
            {
                Console.Write(arr[startArr]);
                startArr = (startArr + m - 1) % n;
            }
            while (startArr != 0);

        }
    }
}
