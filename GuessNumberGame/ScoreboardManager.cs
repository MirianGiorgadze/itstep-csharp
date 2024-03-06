namespace GuessNumberGame
{
    public class ScoreboardManager
    {
        private const string ScoreboardFilePath = "../../../scoreboard.csv";

        public void UpdateScoreboard(string playerName, int score)
        {
            List<ScoreboardEntry> scoreboard = LoadScoreboard();

            scoreboard.Add(new ScoreboardEntry
            {
                PlayerName = playerName,
                Score = score,
                Date = DateTime.Now
            });

            scoreboard = scoreboard.OrderByDescending(entry => entry.Score).ThenBy(entry => entry.Date).ToList();

            scoreboard = scoreboard.Take(10).ToList();

            SaveScoreboard(scoreboard);
        }

        public List<ScoreboardEntry> LoadScoreboard()
        {
            List<ScoreboardEntry> scoreboard = new List<ScoreboardEntry>();

            if (File.Exists(ScoreboardFilePath))
            {
                string[] lines = File.ReadAllLines(ScoreboardFilePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    scoreboard.Add(new ScoreboardEntry
                    {
                        PlayerName = parts[0],
                        Score = int.Parse(parts[1]),
                        Date = DateTime.Parse(parts[2])
                    });
                }
            }

            return scoreboard;
        }

        private void SaveScoreboard(List<ScoreboardEntry> scoreboard)
        {
            using (StreamWriter writer = new StreamWriter(ScoreboardFilePath))
            {
                foreach (var entry in scoreboard)
                {
                    writer.WriteLine($"{entry.PlayerName},{entry.Score},{entry.Date:yyyy-MM-dd HH:mm:ss}");
                }
            }
        }

        public void PrintScoreboard()
        {
            List<ScoreboardEntry> scoreboard = LoadScoreboard();

            Console.WriteLine("Scoreboard:");
            Console.WriteLine("Rank\tName\tScore\tDate");

            for (int i = 0; i < scoreboard.Count; i++)
            {
                Console.WriteLine($"{i + 1}\t{scoreboard[i].PlayerName}\t{scoreboard[i].Score}\t{scoreboard[i].Date:yyyy-MM-dd HH:mm:ss}");
            }
        }
    }

    public class ScoreboardEntry
    {
        public string PlayerName { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }
    }
}
