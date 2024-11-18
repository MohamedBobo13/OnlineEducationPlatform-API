using AutoMapper;
using OnlineEducationPlatform.BLL.AutoMapper.StudentAutoMapper;
using OnlineEducationPlatform.BLL.Dto.InstructorDto;
using OnlineEducationPlatform.BLL.Dto.StudentDto;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.AutoMapper.InstructorAutoMapper
{
    public class InstructorMappingProfile :Profile
    {
        public InstructorMappingProfile()
        {
           
            
                CreateMap<Instructor, InstructorReadDto>().ReverseMap();

            
        }
    }
}
