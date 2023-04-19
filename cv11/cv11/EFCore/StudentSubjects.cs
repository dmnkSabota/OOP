using System;
using System.ComponentModel.DataAnnotations;

namespace cv11.EFCore
{
    public class StudentSubject
    {
        [Key]
        public int StudentId { get; set; }

        [Key]
        public string Abbreviation { get; set; }

        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}

