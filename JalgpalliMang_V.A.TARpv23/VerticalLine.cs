using System;
using JalgpalliMang_V.A.TARpv23;

namespace JalgpalliMang_V.A.TARpv23
{
    public class VerticalLine
    {
        private  List <Point> point = new List<Point>();
        //Konstruktor, mis loob vertikaalsed jooned
        //Конструктор, который создает вертикальные линии
        public VerticalLine(int yUp, int yDown, int x, char sym)
        {
            for (int y = yUp; y <= yDown; y++)
            {
                Point p = new Point(x, y, sym);
                point.Add(p);
            }
        }
        //Liini joonistamise meetod (Метод для отрисовки линии)
        public void Draw()
        {
            foreach (var p in point)
            {
                p.Draw();
            }
        } 
    }
}
