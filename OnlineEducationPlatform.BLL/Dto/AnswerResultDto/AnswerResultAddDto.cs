using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Dtos
{
    public class AnswerResultAddDto
    {
        public string StudentAnswer { get; set; }
       
        public string StudentId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
    }
}
