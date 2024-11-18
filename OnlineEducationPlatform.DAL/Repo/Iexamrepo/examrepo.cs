using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.DAL.Data.DbHelper;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repo.Iexamrepo
{
    public  class examrepo:Iexamrepo
    {
        private readonly EducationPlatformContext _context;

        public examrepo(EducationPlatformContext educationPlatformContext)
        {
            _context = educationPlatformContext;
        }
        public async Task Add(Exam exam)
        {
            await _context.Exam.AddAsync(exam);

        }

        public async Task<bool> Delete(int id)
        {
            var exam = await _context.Exam
                                        .FirstOrDefaultAsync(e => e.Id == id);
            if (exam != null)
            {
                exam.IsDeleted = true;
                _context.Update(exam);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Exam>> GetAll()
        {
            return await _context.Exam.AsNoTracking().ToListAsync();

        }

        public async Task<Exam> GetById(int id)
        {
            return await _context.Exam
                                         .FirstOrDefaultAsync(a => a.Id == id);
        }
       
        public async Task Updateasync(Exam exam)
        {
            _context.Exam.Update(exam);
      
        }
        public async Task<bool> CompleteAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> examExistsAsyncbyid(int id)
        {
            return await _context.Exam
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
     
    }
}
