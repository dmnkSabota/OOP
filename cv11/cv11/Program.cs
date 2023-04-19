namespace cv11
{
    using cv11.EFCore;
    using System;
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize the sample data
            DataInitializer.InitializeData();

            // Display subjects with enrollment count
            Console.WriteLine("Subjects with enrollment count:");
            DataQueries.DisplaySubjectsWithEnrollmentCount();
            Console.WriteLine();

            // Get students for a subject
            var studentsInMath = DataQueries.StudentsSubjects("MATH");
            Console.WriteLine("Students in Mathematics:");
            foreach (var student in studentsInMath)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}");
            }
            Console.WriteLine();

            // Get subjects for a student
            var subjectsForStudent1 = DataQueries.SubjectsStudent(1);
            Console.WriteLine("Subjects for student with ID 1:");
            foreach (var subject in subjectsForStudent1)
            {
                Console.WriteLine($"{subject.SubjectName}");
            }
            Console.WriteLine();

            // Display subjects with average grades
            Console.WriteLine("Subjects with average grades:");
            DataQueries.DisplaySubjectsWithAverageGrades();
        }
    }
}