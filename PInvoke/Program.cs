using System.Runtime.InteropServices;

namespace Beep
{
    class Class1
    {
        [DllImport("kernel32.dll")]
        public static extern bool Beep(int frequency, int duration);

        static void Main(string[] args)
        {
            Random random = new Random();

            for (int i = 0; i < 10000; i++)
            {
                Beep(random.Next(10000), 100);
            }
        }
    }
}