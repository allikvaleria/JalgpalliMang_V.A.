using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace JalgpalliMang_V.A.TARpv23
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создание стадиона
            var width = 80;
            var height = 20;

            var homeTeam = new Team("HomeTeam");
            var awayTeam = new Team("AwayTeam");

            var stadium = new Stadium(width, height);

            // Добавляем 11 игроков в каждую команду
            for (int i = 1; i <= 11; i++)
            {
                homeTeam.AddPlayer(new Player($"HomeTeamPlayer {i}", stadium, null));
                awayTeam.AddPlayer(new Player($"AwayTeamPlayer {i}", stadium, null));
            }

            var game = new Game(homeTeam, awayTeam, stadium);
            homeTeam.AssignGame(game); // Устанавливаем игру для команды
            awayTeam.AssignGame(game); // Устанавливаем игру для команды
            game.Start();

            // Основной игровой цикл
            while (true)
            {
                stadium.Draw();
                homeTeam.Draw();
                awayTeam.Draw();
                game.Ball.Draw();
                homeTeam.Move();
                awayTeam.Move();
                game.Move();
                Thread.Sleep(300);
            }
        }
    }
 }
