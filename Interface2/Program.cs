using System;

namespace Interface2
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat();
            cat.Scream += Mouse;
            cat.Scream += People;

            cat.catCome();
            cat.catCome();
        }

        public delegate void ScreamHandler();

        public class Cat
        {
            public event ScreamHandler Scream;

            public void catCome()
            {
                Console.WriteLine("猫过来，叫了一声");
                Scream?.Invoke();
            }
        }

        public static void Mouse()
        {
            Console.WriteLine("老鼠跑了");
        }

        public static void People()
        {
            Console.WriteLine("主人醒了");
        }
    }
}
