namespace SEW0403DepencencyInjection
{

    using System;
    // Abhängigkeit (Dependency)
    public interface ILogger
    {
        void Log(string message);
    }
    // Eine Klasse mit einer Abhängigkeit
    public class CustomerService
    {
        private ILogger logger;
        // Konstruktor-Injection: Die Abhängigkeit wird über den Konstruktor injiziert.
        public CustomerService(ILogger logger)
        {
            this.logger = logger;
        }
        public void AddCustomer(string name)
        {
            // Geschäftslogik zur Kundenverwaltung
            // Verwendung der Abhängigkeit zur Protokollierung
            logger.Log($"Kunde {name} hinzugefügt.");
        }
    }
    // Eine Implementierung der Abhängigkeit (Logger)
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"Log: {message}");
        }
    }

    public class FileLogger : ILogger
    {

        public void Log(string message)
        {
            File.AppendAllText("C:/Users/Jonas/Desktop/log.txt", message + "\n"); //musst dann deinen Benutzer vom PC ändern sonst geht nix
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            // Erstellen der Abhängigkeit (Logger)
            ILogger logger = new FileLogger();
            // Erstellen der CustomerService-Instanz mit injizierter Abhängigkeit
            CustomerService customerService = new CustomerService(logger);
            // Verwendung des CustomerService

            customerService.AddCustomer("John Doe");
            customerService.AddCustomer("Spau");


        }
    }
    
}
