using System;
using JalgpalliMang_V.A.TARpv23;

namespace JalgpalliMang_V.A.TARpv23
{
    class Stadium
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
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }

        public void Draw()
        {
            Console.Clear(); // Очищаем экран
            for (int x = 0; x < Width; x++)
            {
                Console.SetCursorPosition(x, 0);
                Console.Write('═');
                Console.SetCursorPosition(x, Height - 1);
                Console.Write('═');
            }
            for (int y = 0; y < Height; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write('║');
                Console.SetCursorPosition(Width - 1, y);
                Console.Write('║');
            }
        }
    }
}
