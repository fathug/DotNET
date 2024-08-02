using System.Runtime.InteropServices;

class Program
{
    [DllImport("../../../../x64/Debug/NativeDll.dll")]
    public static extern int Add(int a, int b);

    public static void Main(string[] args)
    {
        int sum = Add(23, 45);
        Console.WriteLine(sum);
        Console.ReadKey();
    }
}
