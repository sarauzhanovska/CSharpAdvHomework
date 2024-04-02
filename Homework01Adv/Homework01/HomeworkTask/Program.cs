

using HomeworkTask.Entities.Models;

Teacher teacher1 = new Teacher(11, "Bob", "bobsky123", new List<string> { "C#Basic", "C#Advanced", "SQL" });
Teacher teacher2 = new Teacher(21, "Mike", "mikesky123", new List<string> { "JavascriptBasic", "JavascriptAdvanced", "Css" });

Student student1 = new Student(01, "Radica", "shvigir12",new List<int> { 4, 5, 5});
Student student2 = new Student(02, "Sara", "uzhanovska12",new List<int> { 5, 4, 3});


Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine(teacher1.PrintUser());
teacher1.PrintSubjects();
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine(teacher2.PrintUser());
teacher2.PrintSubjects();
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine(student1.PrintUser());
student1.PrintGrades();
Console.ResetColor();

Console.ForegroundColor= ConsoleColor.Green;
Console.WriteLine(student2.PrintUser());
student2.PrintGrades();
Console.ResetColor();