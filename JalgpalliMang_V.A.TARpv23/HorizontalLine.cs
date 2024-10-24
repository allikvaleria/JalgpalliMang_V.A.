using System;
using JalgpalliMang_V.A.TARpv23;

namespace JalgpalliMang_V.A.TARpv23
{
    public class HorizontalLine
    {
        //punktide nimekiri (список точек)
        private  List <Point> point = new List<Point>();
        //joonistab punktid algsest lõppjooneni ühele joonele 
        //рисует точки от начальной до конечной на одной линии 
        public HorizontalLine(int xLeft, int xRight, int y, char sym)
        {
            for (int x = xLeft; x <= xRight; x++)
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
