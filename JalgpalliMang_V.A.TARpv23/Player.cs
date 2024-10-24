using System;

namespace JalgpalliMang_V.A.TARpv23
{
    class Player
    {
        public string Name { get; }
        public double X { get; private set; }
        public double Y { get; private set; }
        public Team Team { get; set; }
        private Stadium _stadium;
        private Game _game;

        private double _vx, _vy; // Скорость движения игрока
        private const double MaxSpeed = 5; // Максимальная скорость
        private const double MaxKickSpeed = 25; // Максимальная скорость удара
        private const double BallKickDistance = 10; // Расстояние, на котором игрок может ударить по мячу
        private Random _random = new Random(); // Генератор случайных чисел

        public Player(string name, Stadium stadium, Game game)
        {
            Name = name;
            _stadium = stadium;
            _game = game;
        }

        public void SetPosition(double x, double y)
        {
            if (_stadium.IsIn(x, y))
            {
                X = x;
                Y = y;
            }
        }

        public double GetDistanceToBall()
        {
            var ballPosition = Team.GetBallPosition();
            var dx = ballPosition.Item1 - X;
            var dy = ballPosition.Item2 - Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public void Move()
        {
            // Двигаем игрока к мячу
            if (Team.GetClosestPlayerToBall() != this)
            {
                _vx = 0;
                _vy = 0;
                return; // Если это не ближайший игрок, выходим
            }

            var ballPosition = Team.GetBallPosition();
            var dx = ballPosition.Item1 - X;
            var dy = ballPosition.Item2 - Y;

            // Нормализация вектора движения
            double distanceToBall = Math.Sqrt(dx * dx + dy * dy);
            if (distanceToBall > 0)
            {
                _vx = MaxSpeed * (dx / distanceToBall);
                _vy = MaxSpeed * (dy / distanceToBall);
            }

            if (GetDistanceToBall() < BallKickDistance)
            {
                Team.SetBallSpeed(
                    MaxKickSpeed * _random.NextDouble(),
                    MaxKickSpeed * (_random.NextDouble() - 0.5)
                );
            }

            var newX = X + _vx;
            var newY = Y + _vy;
            if (_stadium.IsIn(newX, newY))
            {
                SetPosition(newX, newY);
            }
        }

        public void Draw()
        {
            Console.SetCursorPosition((int)X, (int)Y);
            Console.ForegroundColor = Team.Name == "HomeTeam" ? ConsoleColor.Red : ConsoleColor.Blue; // Цвет команды
            Console.Write(Team.Name == "HomeTeam" ? 'A' : 'H'); // Символ игрока
        }
    }
}
