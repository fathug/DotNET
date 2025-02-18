using System;

namespace Interface
{
    class Program
    {
        static void Main(string[] args)
        {

            DrawRect draw1 = new DrawRect();
            draw1.Draw();

            IDraw draw2 = new DrawCircle();
            draw2.Draw();
        }

        // 定义接口
        public interface IDraw
        {
            void Draw();
        }

        public class DrawRect : IDraw
        {
            public void Draw()
            {
                Console.WriteLine("rect");
            }
        }

        public class DrawCircle : IDraw
        {
            public void Draw()
            {
                Console.WriteLine("circle");
            }
        }
    }
}
