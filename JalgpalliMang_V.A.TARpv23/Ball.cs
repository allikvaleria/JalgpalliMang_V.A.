using System;

namespace JalgpalliMang_V.A.TARpv23
{
class Ball
    {
        private double _x;
        private double _y;
        private Game _game;

        public (double, double) Position => (_x, _y); // Свойство для получения позиции мяча
        private double _vx, _vy; // Скорость мяча

        public Ball(double x, double y, Game game)
        {
            _x = x;
            _y = y;
            _game = game;
        }

        public void SetSpeed(double vx, double vy)
        {
            _vx = vx;
            _vy = vy;
        }

        public void Move()
        {
            double newX = _x + _vx;
            double newY = _y + _vy;

            // Проверка границ стадиона
            if (newX < 0 || newX >= _game.Stadium.Width)
            {
                _vx = -_vx;
                newX = _x + _vx;
            }

            if (newY < 0 || newY >= _game.Stadium.Height)
            {
                _vy = -_vy;
                newY = _y + _vy;
            }

            _x = newX;
            _y = newY;
        }

        public void Draw()
        {
            Console.SetCursorPosition((int)_x, (int)_y);
            Console.ForegroundColor = ConsoleColor.Yellow; // Цвет мяча
            Console.Write('O'); // Символ мяча
        }
    }
}
