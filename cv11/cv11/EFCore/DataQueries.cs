namespace cv11.EFCore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class DataQueries
    {
        // Displays a list of subjects with the number of students enrolled in each subject
        public static void DisplaySubjectsWithEnrollmentCount()
        {
            using (var context = new EduContext())
            {
                var subjects = context.Subjects
                    .Select(s => new
                    {
                        s.SubjectName,
                        EnrollmentCount = s.StudentSubjects.Count
                    })
                    .OrderByDescending(x => x.EnrollmentCount);

                foreach (var subject in subjects)
                {
                    Console.WriteLine($"{subject.SubjectName}: {subject.EnrollmentCount} students");
                }
            }
        }

        // Retrieves a list of students enrolled in a given subject
        public static IEnumerable<Student> StudentsSubjects(string subjectId)
        {
            using (var context = new EduContext())
            {
                return context.StudentSubjects
                    .Where(ss => ss.Abbreviation == subjectId)
                    .Select(ss => ss.Student)
                    .ToList();
            }
        }

        // Retrieves a list of subjects taken by a given student
        public static IEnumerable<Subject> SubjectsStudent(int studentId)
        {
            using (var context = new EduContext())
            {
                return context.StudentSubjects
                    .Where(ss => ss.StudentId == studentId)
                    .Select(ss => ss.Subject)
                    .ToList();
            }
        }

        // Displays a list of subjects with the average grades of all students enrolled in each subject
        public static void DisplaySubjectsWithAverageGrades()
        {
            using (var context = new EduContext())
            {
                var subjects = context.Subjects
                    .Select(s => new
                    {
                        s.SubjectName,
                        AverageGrade = s.StudentSubjects
                            .SelectMany(ss => context.Grades
                                .Where(g => g.StudentId == ss.StudentId && g.Abbreviation == ss.Abbreviation))
                            .Average(g => (decimal?)g.NumericalGrade)
                    });

                foreach (var subject in subjects)
                {
                    Console.WriteLine($"{subject.SubjectName}: Average grade {(subject.AverageGrade.HasValue ? subject.AverageGrade.Value.ToString("F2") : "N/A")}");
                }
            }
        }
    }
}
