using AutoMapper;
using OnlineEducationPlatform.BLL.Dto.QuestionDto;
using OnlineEducationPlatform.BLL.Dtos;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.AutoMapper.QuesionAutoMapper
{
    public class QuestionMappingProfile : Profile
    {
        public QuestionMappingProfile()
        {
            CreateMap<Question, QuestionReadDto>().ReverseMap();
            CreateMap<Question, QuestionExamUpdateDto>().ReverseMap();
            CreateMap<Question, QuestionQuizUpdateDto>().ReverseMap();
            CreateMap<Question, QuestionQuizAddDto>().ReverseMap();
            CreateMap<Question, QuestionCourseQuizReadDto>().ReverseMap();
            CreateMap<Question, QuestionExamAddDto>().ReverseMap();
            CreateMap<Question, QuestionCourseExamReadDto>().ReverseMap();
        }
    }
}
