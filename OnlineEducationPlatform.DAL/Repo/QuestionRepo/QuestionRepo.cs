using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.DAL.Data.DbHelper;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repo.QuestionRepo
{
    public class QuestionRepo : IQuestionRepo
    {
        private readonly EducationPlatformContext _context;

        public QuestionRepo(EducationPlatformContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            return await _context.Question.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Question>> GetCourseExamAsync(int courseId)
        {
            return await _context.Question.Where(q => q.QuizId == null && q.CourseId == courseId).ToListAsync();
            
        }

        public async Task<IEnumerable<Question>> GetCourseQuizAsync(int courseId)
        {
            return await _context.Question.Where(q => q.ExamId == null && q.CourseId == courseId).ToListAsync();
        }

        public async Task<Question> GetByIdAsync(int id)
        {
            return await _context.Question.FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task AddAsync(Question question)
        {
            await _context.AddAsync(question);
            await SaveChangeAsync();
        }
        public async Task UpdateAsync(Question question)
        {
            _context.Update(question);
            await SaveChangeAsync();
        }
        public async Task DeleteAsync(Question question)
        {
            question.IsDeleted = true;
            _context.Update(question);
            await SaveChangeAsync();
        }

        public async Task<bool> IdForExam(int questionId)
        {
            bool idforExam = await _context.Question.Where(q=>q.QuizId == null).AnyAsync(q=>q.Id == questionId);
            if(idforExam)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> IdForQuiz(int questionId)
        {
            bool idforQuiz = await _context.Question.Where(q => q.ExamId == null).AnyAsync(q => q.Id == questionId);
            if (idforQuiz)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> QuizIdExist(int quizId)
        {
            var quizExist = await _context.Quiz.AnyAsync(q => q.Id == quizId);
            if (quizExist)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> ExamIdExist(int examId)
        {
            var examExist = await _context.Exam.AnyAsync(e => e.Id == examId);
            if (examExist)
            {
                return true;
            }
            return false;
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

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

        
    }
}