namespace GuessNumberGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string playerName;
            Console.WriteLine("Guess Number Game! Press any key to start... 0 - exit");
            var answer = Console.ReadLine();
            ScoreboardManager scoreboard = new ScoreboardManager();
            while (!answer.Equals("0"))
            {
                Console.WriteLine("Enter Name");
                playerName = Console.ReadLine();
                Game game = new Game(playerName);
                scoreboard.UpdateScoreboard(playerName, game.Score);
                scoreboard.PrintScoreboard();
                Console.WriteLine("Guess Number Game! Press any key to start... 0 - exit");
                answer = Console.ReadLine();
            }
        }
    }
}
