using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Data.DbHelper
{
    public class EducationPlatformContext : IdentityDbContext<ApplicationUser>
    {
        public EducationPlatformContext(DbContextOptions<EducationPlatformContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Answer>()
                        .HasQueryFilter(a => !a.IsDeleted);
            modelBuilder.Entity<AnswerResult>()
                        .HasQueryFilter(a => !a.IsDeleted);
            modelBuilder.Entity<Question>()
                        .HasQueryFilter(a => !a.IsDeleted);
            modelBuilder.Entity<Enrollment>()
                    .HasQueryFilter(a => !a.IsDeleted);
            modelBuilder.Entity<ApplicationUser>()
                  .HasQueryFilter(a => !a.IsDeleted);
            modelBuilder.Entity<Course>()
                  .HasQueryFilter(a => !a.IsDeleted);
            modelBuilder.Entity<QuizResult>()
                .HasQueryFilter(a => !a.IsDeleted);
            modelBuilder.Entity<Lecture>()
            .HasQueryFilter(a => !a.IsDeleted);
            modelBuilder.Entity<Video>()
           .HasQueryFilter(a => !a.IsDeleted);
            modelBuilder.Entity<PdfFile>()
           .HasQueryFilter(a => !a.IsDeleted);
            modelBuilder.Entity<ExamResult>()
           .HasQueryFilter(a => !a.IsDeleted);
            modelBuilder.Entity<Quiz>()
          .HasQueryFilter(a => !a.IsDeleted);
            modelBuilder.Entity<Exam>()
         .HasQueryFilter(a => !a.IsDeleted);



            modelBuilder.Entity<Enrollment>()

        .HasIndex(e => new { e.StudentId, e.CourseId })
        .IsUnique();
            modelBuilder.Entity<QuizResult>()
     .HasIndex(e => new { e.StudentId, e.QuizId })
     .IsUnique();
            modelBuilder.Entity<ExamResult>()
 .HasIndex(e => new { e.StudentId, e.ExamId })
 .IsUnique();

           



        }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<AnswerResult> AnswerResult { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<Exam> Exam { get; set; }
        public DbSet<ExamResult> ExamResult { get; set; }
        public DbSet<Lecture> Lecture { get; set; }
        public DbSet<PdfFile> PdfFile { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Quiz> Quiz { get; set; }
        
        public DbSet<ApplicationUser> User { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<Admin> Admin { get; set; }






        public DbSet<Video> Video { get; set; }
        public DbSet<QuizResult> QuizResult { get; set; }


    }
} 
