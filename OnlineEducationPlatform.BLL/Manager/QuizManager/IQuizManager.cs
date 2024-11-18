using OnlineEducationPlatform.BLL.Dto.QuizDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Manager.QuizManager
{
    public interface IQuizManager
    {
        Task<List<QuizReadDto>> GetAllAsync();
        Task<QuizReadDto> GetByIdAsync(int id);
        Task<QuizAddDto> AddAsync(QuizAddDto quizAddDto);
        Task <QuizUpdateDto>UpdateAsync(QuizUpdateDto quizUpdateDto);
        Task DeleteAsync(int id);
        Task<bool> CourseIdExist(int courseId);
        Task<bool> LectureIdExist(int LectureId);


    }
}
