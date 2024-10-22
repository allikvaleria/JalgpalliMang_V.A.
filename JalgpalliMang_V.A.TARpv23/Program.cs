using System;
using System.Threading;

namespace JalgpalliMang_V.A.TARpv23
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создание стадиона
            Stadium stadium = new Stadium(80, 20);

            // Создание игры
            Game game = new Game(stadium);
            game.Start(); // Запуск игры
        }
    }
}
