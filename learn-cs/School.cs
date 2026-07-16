using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

class School
{
    List<Person> l_person = new List<Person>{};

    static List<Student> l_student = new List<Student>{};
    static List<Teacher> l_teacher = new List<Teacher>{};

    public School()
    {
        
    }

    public Person? InputInfo(string ptype)
    {
        var (name, age) = GetDetails();

        switch (ptype){
            case "T":
                var (subject, salary, t_id) = TeacherInfo();
                Teacher t = new Teacher(name, age, t_id, subject, salary);
                t.Display(name, age, t_id, subject, salary);
                
                return t;

            case "S":
                var (s_id, course, grades, status) = StudentInfo();
                Student s = new Student(name, age, s_id, course, grades, status);
                s.Display(name, age, s_id,course,grades, null,status);

                return s;
        
            default:
                Console.WriteLine("Invalid Operation");
                return null;
        }
    }


    public void Add()
    {
        string ptype = GetPersonType();
        Person person = InputInfo(ptype);

        if(person is Teacher teacher)
        {
            l_teacher.Add(teacher);
            l_person.Add(teacher);
        } else if(person is Student student)
        {
            l_student.Add(student);
            l_person.Add(student);
        }
        else
        {
            Console.WriteLine("Invalid Operation");   
        }        

    }

    public void ShowPeople()
    {
        foreach(Person people in l_person)
        {
            Console.WriteLine($"{people}");
        }
    }

    public static Person? Search()
    {
        string ptype = GetPersonType();

        switch (ptype){
            case "T":
                Console.WriteLine("Please Enter the ID of the Teacher");
                int t_id = int.Parse(Console.ReadLine() ?? "");

                Teacher t_result = l_teacher.FirstOrDefault(ID => ID.Teacher_ID == t_id);
                
                if(t_result == null)
                {
                    Console.WriteLine("ID not found!");
                }
                else
                {
                    t_result.Display(
                    t_result.Name,
                    t_result.Age,
                    t_result.Teacher_ID,
                    t_result.Subject,
                    t_result.Salary
                    );
                }

                return t_result;


            case "S":
                Console.WriteLine("Please Enter the ID of the Student");
                int s_id = int.Parse(Console.ReadLine() ?? "");

                Student s_result = l_student.FirstOrDefault(ID => ID.Student_ID == s_id);

                if (s_result == null)
                {
                    Console.WriteLine("ID not found!");
                }
                else
                {
                    s_result.Display(
                    s_result.Name,
                    s_result.Age,
                    s_result.Student_ID,
                    s_result.Course,
                    s_result.Grades,
                    s_result.HasPassed,
                    s_result.Status
                    );
                }

                return s_result;

            default:
                Console.WriteLine("Invalid Operation");
                return null;

        }

    } 

    public void Remove()
    {
        Person Selected = Search();

        if(Selected is Teacher teacher)
        {
            l_teacher.RemoveAll(obj => obj.Teacher_ID == teacher.Teacher_ID );
            Console.WriteLine("Teacher has been removed");
        } else if(Selected is Student student)
        {
            l_student.RemoveAll(obj => obj.Student_ID == student.Student_ID );
            Console.WriteLine("Student has been removed");
        }
        else
        {
            Console.WriteLine("Invalid Person/Person Not Found");
        }

    }

    public void Update()
    {
        Person Selected = Search();

        Console.WriteLine("Input the following data to be updated");       

        if(Selected is Teacher teacher)
        {
            Person updated_t = InputInfo("T"); 

            if(updated_t is Teacher u_t)
            {
                teacher.Name = u_t.Name;
                teacher.Age = u_t.Age;
                teacher.Subject = u_t.Subject;
                teacher.Salary = u_t.Salary;
            }

        } else if(Selected is Student student)
        {
            Person updated_s = InputInfo("S");

            if(updated_s is Student u_s)
            {
                student.Name = u_s.Name;
                student.Course = u_s.Course;
                student.Age = u_s.Age;
                student.Grades = u_s.Grades;
                student.Status = u_s.Status;
            }
        }
        else
        {
            Console.WriteLine("Invalid Person/Person Not Found");
        }
    }

    public void Simulate()
    {
        if(l_person == null || l_person.Count == 0)
        {
            Console.WriteLine("No Students in Database!");
        }
        else
        {
            foreach(Student s in l_student)
            {

                Thread t = new Thread(s.Study);

                t.Start();
                
            }
        }
    }

    public (string name, int age) GetDetails()
    {
        Console.WriteLine("Please Enter The Name");
        string name = Console.ReadLine() ?? "";
        Console.WriteLine("Please Enter The Age");
        int age = int.Parse(Console.ReadLine() ?? "");

        return (name, age);
    }

    public static string GetPersonType()
    {
        Console.WriteLine("Teacher Or Student? [T/S]");
        string resp = Console.ReadLine() ?? "";

        return resp;
    }
    
    public (int id, string course, double[] grades, StudentStatus status) StudentInfo() {
        //Student ID 
        Console.WriteLine("Enter the Student's ID");
        int id = int.Parse(Console.ReadLine() ?? "");

        //Student Course
        Console.WriteLine("Enter the Student's Course");
        string course = Console.ReadLine() ?? "";

        //Student Grades 5 Max
        double[] d = new double[5];
        Console.WriteLine("Please Enter the student's Grades 1 by 1");
            for(int i = 0; i < 5; i++)
            {
                d[i] = double.Parse(Console.ReadLine() ?? "");
            }
        
        //Student Status
            Console.WriteLine($"""
            Enter the Student's status,
            1.  Freshman,
            2.  Sophomore,
            3.  Junior,
            4.  Senior,
            5.  Graduated
            """);
        StudentStatus select = (StudentStatus)int.Parse(Console.ReadLine() ?? "");

        return(id, course, d, select);
    }

    public (string subject, double salary, int id) TeacherInfo()
    {
        Console.WriteLine("Please Enter the teacher's Subject");
        string subject = Console.ReadLine() ?? "";

        Console.WriteLine("Please Enter the teacher's Salary");
        string salary = Console.ReadLine() ?? "";

        Console.WriteLine("Please Enter the Teacher's ID");
        int id = int.Parse(Console.ReadLine() ?? "");

        return (subject, double.Parse(salary), id);
    }
}