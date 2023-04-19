
using System.ComponentModel.DataAnnotations;

namespace cv11.EFCore
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<StudentSubject> StudentSubjects { get; set; }
        public ICollection<Grade> Grades { get; set; } 
    }
}


