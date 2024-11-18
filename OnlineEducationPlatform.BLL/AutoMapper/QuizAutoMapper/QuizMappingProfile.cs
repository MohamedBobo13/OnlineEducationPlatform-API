using AutoMapper;
using OnlineEducationPlatform.BLL.Dto.QuizDto;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.AutoMapper.QuizAutoMapper
{
    public class QuizMappingProfile:Profile
    {
        public QuizMappingProfile()
        {
            CreateMap<Quiz, QuizAddDto>().ReverseMap();
            CreateMap<Quiz, QuizReadDto>().ReverseMap();
            CreateMap<Quiz, QuizUpdateDto>().ReverseMap();
        }
    }
}
