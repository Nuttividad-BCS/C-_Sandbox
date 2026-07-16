class Teacher : Person, IWorker
{
    private string _Subject;
    private double _Salary;
    private int  _TeacherId;

    public string Subject
    {
        get{
            return _Subject;
        }
        set
        {
            if(value == "")
            {
                Console.WriteLine("Subject is unknown");
                _Subject = "Unknwon";
            }
            else
            {
                _Subject = value;
            }
        }
    }

    public int Teacher_ID
    {
        get
        {
            return _TeacherId;
        }
        set
        {
            if(value < 1 || value > 9999)
            {
                Console.WriteLine("Student ID out of Bounds! exceeded max/min Value");
                _TeacherId = -1;
            }
            else
            {
                _TeacherId = value;
            }
        }
    }

    public double Salary
    {
        get{
            return _Salary;
        }
        set
        {
            if(value < 15000  || value > 50000)
            {
                Console.WriteLine("Invalid Salary Input");
                _Salary = -1;
            }
            else
            {
                _Salary = value;
            }
        }
    }

    public Teacher(string name, int age, int id,string subject, double salary) : base(name, age)
    {
        Teacher_ID = id;
        Subject = subject;
        Salary = salary;
    }

    public void Display(
        string name, 
        int age, 
        int teacher_id, 
        string subject, 
        double salary
        )
    {
        Console.WriteLine($"""
        Teacher Details:
        Name: {name}
        Age: {age}
        ID: {teacher_id}
        Subject: {subject}
        Salary: {salary}
        """);
    }

    public void Teach()
    {
        Console.WriteLine($"Teacher {Name} is teaching");
    }
}