using System;

namespace JalgpalliMang_V.A.TARpv23
{
    public class Point
    {
        public int HomeTeamScore { get; private set; }
        public int AwayTeamScore { get; private set; }

        public Point()
        {
            HomeTeamScore = 0;
            AwayTeamScore = 0;
        }

        public void HomeTeamScored()
        {
            HomeTeamScore++;
            Console.WriteLine("Гол! Домашняя команда забила. Счет: " + HomeTeamScore + " - " + AwayTeamScore);
        }

        public void AwayTeamScored()
        {
            AwayTeamScore++;
            Console.WriteLine("Гол! Гостевая команда забила. Счет: " + HomeTeamScore + " - " + AwayTeamScore);
        }
    }
}
