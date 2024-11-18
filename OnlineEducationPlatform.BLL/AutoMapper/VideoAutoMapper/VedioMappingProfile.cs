using AutoMapper;
using OnlineEducationPlatform.BLL.Dto.VideoDto;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.AutoMapper.VideoAutoMapper
{
    public class VedioMappingProfile : Profile
    {
        public VedioMappingProfile()
        {
            CreateMap<Video, VedioAddDto>().ReverseMap();
            CreateMap<Video, VedioReadDto>().ReverseMap();
            CreateMap<Video, VedioUpdateDto>().ReverseMap();
        }
    }
}
