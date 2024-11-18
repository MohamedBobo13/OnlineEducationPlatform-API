using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Dto.EnrollmentDto
{
    public class updateenrollmentdto
    {
        public int Id { get; set; }
       
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;
        public string StudentId { get; set; }

        public int CourseId { get; set; }
        public EnrollmentStatus Status { get; set; }

    }
}
