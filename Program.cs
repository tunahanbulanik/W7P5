using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public int ClassId { get; set; }
}

class Class
{
    public int ClassId { get; set; }
    public string ClassName { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        // Öğrencileri tanımlıyoruz
        List<Student> students = new List<Student>
        {
            new Student { StudentId = 1, StudentName = "Ayşe", ClassId = 2 },
            new Student { StudentId = 2, StudentName = "Mehmet", ClassId = 3 },
            new Student { StudentId = 3, StudentName = "Fatma", ClassId = 2 },
            new Student { StudentId = 4, StudentName = "Ahmet", ClassId = 3 }
        };

        // Sınıfları tanımlıyoruz
        List<Class> classes = new List<Class>
        {
            new Class { ClassId = 2, ClassName = "Matematik" },
            new Class { ClassId = 3, ClassName = "Türkçe" }
        };

        // Group Join işlemi ile her sınıfa ait öğrencileri grupluyoruz
        var classStudents = from c in classes
                            join s in students on c.ClassId equals s.ClassId into studentGroup
                            select new
                            {
                                ClassName = c.ClassName,
                                Students = studentGroup
                            };

        // Sonuçları ekrana yazdırıyoruz
        foreach (var item in classStudents)
        {
            Console.WriteLine($"Sınıf: {item.ClassName}");
            foreach (var student in item.Students)
            {
                Console.WriteLine($" - Öğrenci: {student.StudentName}");
            }
        }
    }
}
