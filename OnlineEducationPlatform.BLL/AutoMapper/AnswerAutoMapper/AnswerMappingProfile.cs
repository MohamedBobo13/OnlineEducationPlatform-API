using AutoMapper;
using OnlineEducationPlatform.BLL.Dtos;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.AutoMapper.AnswerAutoMapper
{
    public class AnswerMappingProfile : Profile
    {
        public AnswerMappingProfile()
        {
            CreateMap<Answer, AnswerAddDto>().ReverseMap();
            CreateMap<Answer, AnswerReadDto>().ReverseMap();
            CreateMap<Answer, AnswerUpdateDto>().ReverseMap();
        }
    }
}
