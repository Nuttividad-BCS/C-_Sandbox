using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using Microsoft.VisualBasic;

enum StudentStatus
{
    StudentStatus,
    Freshman,
    Sophomore,
    Junior,
    Senior,
    Graduated
}

class Student : Person, IStudy
{

    private int _StudentId;

    private string _Course;

    private double[] _Grades = new double[5];

    public StudentStatus Status;

    public int Student_ID
    {
        get
        {
            return _StudentId;
        }
        set
        {
            if(value < 1 || value > 9999)
            {
                Console.WriteLine("Student ID out of Bounds! exceeded max/min Value");
                _StudentId = -1;
            }
            else
            {
                _StudentId = value;
            }
        }
    }
    
    public string Course
    {
        get
        { 
            return _Course;
        }
        set
        {
            if(value == "")
            {
                Console.WriteLine("Course Unkown");
                _Course = "Unknown Course";
            }
            else
            {
                _Course = value;
            }
        }

    }

    public double[] Grades
    {
        get
        {
            return _Grades;
        }
        set
        {
            if (value.Length == 0)
            {
                Console.WriteLine("Student has no grades!");
                _Grades = [-1];
            } else if (value.Length < 5)
            {
                Console.WriteLine("Student Has Incomplete Grades!");
                _Grades = [-1];
            }
            else
            {
                _Grades = value;
            }
        }
    }

    public bool HasPassed
    {
        get
        {
            return AvgGrade() >= 75 ? true : false;
        }
    }

    public Student(
        string name, 
        int age, 
        int s_id, 
        string course, 
        double[] grades,
        StudentStatus status
        ) : base(name, age)
    {
       Student_ID = s_id;
       Course = course;
       Grades = grades;
       Status = status;
    }

    public bool gradesIsEmpty(){
        return _Grades == null || _Grades.Length == 0 || (_Grades.Length == 1 && _Grades[0] == -1);
    }

    public void Display(
        string name,
        int age,
        int student_id,
        string course,
        double[] grades,
        bool? haspassed,
        StudentStatus status
    )
    {
        string result = string.Join(",",grades);

        Console.WriteLine($"""
        Name: {name}
        Age: {age}
        Student ID: {student_id}
        Course: {course}
        Grades: {result}
        Passed: {haspassed}
        Status: {status}
        """);
    }

    public double AvgGrade()
    {
        double avg = 0;

        if (gradesIsEmpty())
        {
            Console.WriteLine("Grades are empty!");
            avg = 0;
        }
        else
        {
            foreach(double i in Grades)
            {
                avg += i;
            }

            avg /= Grades.Length;

            Console.WriteLine($"Average of Grades {avg}");
        }

        return avg;
    }

    public void HighGrade()
    {
        double high = Grades[0];
        if (gradesIsEmpty())
        {
             Console.WriteLine("Grades are empty!");
        }
        else
        {
            foreach(double i in Grades)
            {
                if(high < i)
                {
                    high = i;
                }
            }
            Console.WriteLine($"Highest of Grades {high}");
        }
    }

    public void LowGrade()
    {
        double low = Grades[0];
        if (gradesIsEmpty())
        {
            Console.WriteLine("Grades are empty!");
        }
        else
        {
            foreach(double i in Grades)
            {
                if(low > i)
                {
                    low = i;
                }
            }
            Console.WriteLine($"Lowest of Grades {low}");
        }
    }

    public void Study()
    {
        Console.WriteLine($"Student: {Name} is studying");
        Thread.Sleep(500);
    }

    
}