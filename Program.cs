namespace eser_S1L4
{
    internal class Program
    {
        static void Main(string[] args)
        {



            bool isExit = false;
            do
            {
                Console.WriteLine("Welcome!");
                Console.WriteLine("Please select the operation:");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Logout");
                Console.WriteLine("3. Verify login's date");
                Console.WriteLine("4. Access List");
                Console.WriteLine("5. Exit");

                bool isLoggedIn;

                int selectedOption = int.Parse(Console.ReadLine());
                switch (selectedOption)
                {
                    case 1:
                        Console.WriteLine("Welcome to Login procedure, please insert your username and password:");
                        Console.Write("Username: ");
                        string username = Console.ReadLine();
                        Console.Write("Password: ");
                        string password = Console.ReadLine();
                        Utente.Login(username, password);


                        if (!Utente.IsLoggedIn)
                        {
                            Console.WriteLine("Error: Your username and/or password are invalid.");
                            Console.Write("Press any key to go back to the main menù... ");
                            Console.ReadKey();
                        }

                        break;

                    case 2:
                        if (!Utente.IsLoggedIn)
                        {
                            Console.WriteLine("You are already logged out, press any key to return to menù");
                            break;
                        }
                        Console.WriteLine("You are now logging out...");
                        break;
                }


            } while (!isExit);

            Console.ReadKey();
        }
    }


    static class Utente
    {
        const string ACTUAL_USER = "Lello";
        const string ACTUAL_PSW = "password";
        static string _username;
        static string _password;

        static bool _isLoggedIn = false;
        static List<DateTime> historyAccess = new List<DateTime>();

        public static bool IsLoggedIn { get; }

        public static bool Login(string username, string password)
        {
            if (ACTUAL_USER == username && ACTUAL_PSW == password)
            {
                _username = username;
                _password = password;
                _isLoggedIn = true;
                historyAccess.Add(DateTime.Now);

                return _isLoggedIn;
            }
            _isLoggedIn = false;
            return _isLoggedIn;
        }

        public static bool Logout()
        {
            if (_isLoggedIn)
            {
                _username = null;
                _password = null;
                _isLoggedIn = false;

                return true;
            }
            return false;


        }

        public static List<DateTime> GetHistoryAccess()
        {
            return historyAccess;
        }

        public static DateTime GetLastLoginDate()
        {
            return historyAccess.Count > 0 ? historyAccess[historyAccess.Count - 1] : DateTime.MinValue;
        }


    }
}

