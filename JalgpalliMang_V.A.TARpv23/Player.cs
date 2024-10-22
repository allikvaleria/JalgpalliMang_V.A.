using System;
using JalgpalliMang_V.A.TARpv23;

namespace JalgpalliMang_V.A.TARpv23
{
    public class Player
    {
        public string Name { get; }
        public double X { get; private set; }
        public double Y { get; private set; }
        private double _vx, _vy;
        public Team Team { get; } // Объект команды

        

        private const double MaxSpeed = 5;
        private const double MaxKickSpeed = 25;
        private const double BallKickDistance = 10;

        private Random _random = new Random();

        public Player(string name, double x, double y, Team team)
        {
            Name = name;
            X = x;
            Y = y;
            Team = team; // Инициализация команды
        }

      

        public void SetPosition(double x, double y)
        {
            X = x;
            Y = y;
        }

        public (double, double) GetAbsolutePosition()
        {
            return Team!.Game.GetPositionForTeam(Team, X, Y);
        }

        public double GetDistanceToBall()
        {
            var ballPosition = Team!.GetBallPosition();
            var dx = ballPosition.Item1 - X;
            var dy = ballPosition.Item2 - Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public void MoveTowardsBall()
        {
            var ballPosition = Team!.GetBallPosition();
            var dx = ballPosition.Item1 - X;
            var dy = ballPosition.Item2 - Y;
            var ratio = Math.Sqrt(dx * dx + dy * dy) / MaxSpeed;
            _vx = dx / ratio;
            _vy = dy / ratio;
        }

        public void Move()
        {
            if (Team.GetClosestPlayerToBall() != this)
            {
                _vx = 0;
                _vy = 0;
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
            var newAbsolutePosition = Team.Game.GetPositionForTeam(Team, newX, newY);
            if (Team.Game.Stadium.IsIn(newAbsolutePosition.Item1, newAbsolutePosition.Item2))
            {
                X = newX;
                Y = newY;
            }
            else
            {
                _vx = _vy = 0;
            }
        }

        //Muudused
        public void Draw()
        {
            // Преобразуем X и Y из double в int
            Console.SetCursorPosition((int)X, (int)Y);

            // Проверяем команду и устанавливаем цвет
            if (Team.Name == "Гостевая команда")
            {
                Console.ForegroundColor = ConsoleColor.Red; // Красный цвет для гостевой команды
                Console.Write("A"); // Отображение игрока
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue; // Синий цвет для домашней команды
                Console.Write("H"); // Отображение игрока
            }

            Console.ResetColor(); // Сбрасываем цвет после отрисовки
        }

        public void PassBall(Ball ball, Player receiver)
        {
            // Передаем мяч другому игроку
            if (Math.Abs(X - ball.X) < 2 && Math.Abs(Y - ball.Y) < 2)
            {
                ball.X = receiver.X; // Обновляем позицию мяча
                ball.Y = receiver.Y; // Обновляем позицию мяча
            }
        }
    }
}
