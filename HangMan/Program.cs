using Hangman;

namespace HangMan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            string[] wordList = LoadWordListFromFile("../../../words.txt");
            Console.WriteLine("HangMan Game! Press any key to start... 0 - exit");
            var answer = Console.ReadLine();
            ScoreboardManager scoreboard = new ScoreboardManager();
            while (!answer.Equals("0"))
            {
                var scoreboardManager = new ScoreboardManager();
                Console.WriteLine("Enter your name:");
                name = Console.ReadLine();
                HangmanGame game = new HangmanGame(wordList);
                game.Start();
                scoreboardManager.UpdateScoreboard(name, game.Score);
                scoreboardManager.PrintScoreboard();
                Console.WriteLine("Guess Number Game! Press any key to start... 0 - exit");
                answer = Console.ReadLine();
            }
        }
        

        static string[] LoadWordListFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Error: File '{filePath}' not found.");
                return Array.Empty<string>();
            }

            return File.ReadAllLines(filePath);
        }
    }
}
