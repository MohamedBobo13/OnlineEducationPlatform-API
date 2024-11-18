using OnlineEducationPlatform.BLL.Dto.InstructorDto;
using OnlineEducationPlatform.BLL.Dto.StudentDto;
using OnlineEducationPlatform.BLL.handleresponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Manager.InstructorManager
{
    public interface IInstructorManager


    {


        Task<ServiceResponse<List<InstructorReadDto>>> GetAllInstructorsAsync();

        Task<ServiceResponse<InstructorReadDto>> GetInstructorbyid(string InstructorId);
        Task<ServiceResponse<bool>> softdeleteInstructor(string InstructorId);
    }
}
