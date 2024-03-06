using Newtonsoft.Json;

namespace ATMOperations
{
    public class ATMLogger
    {
        private List<OperationLog> operationLogs;
        private List<UserLog> userLogs;
        private string logFileName;
        private string usersFileName;

        public ATMLogger()
        {
            logFileName = $"../../../log/logs_{DateTime.Now:yyyy-MM-dd}.json";
            usersFileName = $"../../../log/users.json";
            operationLogs = ReadOpLogsFromFile();
            userLogs = ReadUserLogsFromFile();
            InitializeLogFile();
        }

        private void InitializeLogFile()
        {
            if (!File.Exists(logFileName))
            {
                File.WriteAllText(logFileName, "[]");
            }
        }

        public void LogOperation(Client client, string operationType, string comment)
        {
            operationLogs.Add(new OperationLog
            {
                OperationType = operationType,
                CustomerID = client.Id,
                CustomerName = $"{client.FirstName} {client.LastName}",
                Comment = comment,
                OperationDateTime = DateTime.Now
            });

            SerializeOpLogs();

            if (operationType == "Registration")
            {
                userLogs.Add(new UserLog()
                {
                    Id = client.Id,
                    Pin = client.Pin,
                    Name = client.FirstName,
                    LastName = client.LastName,
                    IdentityNumber = client.IdentityNumber,
                    DateRegistered = DateTime.Now,
                });
                SerializeUserLogs();
            }
        }

        private List<OperationLog> ReadOpLogsFromFile()
        {
            if (File.Exists(logFileName))
            {
                string json = File.ReadAllText(logFileName);
                return JsonConvert.DeserializeObject<List<OperationLog>>(json);
            }
            return new List<OperationLog>();
        }

        private void SerializeOpLogs()
        {
            string json = JsonConvert.SerializeObject(operationLogs, Formatting.Indented);
            File.WriteAllText(logFileName, json);
        }

        public List<UserLog> ReadUserLogsFromFile()
        {
            if (File.Exists(usersFileName))
            {
                string json = File.ReadAllText(usersFileName);
                return JsonConvert.DeserializeObject<List<UserLog>>(json);
            }
            return new List<UserLog>();
        }

        private void SerializeUserLogs()
        {
            string json = JsonConvert.SerializeObject(userLogs, Formatting.Indented);
            File.WriteAllText(usersFileName, json);
        }
    }

    public class OperationLog
    {
        public string OperationType { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Comment { get; set; }
        public DateTime OperationDateTime { get; set; }
    }

    public class UserLog
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateRegistered { get; set; }
        public int Id { get; set; }
        public string IdentityNumber { get; set; }
        public string Pin { get; set; }
    }
}
