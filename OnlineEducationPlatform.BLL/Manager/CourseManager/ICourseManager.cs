using OnlineEducationPlatform.BLL.Dto.CourseDto;
using OnlineEducationPlatform.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Manager
{
    public interface ICourseManager
    {
        Task AddAsync(CourseAddDto courseAddDto);
        Task<IEnumerable<CourseReadDto>> GetAllAsync();
        Task<CourseReadDto> GetByIdAsync(int id);
        Task UpdateAsync(CourseUpdateDto courseUpdateDto);
        Task<bool> DeleteAsync(int id);
        Task<bool> InstructorIdExist(string InstructorId);
        Task<bool> IdExist(int Id);
      

    }
}
