using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentBagDemo
{
    internal static class Program
    {
        static void Main()
        {
            BlockingCollection<int> blockCollect = new BlockingCollection<int>(5);

            // 创建一个生产者任务，在后台线程中运行
            Task producer = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));

                    blockCollect.Add(i);
                    //Console.WriteLine($"集合现有{blockCollect.Count}个元素");
                }
                blockCollect.CompleteAdding();
            });

            // 主线程作为消费者从BlockingCollection中读取数据
            foreach (int item in blockCollect.GetConsumingEnumerable())
            {
                Console.WriteLine($"取出{item}");
                //Thread.Sleep(5000);
            }

            Console.ReadKey();
        }
    }
}
