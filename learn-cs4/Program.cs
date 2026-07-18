using System.Net;

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
            4 View Students
            5 Exit
            """);
            Console.WriteLine("Enter Input");

            if(int.TryParse(Console.ReadLine(),out int cho))
            {
                try
                {
                    switch (cho)
                    {
                        case 1:
                            Student s = Student.InputDetails();
                            Student.AddStudent(s);
                            break;
                        case 2:
                            Student.SaveFile();
                            break;
                        case 3:
                            Student.LoadFile();
                            break;
                        case 4:
                            Student.ShowStudents();
                            break;
                        case 5:
                            status = false;
                            break;
                    }
                } 
                catch (Exception e)
                {
                    Console.WriteLine($"Returning to Main menu... {e}");
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
        Console.ReadKey();
        Console.Clear();
    }

    public static int IntInput(string? msg)
    {
        int input = 0;
        bool status = true;
        do
        {
            if (msg != null)
            {
                Console.WriteLine($"Please Enter {msg}");
            }

            if(int.TryParse(Console.ReadLine(), out int inp))
            {
                input = inp;
                status = false;
            }
            else
            {
                InvalidInput();
            }
        
        } while(status);

        return input;
    }

    public static double DoubleInput(string? msg)
    {
        double input = 0;
        bool status = true;
        do
        {
            if (msg != null)
            {
                Console.WriteLine($"Please Enter {msg}");
            }

            if(double.TryParse(Console.ReadLine(), out double inp))
            {
                input = inp;
                status = false;
            }
            else
            {
                InvalidInput();
            }
        
        } while(status);

        return input;
    }
    
    public static List<double> GradesInput(string? msg)
    {
        List<double> grades = new List<double>();
        while(grades.Count < 5){
            try
            {
                double g = DoubleInput("Input Grade");
                grades.Add(g);
            } 
            catch(Exception e)
            {
                Console.WriteLine($"Exception occured! {e}");
            }
        }
        return grades;
    }

    public static string StringInput(string? msg)
    {
        string input ="";
        bool status = true;
        do
        {
            
            if (msg != null)
            {
                Console.WriteLine($"Please Enter {msg}");
            }

            string inp = Console.ReadLine();
            if(inp != "" && inp != null)
            {
                input = inp;
                status = false;
            }
            else
            {
                InvalidInput();
            }
        
        } while(status);

        return input;
    }
}