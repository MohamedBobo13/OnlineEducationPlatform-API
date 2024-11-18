using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Dto.Quizresultsdto
{
    public class QuizResultDto
    {
        public string studentId { get; set; }

        public int QuizId { get; set; }


    }
    public class quizresultwithoutiddto : QuizResultDto
    {

        public decimal Score { get; set; }
        public decimal TotalMarks { get; set; }
    }
    public class quizresultreaddto : quizresultwithoutiddto
    {

        public int id { get; set; }

        

    }
}
