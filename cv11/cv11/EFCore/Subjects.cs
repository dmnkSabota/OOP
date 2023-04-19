namespace cv11.EFCore
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Subject
    {
        [Key]
        public string Abbreviation { get; set; }
        public string SubjectName { get; set; }
        public ICollection<StudentSubject> StudentSubjects { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }

}
