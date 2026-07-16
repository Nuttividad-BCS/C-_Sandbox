using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Net.Http;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
class Program
{

    public static void Main(string[] args)
    {
        School s = new School();

        bool running = true;

        while (running)
        {
            Console.Clear();   

            Console.WriteLine("""
            ==================================
                SCHOOL MANAGEMENT SYSTEM
            ==================================

            1. Add Person
            2. Display All People
            3. Search Person
            4. Update Person
            5. Remove Person
            6. Simulate Activities
            7. Exit

            Choice:
            """);

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                choice = -1; // Default fallback if the input was empty or invalid text
            }

            switch (choice)
            {
                case 1:
                    s.Add();
                    break;

                case 2:
                    s.ShowPeople();
                    break;

                case 3:
                    School.Search();
                    break;

                case 4:
                    s.Update();
                    break;
                case 5:
                    s.Remove();
                    break;

                case 6:
                    s.Simulate();
                    break;

                case 7:
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid Operation");
                    break;
            }

            if (running)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }


    }

    public bool isDone()
    {
        return false;
    }

}   

