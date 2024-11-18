using AutoMapper;
using OnlineEducationPlatform.BLL.Dto.VideoDto;
using OnlineEducationPlatform.BLL.Dtos;
using OnlineEducationPlatform.DAL.Data.Models;
using OnlineEducationPlatform.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Manager
{
    public class VedioManager:IVedioManager
    {
        private readonly IVedioRepo _vedioRepo;
        private readonly IMapper _mapper;

        public VedioManager(IVedioRepo vedioRepo, IMapper mapper)
        {
            _vedioRepo = vedioRepo;
            _mapper = mapper;
        }
        public async Task AddAsync(VedioAddDto vedioAddDto) /// Done 
        {
            var video = _mapper.Map<Video>(vedioAddDto);
            await _vedioRepo.AddAsync(video);

        }


        public async Task<bool> DeleteAsync(int id)
        {
            var video = await _vedioRepo.GetByIdAsync(id);
            if (video != null)
            {
                var result = await _vedioRepo.DeleteAsync(video.Id);
                //SaveChangesAsync();
                if (result == true)
                {
                    return true;
                }
                return false;
            }
            return false;
        }


        public async Task<IEnumerable<VedioReadDto>> GetAllAsync()
        {
            var vedeos = await _vedioRepo.GetAllAsync();
            return _mapper.Map<List<VedioReadDto>>(vedeos);
        }



        public async Task<VedioReadDto> GetByIdAsync(int id)
        {
            var video = await _vedioRepo.GetByIdAsync(id);
            if (video != null)
            {
                return _mapper.Map<VedioReadDto>(video);
            }
            return null;
        }


        public async Task UpdateAsync(VedioUpdateDto vedioUpdateDto)
        {
            var video = await _vedioRepo.GetByIdAsync(vedioUpdateDto.Id);
            if (video != null)
            {
                video.Id = vedioUpdateDto.Id;
                video.Url = vedioUpdateDto.Url;
                video.LectureId = vedioUpdateDto.LectureId;
                video.Title = vedioUpdateDto.Title;

                await _vedioRepo.UpdateAsync(video);
            }
            return ;
        }
        public async Task<bool> LectureIdExist(int LectrueId)
        {
            bool Lectureexist = await _vedioRepo.LectureIdExist(LectrueId);
            if (Lectureexist)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> IdExist(int id)
        {
            bool idExist = await _vedioRepo.IdExist(id);
            if (idExist)
            {
                return true;
            }
            return false;
        }
    }
}
