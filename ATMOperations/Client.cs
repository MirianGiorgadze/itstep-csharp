namespace ATMOperations
{
    public class Client
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Balance { get; set; }
        public int Id { get; }
        public string Pin { get; }

        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (value >= 18)
                {
                    age = value;
                }
            }
        }

        private static int idCounter = 0; 
        private const int PinLength = 4;  

        public Client()
        {
            Id = GenerateUniqueId();   
            Pin = GenerateRandomPin(); 
        }
        private string identityNumber;

        public string IdentityNumber
        {
            get { return identityNumber; }
            set
            {
                if (value.Length == 11 && value.All(char.IsDigit))
                {
                    identityNumber = value;
                }
            }
        }
        private int GenerateUniqueId()
        {
            return ++idCounter;
        }

        private string GenerateRandomPin()
        {
            Random rand = new Random();
            string pin = rand.Next(1000, 10000).ToString(); 
            return pin;
        }

        public override string ToString()
        {

            return $"Client ID: {Id}\nName: {FirstName} {LastName}\nAge: {Age}\nIdentity Number: {IdentityNumber}\nBalance: {Balance}\nPIN: {Pin}";
        }
    }
}
