using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repo.AnswerResultRepo
{
    public interface IAnswerResultRepo
    {
        Task<IEnumerable<AnswerResult>> GetAllAsync();
        Task<AnswerResult> GetByIdAsync(int id);
        Task DeleteAsync(AnswerResult answerResult);
        Task UpdateAsync(AnswerResult answerResult);
        Task AddAsync(AnswerResult answerResult);
        Task<bool> IdExist(int answerResultId);
        Task<bool> QuestionIdExist(int questionId);
        Task<bool> StudentIdExist(string studentId);
        Task<bool> AnsweerIdExist(int answerId);
        Task SaveChangeAsync();
    }
}
