using Task4.Morty;
namespace Task4.Statistics
{
    public class StatisticCollector
    {
        public int RickStayedCount { get; private set; }
        public int TotalRounds { get; private set; }
        public int WinsStayed { get; private set; }
        public int WinsTotal { get; private set; }
        public float WinRateStayedActual => (float)WinsStayed / RickStayedCount;
        public float WinRateSwitchedActual => (float)(WinsTotal - WinsStayed) / (TotalRounds - RickStayedCount);

        private BaseMorty morty;

        public StatisticCollector(BaseMorty morty)
        {
            this.morty = morty;
        }

        public void RegisterRound(bool switched, bool win)
        {
            this.TotalRounds++;
            if (!switched) this.RickStayedCount++;
            if (win)
            {
                this.WinsTotal++;
                if (!switched) this.WinsStayed++;
            }
        }

        public StatisticsData GetStatistics()
        {
            return new StatisticsData
            {
                TotalRounds = this.TotalRounds,
                RickStayedCount = this.RickStayedCount,
                WinsTotal = this.WinsTotal,
                WinsStayed = this.WinsStayed,
                WinRateStayedEstimated = this.morty.WinRateStayed,
                WinRateSwitchedEstimated = this.morty.WinRateSwitched
            };
        }
    }
}