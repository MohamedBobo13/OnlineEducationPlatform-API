﻿using AutoMapper;
using OnlineEducationPlatform.BLL.Dtos;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.AutoMapper.AnswerResultAutoMapper
{
    public class AnswerResultMappingProfile : Profile
    {
        public AnswerResultMappingProfile()
        {
            CreateMap<AnswerResult, AnswerResultAddDto>().ReverseMap();
            CreateMap<AnswerResult, AnswerResultReadDto>().ReverseMap();
            CreateMap<AnswerResult, AnswerResultUpdateDto>().ReverseMap();
        }
    }
}
