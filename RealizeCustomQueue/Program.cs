using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomQueue;
using System.Diagnostics;

namespace RealizeCustomQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomQueue<int> customQueue = new CustomQueue<int>();
            Queue<int> Queue = new Queue<int>();
            Stopwatch stopwatch = new Stopwatch();
            //Тест кастомной очереди
            stopwatch.Start();
            for (int i = 1; i <= 100000; i++)
            {
                customQueue.Enqueue(i);
            }
            for (int i = 1; i <= 50000; i++)
            {
                customQueue.Dequeue();
            }
            for (int i = 50001; i <= 100000; i++)
            {
                if (customQueue.Dequeue() != i)
                {
                    throw new Exception("Ошибка наличия элемента!");
                }
            }
            stopwatch.Stop();
            Console.WriteLine($"Время кастомной очереди: {stopwatch.ElapsedMilliseconds}");

            //Тест майкрософтовской очереди
            stopwatch.Restart();
            for (int i = 1; i <= 100000; i++)
            {
                Queue.Enqueue(i);
            }
            for (int i = 1; i <= 50000; i++)
            {
                Queue.Dequeue();
            }
            for (int i = 50001; i <= 100000; i++)
            {
                if (Queue.Dequeue() != i)
                {
                    throw new Exception("Ошибка наличия элемента!");
                }
            }
            stopwatch.Stop();
            Console.WriteLine($"Время майкрософтовской очереди: {stopwatch.ElapsedMilliseconds}");
        }
    }
}
