using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    public class Program
    {
        Random rng;
        static bool cont = false;
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };

        static void Main(string[] args)
        {
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            var check = Console.ReadLine().ToLower();
            if (check == "yes")
                cont = true;
            else if (check == "no")
                cont = false;
            else
            {
                while (check != "yes" || check != "no")
                {
                    Console.WriteLine("Please write yes or no");
                    check = Console.ReadLine().ToLower();
                    if (check == "yes")
                    {
                        cont = true;
                        break;
                    }
                    else if (check == "no")
                    {
                        cont = false;
                        break;
                    }
                }
            }

            if (cont)
            {
                Console.WriteLine();

                Console.Write("We are going to need your information first! What is your name? ");
                string userName = Console.ReadLine();

                Console.WriteLine();

                Console.Write("What is your age? ");
                int userAge = Int32.Parse(Console.ReadLine());

                Console.WriteLine();

                Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
                string seeList = Console.ReadLine();

                if (seeList.ToLower() == "sure")
                {
                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }

                    Console.WriteLine();
                    Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                    string addToList = Console.ReadLine();
                    Console.WriteLine();

                    while (addToList.ToLower() == "yes")
                    {
                        Console.Write("What would you like to add? ");
                        string userAddition = Console.ReadLine();

                        activities.Add(userAddition);

                        foreach (string activity in activities)
                        {
                            Console.Write($"{activity} ");
                            Thread.Sleep(250);
                        }

                        Console.WriteLine();
                        Console.WriteLine("Would you like to add more? yes/no: ");
                        addToList = Console.ReadLine();
                    }
                }

                while (cont)
                {
                    Console.Write("Connecting to the database");

                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(500);
                    }

                    Console.WriteLine();

                    Console.Write("Choosing your random activity");

                    for (int i = 0; i < 9; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(500);
                    }

                    Console.WriteLine();

                    var rng = new Random();
                    int randomNumber = rng.Next(activities.Count);

                    string randomActivity = activities[randomNumber];

                    if (userAge > 21 && randomActivity == "Wine Tasting")
                    {
                        Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                        Console.WriteLine("Pick something else!");

                        activities.Remove(randomActivity);

                        randomNumber = rng.Next(activities.Count);

                        randomActivity = activities[randomNumber];
                    }

                    Console.Write($"Ah got it! {randomActivity}, your random activity is: {userName}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                    Console.WriteLine();

                    check = Console.ReadLine().ToLower();
                    if (check == "redo")
                        cont = true;
                    else if (check == "keep")
                        cont = false;
                    else
                    {
                        while (check != "redo" || check != "keep")
                        {
                            Console.WriteLine("Please write keep or redo");
                            check = Console.ReadLine().ToLower();
                            if (check == "redo")
                            {
                                cont = true;
                                break;
                            }
                            else if (check == "keep")
                            {
                                cont = false;
                                break;
                            }
                        }
                    }

                }
            }
        }
    }
}

