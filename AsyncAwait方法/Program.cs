using System.Diagnostics;


class Program
{
    /*
    
    #region

    static void Main(string[] args)
    {
        Console.WriteLine("同步方法流程演示");
        Stopwatch sw = Stopwatch.StartNew();
        task1();
        task2();
        task3();
        Console.WriteLine("耗时" + sw.ElapsedMilliseconds.ToString() + "ms");
        Console.ReadKey();
    }

    static void task1()
    {
        Thread.Sleep(1000);
        Console.WriteLine("task1");
    }
    static void task2()
    {
        Thread.Sleep(1000);
        Console.WriteLine("task2");
    }
    static void task3()
    {
        Thread.Sleep(1000);
        Console.WriteLine("task3");
    }

    #endregion

    */

    // 打断点可以看出，虽然task1先开始实行，但是task1最后执行完await，所以会先进入其他方法的断点

    static async Task Main(string[] args)
    {
        Console.WriteLine("同步方法流程演示");
        Stopwatch sw = Stopwatch.StartNew();

        await Task.WhenAll(task1(),task2(),task3());

        Console.WriteLine("耗时" + sw.ElapsedMilliseconds.ToString() + "ms");
        Console.ReadKey();
    }
    static async Task task1()
    {
        Console.WriteLine("task1开始");
        await Task.Delay(3000);
        Console.WriteLine("task1结束");
    }
    static async Task task2()
    {
        Console.WriteLine("task2开始");
        await Task.Delay(1000);
        Console.WriteLine("task2结束");
    }
    static async Task task3()
    {
        Console.WriteLine("task3开始");
        await Task.Delay(1000);
        Console.WriteLine("task3结束");
    }
}