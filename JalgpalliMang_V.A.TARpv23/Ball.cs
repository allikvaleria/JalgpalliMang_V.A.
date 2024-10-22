using System;
using JalgpalliMang_V.A.TARpv23;

namespace JalgpalliMang_V.A.TARpv23
{
    public class Ball
    {
        public double X { get; set; } // Добавили публичный сеттер
        public double Y { get; set; } // Добавили публичный сеттер

        private double _vx, _vy;
        private Game _game;

        public Ball(double x, double y)
        {
            X = x;
            Y = y;
        }

        public void SetSpeed(double vx, double vy)
        {
            _vx = vx;
            _vy = vy;
        }

        public void MoveTowards(Player player)
        {
            // Двигаем мяч к игроку
            if (X < player.X)
                X += 0.5; // Двигаем вправо
            else if (X > player.X)
                X -= 0.5; // Двигаем влево

            if (Y < player.Y)
                Y += 0.5; // Двигаем вниз
            else if (Y > player.Y)
                Y -= 0.5; // Двигаем вверх
        }

        public void MoveToGoal(Goal goal)
        {
            // Двигаем мяч к воротам
            if (X < goal.X)
                X += 0.5; // Двигаем вправо
            else if (X > goal.X)
                X -= 0.5; // Двигаем влево
        }

        public void Draw()
        {
            Console.SetCursorPosition((int)X, (int)Y);
            Console.Write("O"); // Отображение мяча
        }

        public void MoveTowardsGoal(Team team)
        {
            // Здесь мы просто движем мяч вниз к воротам
            // В зависимости от команды, перемещение может отличаться
            if (team.Name == "Гостевая команда")
            {
                // Если это гостевая команда, двигаем мяч к правым воротам
                X += 1; // Пример: движение вправо (можно изменить по необходимости)
                Y = Console.WindowHeight / 2; // Пример: позиция Y для ворот
            }
            else
            {
                // Если это домашняя команда, двигаем мяч к левым воротам
                X -= 1; // Пример: движение влево (можно изменить по необходимости)
                Y = Console.WindowHeight / 2; // Пример: позиция Y для ворот
            }

            // Ограничиваем движение мяча, чтобы он не выходил за границы поля
            if (X < 0) X = 0;
            if (X >= Console.WindowWidth) X = Console.WindowWidth - 1;
        }
    }
}
