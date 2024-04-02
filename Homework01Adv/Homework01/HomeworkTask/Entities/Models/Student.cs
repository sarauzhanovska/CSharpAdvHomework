

using HomeworkTask.Entities.Interfaces;
using HomeworkTask.Entities.Models.BaseModel;

namespace HomeworkTask.Entities.Models
{
    public class Student : User, IStudent
    {
        List<int> Grades { get; set; }


        public Student(int id, string name, string username, List<int> grades) : base(id, name, username)
        {
            Grades = grades;
        }

        public override string PrintUser()
        {

            double average = Grades.Average();
            return $"Id: {Id}, Name: {Name}, Username: {Username}, Average Grade: {average}";
        }

        public void PrintGrades()
        {
            string testingGrades = Grades.Count != 0 ? string.Join(", ", Grades) : "N/A";

            Console.WriteLine($"Grades: {testingGrades}");
        }

    }
}
