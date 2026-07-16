class Person
{
    private string _Name;

    private int _Age;

    public string Name {
        get
        {
            return _Name;
        }
        set
        {
            if(value == "")
            {
                Console.WriteLine("Student Unknown");
                _Name = "Unknown Student";
            }
            else
            {
                _Name = value;
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
            if(value < 3 || value > 40)
            {
                Console.WriteLine("Invalid Age for student (Too Young/Old)");
                _Age = -1;
            } else
            {
                _Age = value;
            }
        }
    }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public virtual void Display()
    {
        Console.WriteLine($"""
        Person Details:
        Name: {_Name}
        Age: {_Age}
        """);
    }
    
}