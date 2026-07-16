using System.Net.Http.Headers;

class Student
{
    static List<Student> S_L = [
            new Student("John", 18, "CS", 80),
            new Student("Alice", 19, "IT", 88),
            new Student("Sophia", 20, "CS", 92),
            new Student("Michael", 21, "Data Science", 74),
            new Student("Emma", 19, "Cybersecurity", 85),
            new Student("Daniel", 22, "IT", 68),
            new Student("Olivia", 18, "CS", 95),
            new Student("James", 20, "Software Engineering", 79),
            new Student("Isabella", 21, "Data Science", 91),
            new Student("Ethan", 19, "Cybersecurity", 62),
            new Student("Ethan", 22, "Data Science", 85)
        ];

    private string _Name;
    private int _Age;

    private string _Course;
    private double _Grade;

    public Student(string name, int age, string course, double grade){
        _Name = name;
        _Age = age;
        _Course = course;
        _Grade = grade;
    }

    public static void ShowAll(List<Student> Data)
    {
        Data.ForEach(s => Console.WriteLine($"""

        Name: {s._Name}
        Age: {s._Age}
        Course: {s._Course}
        Grade: {s._Grade}

        """));
    }

    public static List<Student> ShowAbove74()
    {
        return S_L.Where(s => s._Grade >= 75).ToList();
    }

    public static List<Student> ShowCourseStudent(string course)
    {
        return S_L.Where(s => s._Course == course).ToList();
    }

    public static List<Student> HighestToLow()
    {
        return S_L.OrderByDescending(s => s._Grade).ToList();
    }

    public static Student Youngest()
    {
        return S_L.MinBy(s => s._Age);
    }

    public static Student Oldest()
    {
        return S_L.MaxBy(s => s._Age);
    }

    public static int NumOfPassed()
    {
        return S_L.Count(s => s._Grade >= 75);
    }

    public static double GetAvg()
    {
        return S_L.Average(s => s._Grade);
    }

    public static List<Student> SearchStudent(string name)
    {
        return S_L.Where(s => s._Name == name).ToList();
    }

    public static void ShowNames()
    {
        List<string> names = S_L.Select(s => s._Name).ToList();
        Console.WriteLine("Student Names: ");
        names.ForEach(s => Console.WriteLine($"""
            {s}
            """
        ));
    }
}