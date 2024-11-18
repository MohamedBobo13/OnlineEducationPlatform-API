using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Dtos
{
    public class AnswerReadDto
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
        public decimal MarksAwarded { get; set; }
        public int QuestionId { get; set; }
    }
}
