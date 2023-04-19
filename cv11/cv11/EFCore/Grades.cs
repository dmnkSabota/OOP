using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace cv11.EFCore
{
    public class Grade
    {
        [Key, Column(Order = 0)]
        public int StudentId { get; set; }

        [Key, Column(Order = 1)]
        public string Abbreviation { get; set; }

        public DateTime GradingDate { get; set; }

        public int NumericalGrade { get; set; }

        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; }

        [ForeignKey(nameof(Abbreviation))]
        public Subject Subject { get; set; }
    }



}
