using OnlineEducationPlatform.BLL.Dto.ExamDto;
using OnlineEducationPlatform.BLL.Dto.QuizDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Manager.ExamManager
{
    public interface IExamManager
    {
        Task<List<ExamReadDto>> GetAllAsync();
        Task<ExamReadDto> GetByIdAsync(int id);
        Task<ExamAddDto> AddAsync(ExamAddDto examAddDto);
        Task <ExamUpdateDto> Update(ExamUpdateDto examUpdateDto);
        Task DeleteAsync(int id);
        Task<bool> CourseIdExist(int courseId);
   
    }
}
