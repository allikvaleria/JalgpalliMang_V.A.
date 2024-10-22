using System;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Collections.Generic;
using JalgpalliMang_V.A.TARpv23;

namespace JalgpalliMang_V.A.TARpv23
{
    public class Team
    {
        public List<Player> Players { get; } = new List<Player>();
        public string Name { get; private set; }
        public Game Game { get; set; }


        public Team(string name)
        {
            Name = name;
        }

        public void StartGame(int width, int height) // Принимаем параметры ширины и высоты
        {
            Random rnd = new Random();
            foreach (var player in Players)
            {
                player.SetPosition(
                    rnd.NextDouble() * width,
                    rnd.NextDouble() * height
                );
            }
        }

        

        public (double, double) GetBallPosition()
        {
            if (Game == null)
            {
                throw new InvalidOperationException("Игра не инициализирована для команды.");
            }
            return Game.GetBallPositionForTeam(this);
        }

        public void SetBallSpeed(double vx, double vy)
        {
            Game.SetBallSpeedForTeam(this, vx, vy);
        }

        public Player GetClosestPlayerToBall()
        {
            Player closestPlayer = Players[0];
            double bestDistance = Double.MaxValue;
            foreach (var player in Players)
            {
                var distance = player.GetDistanceToBall();
                if (distance < bestDistance)
                {
                    closestPlayer = player;
                    bestDistance = distance;
                }
            }

            return closestPlayer;
        }

        public void Move()
        {
            GetClosestPlayerToBall().MoveTowardsBall();
            Players.ForEach(player => player.Move());
        }

        public void DrawPlayers()
        {
            foreach (var player in Players)
            {
                if (Name == "Домашняя команда")
                {
                    Console.ForegroundColor = ConsoleColor.Blue; // Синий цвет для домашней команды
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red; // Красный цвет для гостевой команды
                }

                player.Draw(); // Отрисовываем игрока

                Console.ResetColor(); // Сбрасываем цвет после отрисовки
            }
        }
    }
}