using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Dto.Quizresultsdto
{
    public class ExamResultDto
    {
        public string studentId { get; set; }

        public int Examid { get; set; }


    }
    public class Examresultwithoutiddto : ExamResultDto
    {
        
        public decimal Score { get; set; }
        public decimal TotalMarks { get; set; }
        public bool IsPassed { get; set; }

    }
    public class Examresultreaddto : Examresultwithoutiddto
    {

        public int id { get; set; }

        

    }
}
