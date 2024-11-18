using OnlineEducationPlatform.BLL.Dto;
using OnlineEducationPlatform.BLL.Dto.EnrollmentDto;
using OnlineEducationPlatform.BLL.Dto.Quizresultsdto;
using OnlineEducationPlatform.BLL.handleresponse;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Manager.quizresultmanager
{
    public interface IQuizResultManager
    {
        Task<ServiceResponse<List<quizresultreaddto>>> GetAllQuizResults();

        Task<ServiceResponse<quizresultreaddto>> GetQuizResultAsync(string studentid, int quizid);
        Task<ServiceResponse<bool>> softdeletequizresult(string studentId, int quizid);
        Task<ServiceResponse<bool>> updatequizresultbyid(updatequizresultdto quizresultreaddto);
        Task<ServiceResponse<List<quizresultwithoutiddto>>> GetAllSoftDeletedQuizresultsAsync();

        Task<ServiceResponse<bool>> HardDeleteEQuizresulttByStudentAndquizsync(string studentId, int quizid);
       Task<ServiceResponse<quizresultwithoutiddto>> CreateQuizresultAsync(quizresultwithoutiddto quizresultwithoutiddto);

       Task<ServiceResponse<List<quizresultreaddto>>> GetStudentresultssByStudentIdAsync(string studentId);
        Task<ServiceResponse<List<quizresultreaddto>>> GetstudentresultsByQuizIdAsync(int QuizId);
        



    }
}
