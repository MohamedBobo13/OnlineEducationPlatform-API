using OnlineQuiz.BLL.Dtos.Accounts;

namespace OnlineQuiz.BLL.Managers.Accounts
{
    public interface  IEmailService
    {
        Task<GeneralRespnose> SendEmailAsync(string email, string subject, string message);
    }
}
