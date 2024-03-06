using System.Xml.Linq;

namespace Hangman
{
    public class ScoreboardManager
    {
        private const string ScoreboardFilePath = "../../../scoreboard.xml";

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
                XDocument doc = XDocument.Load(ScoreboardFilePath);
                foreach (XElement element in doc.Root.Elements("ScoreboardEntry"))
                {
                    scoreboard.Add(new ScoreboardEntry
                    {
                        PlayerName = element.Element("PlayerName").Value,
                        Score = int.Parse(element.Element("Score").Value),
                        Date = DateTime.Parse(element.Element("Date").Value)
                    });
                }
            }

            return scoreboard;
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

        private void SaveScoreboard(List<ScoreboardEntry> scoreboard)
        {
            XElement root = new XElement("Scoreboard");

            foreach (var entry in scoreboard)
            {
                XElement entryElement = new XElement("ScoreboardEntry",
                    new XElement("PlayerName", entry.PlayerName),
                    new XElement("Score", entry.Score),
                    new XElement("Date", entry.Date.ToString("yyyy-MM-dd HH:mm:ss")));

                root.Add(entryElement);
            }

            XDocument doc = new XDocument(root);
            doc.Save(ScoreboardFilePath);
        }
    }

    public class ScoreboardEntry
    {
        public string PlayerName { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }
    }
}
