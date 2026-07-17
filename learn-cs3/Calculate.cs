class Calculator
{
    private static int _Num1;
    private static int _Num2;

    private static string Operation;

    public static double Add()
    {
        try
        {
            (_Num1,  _Num2) = Get2Nums();
            Operation = "+";
            return _Num1 + _Num2;
        } catch(Exception)
        {
            Program.InvalidInput();
            throw;
        }
    }

    public static double Subtract()
    {
        try
        {
            (_Num1, _Num2) = Get2Nums();
            Operation = "-";
            return _Num1 - _Num2;
        }
        catch (Exception)
        {
            Program.InvalidInput();
            throw;
        }
    }

    public static double Multiply()
    {
        try
        {
            (_Num1, _Num2) = Get2Nums();
            Operation = "*";
            return _Num1 * _Num2;
        }
        catch (Exception)
        {
            Program.InvalidInput();
            throw;
        }
    }

    public static double Divide()
    {
        try
        {
            (_Num1, _Num2) = Get2Nums();
            Operation = "/";
            return _Num1 / _Num2;
        }
        catch (DivideByZeroException e)
        {
            Console.WriteLine(e);
            Program.InvalidInput();
            throw;
        }
    }
    
    public static void ShowAnswer(double answer)
    {
        Console.WriteLine($"Answer: {_Num1} {Operation} ({_Num2}) = {answer}");
        Program.WaitUser();
    }

    public static (int num1, int num2) Get2Nums()
    {
        int num1 = 0;
        int num2 = 0;
        try
        {
            Console.WriteLine("Enter Num 1");
            num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Num 2");
            num2 = int.Parse(Console.ReadLine());
        } catch(Exception ex)
        {
            Console.WriteLine($"Error occured: {ex}");
            throw;
        }

        return (num1, num2);
    }

}