namespace eser_S1L4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            bool isExit = false;
            bool isLoggedIn = false;
            do
            {
                Console.WriteLine("Welcome!");
                Console.WriteLine("Please select the operation:");
                if (!isLoggedIn) Console.WriteLine("1. Login");
                Console.WriteLine("2. Logout");
                Console.WriteLine("3. Verify login's date");
                Console.WriteLine("4. Access List");
                Console.WriteLine("5. Exit");

                Console.WriteLine();
                Console.Write("Insert your option: ");
                int selectedOption = int.Parse(Console.ReadLine());
                switch (selectedOption)
                {
                    case 1:
                        if (!isLoggedIn)
                        {

                            Console.WriteLine("Welcome to Login procedure, please insert your username and password:");
                            Console.Write("Username: ");
                            string username = Console.ReadLine();
                            Console.Write("Password: ");
                            string password = Console.ReadLine();
                            Console.Write("Confirm password:");
                            string confirmPsw = Console.ReadLine();

                            if (password == confirmPsw)
                            {
                                isLoggedIn = Utente.Login(username, password);

                            }
                            else
                            {
                                Console.Write("Your confirmed password is different from the first one. Press any key to return to menù... ");
                            }

                            if (!isLoggedIn)
                            {
                                Console.WriteLine("Error: Your username and/or password are invalid.");
                                Console.Write("Press any key to return to menù... ");
                                break;
                            }
                        }

                        Console.Write("Welcome user! Press any key to return to menù... ");

                        break;

                    case 2:
                        if (!isLoggedIn)
                        {
                            Console.Write("Error: You are already logged out. Press any key to return to menù... ");
                            break;
                        }
                        Console.Write("You are now logging out. Press any key to return to menù... ");
                        isLoggedIn = false;
                        break;

                    case 3:
                        if (!isLoggedIn)
                        {
                            Console.Write("Error: You are not logged in. Press any key to return to menù... ");
                            break;
                        }
                        Console.Write("Here is when you last logged in: " + Utente.GetLastLoginDate());
                        Console.WriteLine();
                        Console.Write("Press any key to return to menù...");
                        break;

                    case 4:
                        if (!isLoggedIn)
                        {
                            Console.Write("Error: You are not logged in. Press any key to return to menù... ");
                            break;
                        }

                        List<DateTime> historyAccess = Utente.GetHistoryAccess();
                        Console.WriteLine("Here is your list of accesses");
                        foreach (DateTime access in historyAccess)
                        {
                            Console.Write($"| {access} ");
                        }
                        Console.WriteLine();
                        Console.Write("Press any key to return to menù... ");

                        break;

                    case 5:
                        isExit = true;
                        Console.WriteLine();
                        Console.Write("Thank you for using our services. Press any key to Exit... ");
                        break;
                }

                Console.ReadKey();
                Console.Clear();

            } while (!isExit);




        }
    }


    static class Utente
    {
        static string _username = "qw";
        static string _password = "po";


        static List<DateTime> historyAccess = new List<DateTime>();

        public static bool Login(string username, string password)
        {
            if (_username == username && _password == password)
            {
                historyAccess.Add(DateTime.Now);
                return true;
            }
            return false;

        }

        public static bool Logout(bool isLoggedIn)
        {
            if (isLoggedIn)
            {
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

