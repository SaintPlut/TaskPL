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
            string path = args[1];
            List<int> list = new List<int>(1);
            int mid = 0;
            int count = 0;
            using(StreamReader sr = new StreamReader(path))
            {
                while (sr.EndOfStream!=true)
                {
                    list.Add(int.Parse(sr.ReadLine())); 
                } 
               
            }
            int[] arr=list.ToArray();

            for(int i = 0; i < arr.Length; i++)
                mid+=arr[i];
            mid = mid / arr.Length;
            //---------------------------
            for(int i = 0; i < arr.Length; i++)
            {
                if(arr[i] < mid)
                {
                    count=count + (mid - arr[i]);  
                }
                if (arr[i]>mid)
                {
                    count = count + (arr[i]-mid);
                }
                
                
            }
            Console.WriteLine(count);
            
        }
    }
}
