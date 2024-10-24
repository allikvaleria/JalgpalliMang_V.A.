using System;

namespace JalgpalliMang_V.A.TARpv23
{
    class Point
    {
        public int x { get; }
        public int y { get; }
        public char symbol { get; }

        public Point(int _x, int _y, char _symbol)
        {
            x = _x;
            y = _y;
            symbol = _symbol;
        }
        //Meetod ekraanile punktide kuvamiseks
        //Метод для отображения точек на экране
        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }
    }
}
