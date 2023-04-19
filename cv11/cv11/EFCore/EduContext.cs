using Microsoft.EntityFrameworkCore;

namespace cv11.EFCore
{
    public class EduContext : DbContext
    {
        // DbSets for each entity
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }

        // Configures the database connection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EduDatabase;Trusted_Connection=True;");
        }

        // Configures the entity relationships and primary keys
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configures the primary key for the StudentSubject entity
            modelBuilder.Entity<StudentSubject>()
                .HasKey(ss => new { ss.StudentId, ss.Abbreviation });

            // Configures the StudentSubject-Student relationship
            modelBuilder.Entity<StudentSubject>()
                .HasOne(ss => ss.Student)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(ss => ss.StudentId);

            // Configures the StudentSubject-Subject relationship
            modelBuilder.Entity<StudentSubject>()
                .HasOne(ss => ss.Subject)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(ss => ss.Abbreviation);

            // Configures the primary key for the Grade entity
            modelBuilder.Entity<Grade>()
                .HasKey(g => new { g.StudentId, g.Abbreviation });

            // Configures the Grade-Student relationship
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Student)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.StudentId);

            // Configures the Grade-Subject relationship
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Subject)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.Abbreviation);
        }
    }
}
