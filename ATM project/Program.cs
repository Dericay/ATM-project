using System;
using System.Net.NetworkInformation;
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

            decimal[][] accArray = new decimal[5][];
            accArray[0] = new decimal[3];
            accArray[1] = new decimal[3];
            accArray[2] = new decimal[4];
            accArray[3] = new decimal[2];
            accArray[4] = new decimal[3];

            accArray[0][0] = 2569.50m;
            accArray[0][1] = 150.43m;
            accArray[1][0] = 140.04m;
            accArray[1][1] = 1020.52m;
            accArray[1][2] = 100.28m;
            accArray[2][0] = 250m;
            accArray[2][1] = 300.52m;
            accArray[2][2] = 100.2m;
            accArray[2][3] = 205.34m;
            accArray[3][0] = 20m;
            accArray[3][1] = 150.4m;
            accArray[4][0] = 100.25m;
            accArray[4][1] = 450.50m;
            accArray[4][2] = 342.50m;




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
                    Check(Users, username, pin);
                    
                    
                    if (Check(Users, username, pin))
                    {
                        successfull = true;
                        Meny(username,Users, accArray, successfull);
                        
                    }                   
                    else
                    {
                        Console.WriteLine("Tyvärr du skrev fel användare eller pin, tyck enter och försök igen!");
                        Correct = false;
                        tries++;
                        Console.ReadKey();
                        Console.Clear();
                        

                    }
                    

                }

            }

        }
        static bool Check(string[,] Users, string username, string pin)
        {
            for (int i = 0; i < Users.GetLength(0); i++)
            {
                if(Users[i, 0] == username  && Users[i, 1] == pin)
                {
                    return true;
                }
                
                    
            }
            return false;

        }
        public static void Meny(string username, string[,] Users, decimal[][] accArray, bool successfull)
        {
            do
            {
                
                Console.WriteLine("[1] Se dina konton och saldo");
                Console.WriteLine("[2] Överföring melland konto");
                Console.WriteLine("[3] Ta ut pengar");
                Console.WriteLine("[4] Avsluta");

                int choice = int.Parse(Console.ReadLine());


                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Dina konton och saldo");
                        account(Users, accArray, username);
                        
                        break;

                    case 2:
                        Console.WriteLine("Överföring");
                        //transfer();
                        break;

                    case 3:
                        Console.WriteLine("Ta ut pengar");
                        //withdraw();
                        break;

                    case 4:
                        Console.WriteLine("Avsluta, tack för du använder vår tjänst.");
                        //CloseDown
                        break;
                  
                }
            } while (successfull == true);
        }    
        public static int LoginUser(string[,] Users, string username)
        {
            for (int i = 0;i < Users.GetLength(0); i++)
            {
                if (Users[i, 0] == username)
                {
                    return i;
                }
            }
            return 0;
        }
        public static void account(string[,] Users, decimal[][] accArray, string username)
        {
            int Active = LoginUser(Users, username);
            string[] AccArr = new string[4];
            AccArr[0] = "Lönekonto";
            AccArr[1] = "Sparkonto";
            AccArr[2] = "Semesterkonto";
            AccArr[3] = "Privatkonto";
            Console.WriteLine("Konton");
            for (int i = 0; i < accArray[Active].Length; i++)
            {
                if (accArray[Active][i] != 0)
                {
                    Console.WriteLine($"{AccArr[i]} {accArray[Active][i]}kr");


                }
                return;
            }
                
                
            
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