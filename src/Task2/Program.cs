using System;
using System.Collections.Generic;

/// <summary>
/// Базовый класс для студента
/// </summary>
class Student
{
    public string Name { get; set; } = null!;
    public int Age { get; set; }
}

/// <summary>
/// Класс для старосты
/// </summary>
class Monitor : Student
{
    public string Responsibilities { get; set; } = null!;
}

/// <summary>
///  Класс для группы студентов
/// </summary>
class StudentGroup
{
    public string GroupName { get; set; } = null!;
    public Monitor GroupMonitor { get; set; } = null!;
    public List<Student> Students { get; set; } = null!;

    public StudentGroup(string groupName)
    {
        GroupName = groupName;
        Students = new List<Student>();
    }
}

/// <summary>
///  Класс для режима только чтения данных
/// </summary>
class ReadOnlyMode
{
    public void DisplayStudentInfo(Student student)
    {
        Console.WriteLine("Student Name: " + student.Name);
        Console.WriteLine("Student Age: " + student.Age);
    }

    public void DisplayGroupInfo(StudentGroup group)
    {
        Console.WriteLine("Group Name: " + group.GroupName);
        Console.WriteLine("Group Monitor: " + group.GroupMonitor.Name);
        Console.WriteLine("Group Monitor Responsibilities: " + group.GroupMonitor.Responsibilities);
        Console.WriteLine("Total Students: " + group.Students.Count);
    }
}

/// <summary>
///  Класс для режима редактирования данных
/// </summary>
class EditMode
{
    public void EditStudentInfo(Student student)
    {
        Console.Write("Enter student name: ");
        student.Name = Console.ReadLine();

        Console.Write("Enter student age: ");
        student.Age = Convert.ToInt32(Console.ReadLine());
    }

    public void EditGroupInfo(StudentGroup group)
    {
        Console.Write("Enter group name: ");
        group.GroupName = Console.ReadLine();

        Console.Write("Enter group monitor name: ");
        group.GroupMonitor.Name = Console.ReadLine();

        Console.Write("Enter group monitor responsibilities: ");
        group.GroupMonitor.Responsibilities = Console.ReadLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Student student1 = new Student { Name = "John", Age = 20 };
        Student student2 = new Student { Name = "Emma", Age = 21 };
        Student student3 = new Student { Name = "Tom", Age = 19 };

        Monitor monitor = new Monitor { Name = "Mike", Age = 22, Responsibilities = "Managing group activities" };

        StudentGroup group = new StudentGroup("Group A");
        group.GroupMonitor = monitor;
        group.Students.Add(student1);
        group.Students.Add(student2);
        group.Students.Add(student3);

        ReadOnlyMode readOnlyMode = new ReadOnlyMode();
        EditMode editMode = new EditMode();
        
        // Выводим информацию о студенте в режиме только чтения данных
        readOnlyMode.DisplayStudentInfo(student1);

        // Выводим информацию о группе в режиме только чтения данных
        readOnlyMode.DisplayGroupInfo(group);

        // Редактируем информацию о студенте в режиме редактирования данных
        editMode.EditStudentInfo(student1);

        // Редактируем информацию о группе в режиме редактирования данных
        editMode.EditGroupInfo(group);

        // Выводим измененную информацию о студенте в режиме только чтения данных
        readOnlyMode.DisplayStudentInfo(student1);

        // Выводим измененную информацию о группе в режиме только чтения данных
        readOnlyMode.DisplayGroupInfo(group);
    }
}