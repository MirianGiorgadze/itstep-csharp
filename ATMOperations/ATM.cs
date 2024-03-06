namespace ATMOperations
{
    public class ATM
    {
        private List<Client> clients;
        private Client loggedInClient;
        public Client LoggedInClient
        {
            get { return loggedInClient; }
        }
        public ATM()
        {
            clients = new List<Client>();
            loggedInClient = null;
        }
        
        public void RegisterClient(Client client)
        {
            if (clients.Exists(c => c.Id == client.Id))
            {
                Console.WriteLine("Client already registered.");
                return;
            }

            clients.Add(client);
            Console.WriteLine("Client registered successfully.");
        }

        public void Login(int id, string pin)
        {
            Client client = clients.Find(c => c.Id == id);

            if (client == null)
            {
                Console.WriteLine("Client not found.");
                return;
            }

            if (client.Pin == pin)
            {
                loggedInClient = client;
                Console.WriteLine("Login successful.");
            }
            else
            {
                Console.WriteLine("Incorrect PIN.");
            }
        }

        public void AddBalance(double amount)
        {
            if (loggedInClient == null)
            {
                Console.WriteLine("Please log in first.");
                return;
            }

            loggedInClient.Balance += amount;
            Console.WriteLine($"Added {amount} to your balance. Current balance: {loggedInClient.Balance}");
        }

        public void Withdraw(double amount)
        {
            if (loggedInClient == null)
            {
                Console.WriteLine("Please log in first.");
                return;
            }

            if (loggedInClient.Balance < amount)
            {
                Console.WriteLine("Insufficient balance.");
                return;
            }

            loggedInClient.Balance -= amount;
            Console.WriteLine($"Withdrawn {amount} from your balance. Current balance: {loggedInClient.Balance}");
        }

        public void CheckBalance()
        {
            if (loggedInClient == null)
            {
                Console.WriteLine("Please log in first.");
                return;
            }

            Console.WriteLine($"Your balance: {loggedInClient.Balance}");
        }
    }
}
