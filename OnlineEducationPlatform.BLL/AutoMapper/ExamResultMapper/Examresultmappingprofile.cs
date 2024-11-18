using AutoMapper;
using OnlineEducationPlatform.BLL.AutoMapper.QuizResultAutoMapper;
using OnlineEducationPlatform.BLL.Dto.Quizresultsdto;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.AutoMapper.ExamResultMapper
{
    public class Examresultmappingprofile :Profile
    {
        public Examresultmappingprofile()
        {
            
            
                CreateMap<ExamResult, Examresultreaddto>().ReverseMap();

                CreateMap<ExamResult, Examresultwithoutiddto>().ReverseMap();

            
        }
    }
}
