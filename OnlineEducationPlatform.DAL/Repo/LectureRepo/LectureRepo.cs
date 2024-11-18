using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.DAL.Data.DbHelper;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repositories
{
    public class LectureRepo : ILectureRepo
    {
        private readonly EducationPlatformContext _context;

        public LectureRepo(EducationPlatformContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Lecture lecture)
        {
            await _context.Lecture.AddAsync(lecture);
            SaveChangesAsync();
        }

        public async Task<IEnumerable<Lecture>> GetAllAsync()
        {
            var lecture = await _context.Lecture.AsNoTracking().Where(l => l.IsDeleted == false).ToListAsync();
            if (lecture != null)
            {
                return lecture;
            }
            return null;
        }

        public async Task<Lecture> GetByIdAsync(int id)
        {

            return await _context.Lecture.Where(l => l.IsDeleted == false)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task UpdateAsync(Lecture lecture)
        {
            await SaveChangesAsync();

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var lecture = await _context.Lecture.FindAsync(id);
            if (lecture != null)
            {
                lecture.IsDeleted = true;
                await SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
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
        public async Task<bool> IdExist(int Id)
        {
            var LectureIdExist = await _context.Lecture.AnyAsync(a => a.Id == Id);
            if (LectureIdExist)
            {
                return true;
            }
            return false;
        }

    }
}
