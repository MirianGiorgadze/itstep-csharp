namespace GuessNumberGame
{
    public class Game
    {
        private int _numberToGuess;
        private int _maxAttempts;
        private int _attemptsLeft;
        private int _maxNumber;
        private string _playerName;
        private List<int> _guessHistory;
        public int Score;
        public Game(string playerName)
        {
            _playerName = playerName;
            _guessHistory = new List<int>();
            _maxAttempts = 10;
            Score = 0;
            Play();
        }

        public void Play()
        {
            Console.WriteLine($"Welcome, {_playerName}!");
            SetDifficulty();

            Console.WriteLine($"Guess the number between 1 and {_maxNumber}.");
            Console.WriteLine($"You have {_maxAttempts} attempts.");

            GenerateRandomNumber();

            while (_attemptsLeft > 0)
            {
                int guess = GetGuessFromUser();

                _guessHistory.Add(guess);

                if (guess == _numberToGuess)
                {
                    Score = (_maxAttempts - _attemptsLeft) * 100 + _maxNumber;
                    Console.WriteLine("Congratulations! You guessed the number!");
                    Console.WriteLine($"Your Score: {Score}");
                    Console.WriteLine($"Let's check if you are in our leaderboard..");
                    return;
                }
                if (guess < _numberToGuess)
                {
                    Console.WriteLine("Too low. Try again.");
                }
                else
                {
                    Console.WriteLine("Too high. Try again.");
                }

                _attemptsLeft--;
                Console.WriteLine($"Attempts left: {_attemptsLeft}");
            }

            Console.WriteLine($"Sorry, you've run out of attempts. The correct number was {_numberToGuess}.");
        }

        private int GetGuessFromUser()
        {
            int guess;
            do
            {
                Console.Write("Enter your guess: ");
            } while (!int.TryParse(Console.ReadLine(), out guess) || guess < 1 || guess > _maxNumber);

            return guess;
        }

        private void SetDifficulty()
        {
            Console.WriteLine("Choose difficulty level:");
            Console.WriteLine("1. Easy (1-15)");
            Console.WriteLine("2. Medium (1-25)");
            Console.WriteLine("3. Hard (1-50)");

            int difficultyLevel;
            do
            {
                Console.Write("Enter your choice: ");
            } while (!int.TryParse(Console.ReadLine(), out difficultyLevel) || difficultyLevel < 1 || difficultyLevel > 3);

            switch (difficultyLevel)
            {
                case 1:
                    _maxNumber = 15;
                    break;
                case 2:
                    _maxNumber = 25;
                    break;
                case 3:
                    _maxNumber = 50;
                    break;
            }

            _attemptsLeft = _maxAttempts;
        }

        private void GenerateRandomNumber()
        {
            Random rand = new Random();
            _numberToGuess = rand.Next(1, _maxNumber + 1);
        }

        private void SaveGameHistory()
        {
            // Implement saving game history to CSV file
        }
    }
}
