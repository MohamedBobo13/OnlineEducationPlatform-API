using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repo.AnswerRepo
{
    public interface IAnswerRepo
    {
        Task<IEnumerable<Answer>> GetAllAsync();
        Task<Answer> GetByIdAsnyc(int id);
        Task DeleteAsync(Answer answer);
        Task UpdateAsync(Answer answer);
        Task AddAsync(Answer answer);
        Task<bool> IdExist(int answerId);
        Task<bool> QuestionIdExist(int questionId);
        Task SaveChangeAsync();
    }
}
