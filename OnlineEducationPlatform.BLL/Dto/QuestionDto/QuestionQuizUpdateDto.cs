using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Dto.QuestionDto
{
    public class QuestionQuizUpdateDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Marks { get; set; }
        public QuestionType QuestionType { get; set; }
        public int QuizId { get; set; }
    }
}
