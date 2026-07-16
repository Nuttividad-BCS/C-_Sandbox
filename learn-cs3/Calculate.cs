class Calculator
{
    private static int _Num1;
    private static int _Num2;

    public static void Add()
    {
        (_Num1 ,  _Num2) = Get2Nums();

        try
        {
            Console.WriteLine($"Answer: {_Num1 + _Num2}");
            Console.ReadLine();
        } catch(Exception e)
        {
            Console.WriteLine($"Error Occured when adding {e}");
            Console.ReadLine();
        }
        Console.Clear();
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
        }

        return (num1, num2);
    }

}