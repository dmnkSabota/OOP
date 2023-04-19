namespace cv11.EFCore
{
    using System;
    using System.Linq;

    // A static class used to initialize sample data in the database
    public static class DataInitializer
    {
        public static void InitializeData()
        {
            // Create a new EduContext instance
            using (var context = new EduContext())
            {
                // Check if the database has already been initialized
                if (context.Subjects.Any())
                {
                    return;
                }
                // Add sample subjects
                AddSubject(context, "MATH", "Mathematics");
                AddSubject(context, "ENG", "English");
                AddSubject(context, "PHY", "Physics");

                // Add sample students
                int student1Id = AddStudent(context, "John", "Doe", new DateTime(2000, 5, 22));
                int student2Id = AddStudent(context, "Jane", "Doe", new DateTime(2001, 11, 30));

                // Add sample student subjects
                AddStudentSubject(context, student1Id, "MATH");
                AddStudentSubject(context, student1Id, "ENG");
                AddStudentSubject(context, student2Id, "ENG");
                AddStudentSubject(context, student2Id, "PHY");

                // Add sample grades
                AddGrade(context, student1Id, "MATH", new DateTime(2021, 12, 15), 85);
                AddGrade(context, student1Id, "ENG", new DateTime(2021, 12, 20), 90);
                AddGrade(context, student2Id, "ENG", new DateTime(2021, 12, 20), 95);
                AddGrade(context, student2Id, "PHY", new DateTime(2021, 12, 18), 89);

                // Save changes to the database
                context.SaveChanges();
            }
        }

        // A private method to add a new subject to the database
        private static void AddSubject(EduContext context, string abbreviation, string subjectName)
        {
            // Check if the subject already exists in the database
            if (!context.Subjects.Any(s => s.Abbreviation == abbreviation))
            {
                // Create a new Subject object and add it to the context
                context.Subjects.Add(new Subject { Abbreviation = abbreviation, SubjectName = subjectName });

                // Save changes to the database
                context.SaveChanges();
            }
        }

        // A private method to add a new student to the database
        private static int AddStudent(EduContext context, string firstName, string lastName, DateTime dateOfBirth)
        {
            // Create a new Student object and add it to the context
            var student = new Student { FirstName = firstName, LastName = lastName, DateOfBirth = dateOfBirth };
            context.Students.Add(student);

            // Save changes to the database
            context.SaveChanges();

            // Return the ID of the newly created student
            return student.StudentId;
        }

        // A private method to add a new StudentSubject record to the database
        private static void AddStudentSubject(EduContext context, int studentId, string abbreviation)
        {
            // Check if the StudentSubject record already exists for this student and subject
            var existing = context.StudentSubjects.Find(studentId, abbreviation);
            if (existing == null)
            {
                // Create a new StudentSubject object and add it to the context
                var studentSubject = new StudentSubject { StudentId = studentId, Abbreviation = abbreviation };
                context.StudentSubjects.Add(studentSubject);

                // Save changes to the database
                context.SaveChanges();
            }
        }

        private static void AddGrade(EduContext context, int studentId, string abbreviation, DateTime gradingDate, int numericalGrade)
        {
            // Check if the StudentSubject record exists for this student and subject
            var studentSubject = context.StudentSubjects.FirstOrDefault(ss => ss.StudentId == studentId && ss.Abbreviation == abbreviation);
            if (studentSubject == null)
            {
                // Create a new StudentSubject record if it doesn't exist
                studentSubject = new StudentSubject { StudentId = studentId, Abbreviation = abbreviation };
                context.StudentSubjects.Add(studentSubject);
            }

            // Create the Grade record
            var grade = new Grade { StudentId = studentId, Abbreviation = abbreviation, GradingDate = gradingDate, NumericalGrade = numericalGrade };
            context.Grades.Add(grade);

            // Save changes to the database
            context.SaveChanges();
        }


    }
}



