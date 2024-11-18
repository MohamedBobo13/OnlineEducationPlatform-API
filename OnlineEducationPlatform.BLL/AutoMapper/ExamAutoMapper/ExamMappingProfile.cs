using AutoMapper;
using OnlineEducationPlatform.BLL.Dto.ExamDto;
using OnlineEducationPlatform.BLL.Dto.QuizDto;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.AutoMapper.ExamMappingProfile
{
    public class ExamMappingProfile:Profile
    {
        public ExamMappingProfile()
        {
            CreateMap<Exam, ExamAddDto>().ReverseMap();
            CreateMap<Exam, ExamReadDto>().ReverseMap();
            CreateMap<Exam, ExamUpdateDto>().ReverseMap();
        }

    }
}
