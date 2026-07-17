class Program
{
    public static void Main(string[] args)
    {
        bool status = true;

        while (status)
        {
            Console.WriteLine($"""
            1 Add Student
            2 Save
            3 Load
            4 Exit
            """);
            Console.WriteLine("Enter Input");

            if(int.TryParse(Console.ReadLine(),out int cho))
            {
                try
                {
                    switch (cho)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            status = false;
                            break;
                    }
                } 
                catch (Exception)
                {
                    
                }
            }
            else
            {
                InvalidInput();
            }
        }
    }

    public bool Status(bool status)
    {
        return status;
    }

    public static void InvalidInput()
    {
        Console.WriteLine("Input is invalid!");
        Console.ReadLine();
        Console.Clear();
    }
}