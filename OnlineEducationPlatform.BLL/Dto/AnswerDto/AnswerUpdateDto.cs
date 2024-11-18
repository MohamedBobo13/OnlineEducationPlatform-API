using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Dtos
{
    public class AnswerUpdateDto
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
        public decimal MarksAwarded { get; set; }
    }
}
