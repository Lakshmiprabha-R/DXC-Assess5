// See https://aka.ms/new-console-template for more information


namespace BankDetails
{
    class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Taluk { get; set; }
        public string Village { get; set; }
        public string Phonenum { get; set; }
        public string CustomerId { get; }

        private static int lastCustomerId = 0;

        public Customer(string firstName, string lastName, string address, string taluk, string village, string phonenum)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Taluk = taluk;
            Village = village;
            if (IsValidPhoneNumber(phonenum))
            {
                Phonenum = phonenum;
            }
           
            lastCustomerId++;
            CustomerId = lastCustomerId.ToString("0001");
        }

        private bool IsValidPhoneNumber(string phonenum)
        {
            if (phonenum.Length != 10)
            {
                return false;
            }
            int stateCode;
            if (!int.TryParse(phonenum.Substring(0, 2), out stateCode))
            {
                return false;
            }
            return true;
        }
    }

    class Bank
    {
        private List<Customer> customers = new List<Customer>();

        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public void DisplayCustomerByLastName(string lastName)
        {
            foreach (Customer customer in customers)
            {
                if (customer.LastName == lastName)
                {
                    Console.WriteLine($"Customer ID: {customer.CustomerId}");
                    Console.WriteLine($"Name: {customer.FirstName} {customer.LastName}");
                    Console.WriteLine($"Address: {customer.Address}");
                    Console.WriteLine($"Taluk: {customer.Taluk}");
                    Console.WriteLine($"Village: {customer.Village}");
                    Console.WriteLine($"Phonenum: {customer.Phonenum}");
                    Console.WriteLine();
                }
            }
        }

        public void DisplayCustomersByTalukOrVillage(string taluk, string village)
        {
            Console.WriteLine("Customer ID\t\tName\t\t\tAddress\t\t\tPhonenum");
            Console.WriteLine("------------------------------------------------------------------------");
            foreach (Customer customer in customers)
            {
                if (customer.Taluk == taluk && customer.Village == village)
                {
                    Console.WriteLine($"{customer.CustomerId}\t\t{customer.FirstName} {customer.LastName}\t\t\t{customer.Address}\t\t{customer.Phonenum}");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();

            bank.AddCustomer(new Customer("Lakshmi", "Prabha", "123 Main St", "TalukXXX", "VillageAAA", "7905525595"));
            bank.AddCustomer(new Customer("Priya", "Sri", " 456 ABC street", "TalukYYY", "VillageBBB", "9841419141"));
            bank.AddCustomer(new Customer("Sowndharya", "Devi", "789 MLP street", "TalukZZZ", "VillageCCC", "9865085599"));
            Console.WriteLine("Customers with last name Prabha:");
            bank.DisplayCustomerByLastName("Sri");
            Console.WriteLine("Customers in TalukZZZ,VillageCCC:");
            bank.DisplayCustomersByTalukOrVillage ("TalukZZZ", "VillageCCC");

            Console.ReadKey();
        }
    }
}
