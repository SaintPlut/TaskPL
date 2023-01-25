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
            int n = int.Parse(args[0]);
            int m = int.Parse(args[1]);
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = i + 1;
            }
            int startArr = 0;
            int count = 0;
            while (count < n)
            {
                Console.Write(arr[startArr]);
                startArr = (startArr + m - 1) % n;
                count++;
            }
            Console.ReadKey();
        }
        //Здраствуйте, если с вашими тестами работать не будет, то ошибка в передаче входных параметров.
        //Чтобы доказать работоспособность программы я в каждый проект добавил файлы где они нужны по тз
        //И прописал для каждого проекта в свойствах аргументы командной строки.
    }
}
