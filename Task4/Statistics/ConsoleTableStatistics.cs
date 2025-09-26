using ConsoleTables;

namespace Task4.Statistics
{
    public class ConsoleTableStatistics : IStatisticsDisplayer
    {
        public void DisplayStatistics(StatisticsData data)
        {
            var table = new ConsoleTable("Game Results", "Rick stayed", "Rick switched");

            table.AddRow("Rounds", data.RickStayedCount, data.RickSwitchedCount)
                 .AddRow("Wins", data.WinsStayed, data.WinsSwitched)
                 .AddRow("P(actual)", $"{data.WinRateStayedActual:F2}", $"{data.WinRateSwitchedActual:F2}")
                 .AddRow("P(estimated)", $"{data.WinRateStayedEstimated:F2}", $"{data.WinRateSwitchedEstimated:F2}");

                table.Write(Format.Alternative);
        }
    }
}