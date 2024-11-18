using OnlineEducationPlatform.BLL.Dto.EnrollmentDto;
using OnlineEducationPlatform.BLL.handleresponse;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Manager.EnrollmentManager
{
    public interface IenrollmentManager
    {
        Task<ServiceResponse<bool>> HardDeleteEnrollmentByStudentAndCourseAsync(string studentId, int courseId);
        Task<ServiceResponse<EnrollmentDtowWithStatusanddDate>> CreateEnrollmentAsync(EnrollmentDto enrollmentDto);
        Task<ServiceResponse<bool>> UnenrollFromCourseByStudentAndCourseIdAsync(string studentId,int CourseId  );
        Task<ServiceResponse<List<EnrollmentDtoForRetriveAllEnrollmentsInCourse>>> GetEnrollmentsByCourseIdAsync(int courseId);
        Task<ServiceResponse<List<EnrollmentDtoForRetriveAllEnrollmentsInCourse>>> GetEnrollmentsByStudentIdAsync(string studentId);
        Task<ServiceResponse<List<EnrollmentDtoForRetriveAllEnrollmentsInCourse>>> GetAllEnrollments();
        Task<ServiceResponse<List<EnrollmentDtowWithStatusanddDate>>> GetAllSoftDeletedEnrollmentsAsync();
        Task<ServiceResponse<bool>> updateenrollmentbyid(updateenrollmentdto updateenrollmentdto);


    }
}
