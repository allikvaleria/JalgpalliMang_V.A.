using System;
using JalgpalliMang_V.A.TARpv23;

namespace JalgpalliMang_V.A.TARpv23
{
    public class Stadium
    {
        public int Width { get; }
        public int Height { get; }


        public Stadium(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public bool IsIn(double x, double y)
        {
            return x >= 0 && x <= Width && y >= 0 && y <= Height;
        }

        public void Draw()
        {
            // Рисуем верхнюю рамку стадиона
            Console.WriteLine(new string('═', Width));

            // Рисуем стороны стадиона с воротами
            for (int y = 0; y < Height; y++)
            {
                Console.Write("║"); // Левая сторона стадиона

                // Проверяем, нужно ли рисовать ворота
                if (y >= Height / 2 - 2 && y <= Height / 2 + 2) // Высота ворот
                {
                    Console.Write("=="); // Ворота слева
                }
                else
                {
                    Console.Write("  "); // Пустое пространство
                }

                Console.Write(new string(' ', Width - 22)); // Пустое пространство между воротами

                // Проверяем, нужно ли рисовать ворота справа
                if (y >= Height / 2 - 2 && y <= Height / 2 + 2) // Высота ворот
                {
                    Console.Write("=="); // Ворота справа
                }

                Console.WriteLine("║"); // Правая сторона стадиона
            }

            // Рисуем нижнюю рамку стадиона
            Console.WriteLine(new string('═', Width));
        }

        //public void DrawGoals()
        //{
        //    // Определяем позицию для ворот
        //    int goalY = Height / 2; // Высота для ворот (по центру)

        //    // Рисуем ворота слева
        //    Console.SetCursorPosition(0, goalY); // Позиция для ворот
        //    Console.Write(new string('=', 10)); // Линия ворот слева

        //    // Рисуем ворота справа
        //    Console.SetCursorPosition(Width - 10, goalY); // Позиция для ворот
        //    Console.Write(new string('=', 10)); // Линия ворот справа
        //}

        //public void DrawField()
        //{
        //    Console.Clear();
        //    DrawGoals();
        //}
    }
}
