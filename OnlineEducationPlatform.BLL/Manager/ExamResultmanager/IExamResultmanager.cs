using OnlineEducationPlatform.BLL.Dto.ExamResultDto;
using OnlineEducationPlatform.BLL.Dto.Quizresultsdto;
using OnlineEducationPlatform.BLL.handleresponse;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Manager.ExamResultmanager
{
    public interface IExamResultmanager
    {
        Task<ServiceResponse<List<Examresultreaddto>>> GetAllExamResults();

        Task<ServiceResponse<Examresultreaddto>> GetExamResultAsync(string studentid, int examid);
        Task<ServiceResponse<bool>> softdeleteexamresult(string studentId, int examid);
        Task<ServiceResponse<bool>> updateexamresultbyid(updateexamresultdto examresultreaddto);
        Task<ServiceResponse<List<Examresultwithoutiddto>>> GetAllSoftDeletedexamresultsAsync();

        Task<ServiceResponse<bool>> HardDeleteExamresulttByStudentAndquizsync(string studentId, int examid);
        Task<ServiceResponse<Examresultwithoutiddto>> CreateexamresultAsync(Examresultwithoutiddto examresultwithoutiddto);

        Task<ServiceResponse<List<Examresultreaddto>>> GetStudentresultssByStudentIdAsync(string studentId);
        Task<ServiceResponse<List<Examresultreaddto>>> GetstudentresultsByExamIdAsync(int examid);

    }
}
