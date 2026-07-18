using System.Text.Json;
using System.IO;
using System.Security.Cryptography;

class Student
{
    private static List<Student> students = new List<Student>();

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
                printException(e);
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
                    printException(e);
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
                printException(e);
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
                    printException(e);
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

    public static Student InputDetails()
    {
        string name;
        int age=0;
        string subject;
        List<double> grades = new List<double>();

        try
        {
            name = Program.StringInput("Name");

            age = Program.IntInput("Age");

            subject = Program.StringInput("Subject");

            grades = Program.GradesInput(null);

            return new Student 
                (   name, 
                    age, 
                    subject, 
                    grades
                );
        }
        catch(Exception)
        {
            Program.InvalidInput();
            throw;
        }
    }

    //Student Adder
    public static void AddStudent(Student s)
    {
        try
        {
            Student student = new Student(s.Name, s.Age, s.Subject, s.Grades);
            students.Add(student);
        }
        catch (Exception e)
        {
            printException(e);
        }
    }

    public static void SaveFile()
    {
        try
        {
            var options = new JsonSerializerOptions {
                WriteIndented = true
            };

            string jsonstring = JsonSerializer.Serialize(students, options);

            File.WriteAllText("students.json",jsonstring);
       } 
        catch(Exception e)
        {
            printException(e);
        }
    }

    public static void LoadFile()
    {
            using FileStream filePath = File.OpenRead("students.json");

            if (!File.Exists("students.json"))
            {
                Console.WriteLine("Save file does not exist!");
                return;
            }

            List<Student> deserialized = JsonSerializer.Deserialize<List<Student>>(filePath) ?? [];
        try
        {
            try
            {
                BackupCurrent();
            } 
            catch(Exception e)
            {
                printException(e);
                throw;
            } 

            students.Clear();
            foreach(Student s in deserialized)
            {
                AddStudent(s);
            }   
        
        } 
        catch (Exception e)
        {
            printException(e);
            throw;
        }
    }

    public static void ShowStudents()
    {
        if(isStudentsEmpty())
        {
            Console.WriteLine("No save data loaded/No students in file");
        }

        else
        {
            students.ForEach(s => Console.WriteLine($"""
            Name: {s._Name}
            Age: {s._Age}
            Subject: {s._Subject}
            Grades: {string.Join(", ",s._Grades)}
            """));
        }

    }

    public static void BackupCurrent()
    {

        File.Copy("students.json","students_backup.json", overwrite: true);
    }
    //Empty checker
    public static bool isStudentsEmpty()
    {
        return students.Count == 0 || students == null ? true : false;
    }

    public static void printException(Exception e)
    {
        Console.WriteLine($"Exception Occured: {e}");
    }
}