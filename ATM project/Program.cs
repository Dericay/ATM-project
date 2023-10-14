using System;
using System.Linq.Expressions;
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
            LogIn();//the first method to start the program
        }
        public static void LogIn()
        {
            string[,] Users = new string[5, 2];//2D array for username and pin
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

            decimal[][] accArray = new decimal[5][];//Jagged array for accounts
            accArray[0] = new decimal[2];
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



            while (successfull == false)//will be faulse untill you login
            {

                while (Correct == false && tries != 3)  //another while loop for login system, will block when reaching 3 tries            
                {
                    Console.WriteLine("Välkommen, vänligen logga in!");
                    Console.WriteLine("Skriv användarnamn: ");
                    string username = Console.ReadLine();
                    Console.WriteLine("Skriv pinkod: ");
                    string pin = Console.ReadLine();
                    Check(Users, username, pin);
                    tries++;

                    if (Check(Users, username, pin))
                    {
                        successfull = true;
                        Meny(username, Users, accArray, successfull);

                    }
                    else if (tries == 3)
                    {

                        Console.WriteLine("För många försök! Försök igen senare");


                    }
                    else
                    {
                        Console.WriteLine("Tyvärr du skrev fel användare eller pin, tyck enter och försök igen!");
                        Correct = false;
                    }



                }

            }

        }


        static bool Check(string[,] Users, string username, string pin)//method for checking username and pin
        {
            for (int i = 0; i < Users.GetLength(0); i++)
            {
                if (Users[i, 0] == username && Users[i, 1] == pin)
                {
                    return true;
                }


            }
            return false;

        }
        public static void Meny(string username, string[,] Users, decimal[][] accArray, bool successfull)//Method for meny and choice
        {
            do
            {
                try
                {
                    Console.WriteLine("Välkommen!");
                    Console.WriteLine("[1] Se dina konton och saldo");
                    Console.WriteLine("[2] Överföring melland konto");
                    Console.WriteLine("[3] Ta ut pengar");
                    Console.WriteLine("[4] Avsluta");

                    int choice = int.Parse(Console.ReadLine());


                    switch (choice)//Switch for the choices, the choice you make will run that method
                    {
                        case 1:
                            Console.WriteLine("Dina konton och saldo");
                            account(Users, accArray, username);
                           break;

                        case 2:
                            Console.WriteLine("Överföring");
                            transfer(Users, accArray, username);
                            break;

                        case 3:
                            Console.WriteLine("Ta ut pengar");
                            withdraw(Users, accArray, username);
                            break;

                        case 4:
                            Console.WriteLine("Du har loggat ut, tack för att du använder vår tjänst!");
                            successfull = false;
                            Console.ReadKey();

                            break;

                        default:
                            Console.WriteLine("Fel, vänligen välj något av de 4 valen");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Fel inmatnings format");
                }

            } while (successfull == true);
        }
        public static int LoginUser(string[,] Users, string username)//method to check current logged in user
        {
            for (int i = 0; i < Users.GetLength(0); i++)
            {
                if (Users[i, 0] == username)
                {
                    return i;
                }
            }
            return 0;
        }
        public static void account(string[,] Users, decimal[][] accArray, string username)//method to check account on active user
        {
            int Active = LoginUser(Users, username);
            string[] AccArr = new string[4];
            AccArr[0] = "1.Lönekonto";
            AccArr[1] = "2.Sparkonto";
            AccArr[2] = "3.Semesterkonto";
            AccArr[3] = "4.Privatkonto";
            Console.WriteLine("Konton");
            for (int i = 0; i < accArray[Active].Length; i++)
            {
                if (accArray[Active][i] != 0)
                {
                    Console.WriteLine($"{AccArr[i]} {accArray[Active][i]}kr");
                }
            }
            Console.WriteLine("Tryck enter för att komma till meny");
            Console.ReadKey();
            Console.Clear();
        }
        public static void transfer(string[,] Users, decimal[][] accArray, string username)//Method to transfer between accounts
        {
            bool successfull = false;
            int Active = LoginUser(Users, username);
            string[] AccArr = new string[4];
            AccArr[0] = "1.Lönekonto";
            AccArr[1] = "2.Sparkonto";
            AccArr[2] = "3.Semesterkonto";
            AccArr[3] = "4.Privatkonto";
            string[] AccChoice = { "1 - Lönekonto\n", "2 - Sparkonto\n", "3 - Semesterkonto\n", "4 - Privatkonto\n" };
            Console.WriteLine("Konton");
            Console.WriteLine("Vänligen välj konto du vill göra överföring ifrån");
            for (int i = 0; i < accArray[Active].Length; i++)                       //Prints out accounts on active user
            {
                if (accArray[Active][i] != 0)
                {
                    Console.WriteLine($"{AccArr[i]} {accArray[Active][i]}");
                }
            }

            int Choice1 = int.Parse(Console.ReadLine());

            switch (Choice1) //Switch to choose account you wanna transfer from
            {
                case 1:
                    Choice1 = 0;
                    break;
                case 2:
                    Choice1 = 1;
                    break;
                case 3:
                    Choice1 = 2;
                    break;
                case 4:
                    Choice1 = 3;
                    break;
                default:
                    Console.WriteLine("Fel, vänligen välj något av alternativen");
                    break;
            }
            Console.WriteLine("Hur mycket vill du föra över?");
            decimal sum = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Vänligen välj konto du vill föra över till");
            for (int i = 0; i < accArray[Active].Length; i++)
            {
                if (accArray[Active][i] != 0)
                {
                    Console.WriteLine($"{AccArr[i]} {accArray[Active][i]}");
                }
            }
            int Choice2 = int.Parse(Console.ReadLine()); //Second choice to choose account you want to transfer too
            switch (Choice2)
            {
                case 1:
                    Choice2 = 0;
                    break;
                case 2:
                    Choice2 = 1;
                    break;
                case 3:
                    Choice2 = 2;
                    break;
                case 4:
                    Choice2 = 3;
                    break;
                case 5:
                    Choice2 = 4;
                    break;
                default:
                    Console.WriteLine("Fel, vänligen välj ett av alternativen");
                    break;
            }
            decimal balance = accArray[Active][Choice1] - sum;  //for transfering the money to the other account
            decimal balance2 = accArray[Active][Choice2] + sum;           
            accArray[Active][Choice1] = balance;
            accArray[Active][Choice2] = balance2;
            Console.WriteLine($"Ditt saldo är nu {AccArr[Choice2]}: {accArray[Active][Choice2]}");
            Console.WriteLine("Tryck enter för att komma till meny");
            Console.ReadKey();
            Console.Clear();
            Meny(username, Users, accArray, successfull);
        }
        public static void withdraw(string[,] Users, decimal[][] accArray, string username)// Method to withdraw money from account on activ user
        {
            int Active = LoginUser(Users, username);
            string[] AccArr = new string[4];
            AccArr[0] = "1.Lönekonto";
            AccArr[1] = "2.Sparkonto";
            AccArr[2] = "3.Semesterkonto";
            AccArr[3] = "4.Privatkonto";
            string[] AccChoice = { "1 - Lönekonto\n", "2 - Sparkonto\n", "3 - Semesterkonto\n", "4 - Privatkonto\n" };
            Console.WriteLine("Konton");
            Console.WriteLine("Vänligen välj konto du vill göra uttag från");
            for (int i = 0; i < accArray[Active].Length; i++)
            {
                if (accArray[Active][i] != 0)
                {
                    Console.WriteLine($"{AccArr[i]} {accArray[Active][i]}");
                }
            }
                
            int Choice = int.Parse(Console.ReadLine());

            switch (Choice)//switch to choose with account you wanna withdraw from
            {
                case 1: Choice = 0;
                    break;
                case 2: Choice = 1;
                    break;
                case 3: Choice = 2;
                    break;
                case 4: Choice = 3;
                    break;
                default:
                    Console.WriteLine("Fel, vänligen välj något av alternativen");
                    break;
            }
                      
                
            bool successfull = false;
            bool pinCheck = false;
            int pinTries = 0;
            while (successfull == false)
            {
                
                while (pinCheck == false && pinTries != 3)//pin check, must enter the active user pin, will break after 3 tries
                {                  
                    Console.WriteLine("Hur mycket vill du ta ut?: ");
                    decimal sum = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("Vänligen skriv pinkod: ");
                    string pinKod = Console.ReadLine();
                  
                    
                    if (pinKod == Users[Active, 1])
                    {
                        if(sum < accArray[Active][Choice])
                        {
                            successfull = true;
                            decimal balance = accArray[Active][Choice] - sum;
                            accArray[Active][Choice] = balance;
                            Console.WriteLine($"Ditt saldo är nu {accArray[Active][Choice]}");
                            Console.WriteLine("Tryck enter för att komma till meny");
                            Console.ReadKey();
                            Console.Clear();
                            Meny(username, Users, accArray, successfull);
                        }
                        else
                        {
                            Console.WriteLine("Förstor summa, tryck enter och försök igen");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        
                    }
                    else if (pinTries == 3)
                    {
                        Console.WriteLine("Förmånga försök!");
                        Console.ReadKey();
                        Console.Clear();
                        Meny(username, Users, accArray, successfull);
                    }
                    else
                    {
                        Console.WriteLine("Fel försök igen!");
                        pinTries++;
                        pinCheck = false;
                        
                    }

                }

            }
            
            
        }
    } 
}