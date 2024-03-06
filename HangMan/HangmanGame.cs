namespace Hangman
{
    public class HangmanGame
    {
        private string[] _wordList;
        private string _targetWord;
        private List<char> _correctGuesses;
        private List<char> _incorrectGuesses;
        private int _guessesLeft;
        public int Score;

        public HangmanGame(string[] wordList)
        {
            _wordList = wordList;
            _correctGuesses = new List<char>();
            _incorrectGuesses = new List<char>();
            _guessesLeft = 6;
            Score = 0;
        }

        public void Start()
        {
            // Select a random word from the word list
            Random random = new Random();
            _targetWord = _wordList[random.Next(0, _wordList.Length)];

            Console.WriteLine("Welcome to Hangman!");
            Console.WriteLine("Try to guess the word. You have 6 attempts to guess a letter or the whole word.");

            while (_guessesLeft > 0)
            {
                Console.WriteLine();
                DisplayHangman();
                DisplayWordWithGuesses();

                Console.Write($"Attempts left: {_guessesLeft}. Enter a letter or the whole word: ");
                string userInput = Console.ReadLine().ToLower();

                if (userInput.Length == 1)
                {
                    char guessedLetter = userInput[0];
                    if (char.IsLetter(guessedLetter))
                    {
                        if (_targetWord.Contains(guessedLetter))
                        {
                            Console.WriteLine($"The letter '{guessedLetter}' is in the word!");
                            _correctGuesses.Add(guessedLetter);
                        }
                        else
                        {
                            Console.WriteLine($"The letter '{guessedLetter}' is not in the word.");
                            _incorrectGuesses.Add(guessedLetter);
                            _guessesLeft--;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid letter.");
                    }
                }
                else if (userInput.Length == _targetWord.Length && userInput == _targetWord)
                {
                    Console.WriteLine("Congratulations! You guessed the word!");
                    Score = _targetWord.Length * 1000 * _guessesLeft;
                    Console.WriteLine($"Your Score is {Score}. Let's check if you are on ScoreBoard ....");
                    return;
                }
                else
                {
                    Console.WriteLine("Incorrect word guess.");
                    _guessesLeft--;
                }

                if (CheckIfWordGuessed())
                {
                    Console.WriteLine($"Congratulations! You guessed the word: {_targetWord}");
                    Score = _targetWord.Length * 1000 * _guessesLeft;
                    Console.WriteLine($"Your Score is {Score}. Let's check if you are on ScoreBoard ....");
                    return;
                }
            }

            Console.WriteLine($"Sorry, you've run out of attempts. The correct word was: {_targetWord}");
            DisplayHangman();
        }

        private void DisplayHangman()
        {
            int incorrectGuesses = _incorrectGuesses.Count;
            if (incorrectGuesses == 0)
            {
                Console.WriteLine();
                return;
            }

            Console.WriteLine("  +---+");
            Console.WriteLine("  |   |");

            switch (incorrectGuesses)
            {
                case 1:
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    break;
                case 2:
                    Console.WriteLine("  O   |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    break;
                case 3:
                    Console.WriteLine("  O   |");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("      |");
                    break;
                case 4:
                    Console.WriteLine("  O   |");
                    Console.WriteLine(" /|   |");
                    Console.WriteLine("      |");
                    break;
                case 5:
                    Console.WriteLine("  O   |");
                    Console.WriteLine(" /|\\  |");
                    Console.WriteLine("      |");
                    break;
                case 6:
                    Console.WriteLine("  O   |");
                    Console.WriteLine(" /|\\  |");
                    Console.WriteLine(" /    |");
                    break;
            }

            Console.WriteLine("      |");
            Console.WriteLine("=========");
        }


        private void DisplayWordWithGuesses()
        {
            foreach (char letter in _targetWord)
            {
                if (_correctGuesses.Contains(letter))
                {
                    Console.Write($"{letter} ");
                }
                else
                {
                    Console.Write("_ ");
                }
            }
            Console.WriteLine();
        }

        private bool CheckIfWordGuessed()
        {
            foreach (char letter in _targetWord)
            {
                if (!_correctGuesses.Contains(letter))
                {
                    return false;
                }
            }
            return true;
        }
    }

}
