using OnlineEducationPlatform.BLL.Dto.LectureDto;
using OnlineEducationPlatform.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Manager
{
    public interface ILectureManager
    {
        Task AddAsync(LectureAddDto lectureAddDto);
        Task<IEnumerable<LectureReadDto>> GetAllAsync();
        Task<LectureReadDto> GetByIdAsync(int id);
        Task UpdateAsync(LectureUpdateDto lectureUpdateDto);
        Task<bool> DeleteAsync(int id);
         Task<bool> CourseIdExist(int courseId);
        Task<bool> IdExist(int id);
       
    }
}
