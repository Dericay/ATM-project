using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace ATM_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LogIn();
        }
        public static void LogIn()
        {
            string[,] Users = new string[5, 2];
            Users[0, 0] = "Anas";
            Users[0, 1] = "1234";
            Users[1, 0] = "Alfred";
            Users[1, 1] = "1337";
            Users[2, 0] = "Maureen";
            Users[2, 1] = "1993";
            Users[3, 0] = "Anna";
            Users[3, 1] = "9191";
            Users[4, 0] = "Lotta";
            Users[4, 1] = "1111";


            int tries = 0;
            bool successfull = false;
            bool Correct = false;
            Console.WriteLine("Välkommen, vänligen tryck enter!");
            Console.ReadKey();

            while (successfull == false && tries != 3)
            {

                while (Correct == false)
                {
                    Console.WriteLine("Skriv användarnamn: ");
                    string username = Console.ReadLine();
                    Console.WriteLine("Skriv pinkod: ");
                    string pin = Console.ReadLine();
                    if (username == Users[0, 0] && pin == Users[0, 1])
                    {
                        successfull = true;
                        Meny();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Tyvärr du skrev fel användare eller pin, tyck enter och försök igen!");
                        Correct = false;
                        tries++;
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    }

                }

            }

        }
        public static void Meny()
        {

            Console.WriteLine("Välkommen!");
            Console.WriteLine("[1] Se dina konton saldo");
            Console.WriteLine("[2] Överföring melland konto");
            Console.WriteLine("[3] Ta ut pengar");
            Console.WriteLine("[4] Avsluta");

            int choice = int.Parse(Console.ReadLine());


            switch (choice)
            {
                case 1: Console.WriteLine("Dina konton och saldo");
                    //account();
                    break;

                case 2: Console.WriteLine("Överföring");
                    //transfer();
                    break;

                case 3: Console.WriteLine("Ta ut pengar");
                    //withdraw();
                    break;

                case 4: Console.WriteLine("Avsluta, tack för du använder vår tjänst.");
                    //CloseDown
                    break;
            }
        }
        public static void account()
        {

        }
        public static void transfer()
        {

        }
        public static void withdraw()
        {

        }
        public static void CloseDown()
        {

        }
    }
}