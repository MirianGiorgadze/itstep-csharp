namespace ATMOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            ATM atm = new ATM();
            ATMLogger logger = new ATMLogger();
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Welcome to the ATM.");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Log in");
                Console.WriteLine("3. Check Balance");
                Console.WriteLine("4. Add Balance");
                Console.WriteLine("5. Withdraw");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                int option;
                if (int.TryParse(Console.ReadLine(), out option))
                {
                    switch (option)
                    {
                        case 1:
                            Client newClient = CreateNewClient();
                            atm.RegisterClient(newClient);
                            logger.LogOperation(newClient,"Registration", $"Registered Successfully");
                            break;
                        case 2:
                            Console.Write("Enter ID: ");
                            int loginId = int.Parse(Console.ReadLine());
                            Console.Write("Enter PIN: ");
                            string loginPin = Console.ReadLine();
                            atm.Login(loginId, loginPin);
                            logger.LogOperation(atm.LoggedInClient, "Log in", "Logged in Successfully");
                            break;
                        case 3:
                            atm.CheckBalance();
                            logger.LogOperation(atm.LoggedInClient,
                                "Check Ballance",
                                $"Checked Balance. Current Balance: {atm.LoggedInClient.Balance}GEL");
                            break;
                        case 4:
                            Console.Write("Enter amount to add: ");
                            double addAmount = double.Parse(Console.ReadLine());
                            atm.AddBalance(addAmount);
                            logger.LogOperation(atm.LoggedInClient,
                                            "Add Cash", 
                                $"Added Amount {addAmount}GEL. Current Balance: {atm.LoggedInClient.Balance}GEL");
                            break;
                        case 5:
                            Console.Write("Enter amount to withdraw: ");
                            double withdrawAmount = double.Parse(Console.ReadLine());
                            atm.Withdraw(withdrawAmount);
                            logger.LogOperation(atm.LoggedInClient, 
                                "Withdraw Cash",
                                    $"Withdrawn Amount {withdrawAmount}GEL. Current Balance: {atm.LoggedInClient.Balance}GEL");
                            break;
                        case 6:
                            isRunning = false;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please choose again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }

                Console.WriteLine();
            }
        }

        static Client CreateNewClient()
        {
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter Identity Number: ");
            string identityNumber = Console.ReadLine();

            Client newClient = new Client
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                IdentityNumber = identityNumber
            };
            Console.WriteLine("Registered Successfully!");
            Console.WriteLine("Account Details:");
            Console.WriteLine(newClient);
            return newClient;
        }
    }
}
