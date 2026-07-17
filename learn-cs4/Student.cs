class Student
{
    private string _Name;
    private int _Age;
    private string _Subject;
    private List<double> _Grades;


    public string Name
    {
        get
        {
            return _Name;
        }
        set
        {
            try
            {
                _Name = value;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error Occured: {e}");
            }
        }
    }

    public int Age
    {
        get
        {
            return _Age;
        }
        set
        {
            if(value < 3 || value >= 31)
            {
                Console.WriteLine("You are too old/young");
            }
            else
            {
                try
                {
                    _Age = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error Occured: {e}");
                }
            }
           
        }
    }

    public string Subject
    {
        get
        {
            return _Subject;
        }
        set
        {
            try
            {
                _Subject = value;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error Occured: {e}");
            }
        }
    }

    public List<double> Grades
    {
        get
        {
            return _Grades;
        }
        set
        {
            if(value.Count() < 5)
            {
                Console.WriteLine("Grades Incomplete!");
            }
            else
            {
                try
                {
                    _Grades = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error Occurred: {e}");
                }
            }
        }
    }

    public Student(
        string name, 
        int age, 
        string subject, 
        List<double> grades
        )
    {
        Name = name;
        Age = age;
        Subject = subject;
        Grades = grades;
    }

    public void AddStudent()
    {
        
    }
}