using AutoMapper;
using OnlineEducationPlatform.BLL.Dto.Quizresultsdto;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.AutoMapper.QuizResultAutoMapper
{
    public class QuizResultMappingProfile : Profile
    {
        public QuizResultMappingProfile()
        {
            CreateMap<QuizResult, quizresultreaddto>().ReverseMap();

            CreateMap<QuizResult, quizresultwithoutiddto>().ReverseMap();

        }
    }
}
