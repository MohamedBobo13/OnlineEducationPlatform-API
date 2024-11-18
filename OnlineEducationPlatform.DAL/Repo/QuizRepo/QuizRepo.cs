using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.DAL.Data.DbHelper;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repo.QuizRepo
{
    public class QuizRepo : IQuizRepo
    {
        private readonly EducationPlatformContext _context;

        public QuizRepo(EducationPlatformContext educationPlatformContext)
        {
            _context = educationPlatformContext;
        }
        public async Task Add(Quiz quiz)
        {
            await _context.Quiz.AddAsync(quiz);
         
        }

        public async Task<bool> Delete(int id)
        {
            var quiz = await _context.Quiz
                                        .FirstOrDefaultAsync(e => e.Id == id);
            if (quiz != null)
            {
                quiz.IsDeleted = true;
                _context.Update(quiz);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Quiz>> GetAll()
        {
            return await _context.Quiz.AsNoTracking().ToListAsync();

        }

        public async  Task<Quiz> GetById(int id)
        {
            return await _context.Quiz
                                         .FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task Update(Quiz quiz)
        {
            _context.Quiz.Update(quiz);
         
        }
        public async Task<bool> CompleteAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> quizExistsAsyncbyid(int id)
        {
            return await _context.Quiz
                .AnyAsync(e => e.Id == id);
        }
        public async Task<bool> CourseIdExist(int courseId)
        {
            var courseExist = await _context.Course.AnyAsync(c => c.Id == courseId);
            if (courseExist)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> LectureIdExist(int LectureId)
        {
            var courseExist = await _context.Lecture.AnyAsync(c => c.Id == LectureId);
            if (courseExist)
            {
                return true;
            }
            return false;

        }

    }
}
