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
    public class CourseRepo : ICourseRepo
    {
        private readonly EducationPlatformContext _context;

        public CourseRepo(EducationPlatformContext context)
        {
            _context = context;
        }


        public async Task AddAsync(Course course)
        {
            await _context.Course.AddAsync(course);
            SaveChangesAsync();
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            var courses= await _context.Course.AsNoTracking().Where(c=>c.IsDeleted==false).ToListAsync();
            if (courses != null)
            {
                return courses;
            }
            return null;
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            
            return await _context.Course.Where(c=>c.IsDeleted==false)
                .FirstOrDefaultAsync(c=>c.Id==id);
        }

        public async Task UpdateAsync(Course course)
        {
            await SaveChangesAsync();

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var course= await _context.Course.FindAsync(id);
            if (course != null)
            {
                course.IsDeleted = true;
                await SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<bool> InstructorIdExist(string InstructorId)
        {
            var Instructorexist = await _context.User.AnyAsync(a => a.Id == InstructorId && a.UserType == TypeUser.Instructor);
            if (Instructorexist)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> IdExist(int CourseId)
        {
            var CourseIdExist = await _context.Course.AnyAsync(a => a.Id == CourseId);
            if (CourseIdExist)
            {
                return true;
            }
            return false;
        }
    }
}
