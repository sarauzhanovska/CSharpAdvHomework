
using HomeworkTask.Entities.Interfaces;
using HomeworkTask.Entities.Models.BaseModel;

namespace HomeworkTask.Entities.Models
{
    public class Teacher : User, ITeacher
    {
        List<string> Subjects { get; set; }
        public Teacher(int id, string name, string username, List<string> subjects) : base(id, name, username)
        {
            Subjects = subjects;
        }
        public override string PrintUser()
        {

            return $"Id: {Id}, Name: {Name}, Username: {Username}, Number of subjects: {Subjects.Count}";
        }
        public void PrintSubjects()
        {
            string testingSubjects = Subjects.Count != 0 ? string.Join(", ", Subjects) : "N/A";
            Console.WriteLine($"Subjects: {testingSubjects}");
        }

    }
}
