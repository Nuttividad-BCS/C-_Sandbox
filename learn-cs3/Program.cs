using System.Net;
using System.Transactions;

class Program
{
    public static void Main(string[] args)
    {
        bool status = true;
        
        while(Status(status))
        {
            try{
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
                            Calculator.ShowAnswer(
                                Calculator.Add()
                            );
                            break;
                        case 2:
                            Calculator.ShowAnswer(
                                Calculator.Subtract()
                            );
                            break;
                        case 3:
                            Calculator.ShowAnswer(
                                Calculator.Multiply()                                
                            );
                            break;
                        case 4:
                            Calculator.ShowAnswer(
                                Calculator.Divide()                                
                            );
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
            catch (Exception)
            {
                Console.WriteLine("Returning to Main menu...");
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
        WaitUser();
    }

    public static void WaitUser()
    {
        Console.ReadKey();
        Console.Clear();
    }
}

