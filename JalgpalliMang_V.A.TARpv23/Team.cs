using System;
using System.Collections.Generic;
using System.Linq;

namespace JalgpalliMang_V.A.TARpv23
{
    class Team
    {
        public string Name { get; }
        public List<Player> Players { get; private set; }
        public Game Game { get; private set; }

        public Team(string name)
        {
            Name = name;
            Players = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            player.Team = this; // Устанавливаем команду игрока
            Players.Add(player);
        }

        public void AssignGame(Game game)
        {
            Game = game; // Устанавливаем игру для команды
        }

        public (double, double) GetBallPosition()
        {
            // Возвращаем позицию мяча
            return Game.Ball.Position; // Предполагается, что у мяча есть свойство Position
        }

        public Player GetClosestPlayerToBall()
        {
            var ballPosition = GetBallPosition();
            return Players.OrderBy(p => p.GetDistanceToBall()).FirstOrDefault();
        }

        public void SetBallSpeed(double vx, double vy)
        {
            Game.Ball.SetSpeed(vx, vy); // Устанавливаем скорость мяча
        }

        public void StartGame(double startX, double startY)
        {
            Random random = new Random();
            foreach (var player in Players)
            {
                double randomX = random.NextDouble() * Game.Stadium.Width; // Случайная позиция по X
                double randomY = random.NextDouble() * Game.Stadium.Height; // Случайная позиция по Y
                player.SetPosition(randomX, randomY); // Устанавливаем случайную позицию игрока
            }
        }

        public void Move()
        {
            foreach (var player in Players)
            {
                player.Move();
            }
        }

        public void Draw()
        {
            foreach (var player in Players)
            {
                player.Draw();
            }
        }
    }
}
