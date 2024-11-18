using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Dto.EnrollmentDto
{
    public class EnrollmentDto
    {
        //  public int EnrollmentId { get; set; }
        public string StudentId { get; set; }
        public int CourseId { get; set; }
        //  public DateTime EnrollmentDate { get; set; }= DateTime.Now;
        //public EnrollmentStatus Status { get; set; }
    }
    public class EnrollmentDtowWithStatusanddDate : EnrollmentDto
    {
        public string? Status { get; set; }
        public DateTime? EnrollmentDate { get; set; } = DateTime.Now;
    }
    public class EnrollmentDtoForRetriveAllEnrollmentsInCourse : EnrollmentDto
    {
        public int Id { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public string? status { get; set; }



    }
}
