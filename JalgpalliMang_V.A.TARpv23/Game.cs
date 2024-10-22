using System;
using JalgpalliMang_V.A.TARpv23;

namespace JalgpalliMang_V.A.TARpv23
{
    public class Game
    {
        public Team HomeTeam { get; }
        public Team AwayTeam { get; }
        public Stadium Stadium { get; }
        public Ball Ball { get; private set; }
        public Point Score { get; private set; }

        private Stadium _stadium;
        private Player[] _homeTeam;
        private Player[] _awayTeam;
        private Ball _ball;
        private Team _teamHome;
        private Team _teamAway;

        public Game(Stadium stadium)
        {
            _stadium = stadium;

            // Создаем команды
            _teamHome = new Team("Домашняя команда");
            _teamAway = new Team("Гостевая команда");

            // Создаем игроков для домашней команды
            _homeTeam = new Player[]
            {
            new Player("Player 1", 5, 10, _teamHome),
            new Player("Player 2", 5, 12, _teamHome),
            new Player("Player 3", 5, 14, _teamHome),
            new Player("Player 4", 5, 16, _teamHome),
            new Player("Player 5", 5, 18, _teamHome),
            new Player("Player 6", 5, 20, _teamHome),
            new Player("Player 7", 5, 22, _teamHome),
            new Player("Player 8", 5, 24, _teamHome),
            new Player("Player 9", 5, 26, _teamHome),
            new Player("Player 10", 5, 28, _teamHome),
            new Player("Player 11", 5, 30, _teamHome)
            };

            // Создаем игроков для гостевой команды
            _awayTeam = new Player[]
            {
            new Player("Player A", 60, 10, _teamAway),
            new Player("Player B", 60, 12, _teamAway),
            new Player("Player C", 60, 14, _teamAway),
            new Player("Player D", 60, 16, _teamAway),
            new Player("Player E", 60, 18, _teamAway),
            new Player("Player F", 60, 20, _teamAway),
            new Player("Player G", 60, 22, _teamAway),
            new Player("Player H", 60, 24, _teamAway),
            new Player("Player I", 60, 26, _teamAway),
            new Player("Player J", 60, 28, _teamAway),
            new Player("Player K", 60, 30, _teamAway)
            };

            // Создаем мяч
            _ball = new Ball(35, 20);
        }

        public void Start()
        {
            while (true)
            {
                _stadium.Draw(); // Рисуем стадион

                // Рисуем игроков
                foreach (var player in _homeTeam)
                {
                    player.Draw(); // Рисуем игроков домашней команды
                }

                foreach (var player in _awayTeam)
                {
                    player.Draw(); // Рисуем игроков гостевой команды
                }

                _ball.Draw(); // Рисуем мяч

                // Логика передачи мяча (пример)
                // Передача мяча от первого игрока домашней команды ко второму
                _homeTeam[0].PassBall(_ball, _homeTeam[1]);

                // Двигаем мяч в сторону ворот (пример)
                _ball.MoveTowardsGoal(_teamAway);

                Thread.Sleep(100); // Задержка для обновления
            }
        }

    public void Move()
        {
            // Двигаем команды и мяч
            HomeTeam.Move();
            AwayTeam.Move();
            

            // Проверяем, был ли забит гол
            CheckForGoal();
        }

        private void CheckForGoal()
        {
            // Проверка на гол в ворота домашней команды
            if (Ball.X < 0)
            {
                Score.AwayTeamScored();
                ResetBallPosition();
            }
            // Проверка на гол в ворота гостевой команды
            else if (Ball.X > Stadium.Width)
            {
                Score.HomeTeamScored();
                ResetBallPosition();
            }
        }

        private void ResetBallPosition()
        {
            // Возвращаем мяч в центр поля
            Ball.SetSpeed(0, 0);
            Ball.X = Stadium.Width / 2;
            Ball.Y = Stadium.Height / 2;
            Console.WriteLine("Мяч возвращен в центр поля.");
        }

        // Добавленный метод GetPositionForTeam
        // Возвращает положение игрока в зависимости от его команды
        public (double, double) GetPositionForTeam(Team team, double x, double y)
        {
            // Если команда домашняя, возвращаем координаты как есть
            if (team == HomeTeam)
            {
                return (x, y);
            }
            // Если команда гостевая, меняем координаты местами
            else
            {
                return (Stadium.Width - x, Stadium.Height - y);
            }
        }

        // Метод для получения позиции мяча для команды
        public (double, double) GetBallPositionForTeam(Team team)
        {
            return GetPositionForTeam(team, Ball.X, Ball.Y);
        }

        // Метод для задания скорости мяча для команды
        public void SetBallSpeedForTeam(Team team, double vx, double vy)
        {
            if (team == HomeTeam)
            {
                Ball.SetSpeed(vx, vy);
            }
            else
            {
                Ball.SetSpeed(-vx, -vy);
            }
        }
    }
}
