using System;

namespace JalgpalliMang_V.A.TARpv23
{
    class Game
    {
        public Team HomeTeam { get; }
        public Team AwayTeam { get; }
        public Ball Ball { get; }
        public Stadium Stadium { get; }

        public Game(Team homeTeam, Team awayTeam, Stadium stadium)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            Stadium = stadium;
            Ball = new Ball(stadium.Width / 2, stadium.Height / 2, this);
        }

        public void Start()
        {
            HomeTeam.StartGame(Stadium.Width / 4, Stadium.Height / 2);
            AwayTeam.StartGame(3 * Stadium.Width / 4, Stadium.Height / 2);
        }

        public void Move()
        {
            Ball.Move(); // Движение мяча
        }
    }
}
