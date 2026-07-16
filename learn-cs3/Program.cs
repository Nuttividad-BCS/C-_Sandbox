using System.Net;
using System.Transactions;

class Program
{
    public static void Main(string[] args)
    {
        bool status = true;
        while(Status(status))
        {
            Console.WriteLine($"""
            1. Add
            2. Subtract
            3. Multiply
            4. Divide
            5. Exit
            """);

            if(int.TryParse(Console.ReadLine(), out int cho))
            {                
                switch (cho)
                {
                    case 1:
                        Calculator.Add();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        status = false;
                        break;
                    default:
                        InvalidInput();
                        break;
                }
            }
            else
            {
                InvalidInput();
            }
        }
    }

    public static bool Status(bool status)
    {
        return status;
    }

    public static void InvalidInput()
    {
        Console.WriteLine($"Invalid! Press Any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }
}

