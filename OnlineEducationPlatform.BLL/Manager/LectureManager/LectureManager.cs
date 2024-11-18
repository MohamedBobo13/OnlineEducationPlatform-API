using AutoMapper;
using OnlineEducationPlatform.BLL.Dto.LectureDto;
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
    public class LectureManager : ILectureManager
    {
        private readonly ILectureRepo _lectureRepo;
        private readonly IMapper _mapper;

        public LectureManager(ILectureRepo lectureRepo,IMapper mapper)
        {
            _lectureRepo = lectureRepo;
            _mapper = mapper;
        }
        public async Task AddAsync(LectureAddDto lectureAddDto)  
        {
            var lecture = _mapper.Map<Lecture>(lectureAddDto);
            await _lectureRepo.AddAsync(lecture);

        }


        public async Task<bool> DeleteAsync(int id)
        {
            var lecture = await _lectureRepo.GetByIdAsync(id);
            if (lecture != null)
            {
                var result = await _lectureRepo.DeleteAsync(lecture.Id);
          
                if (result == true)
                {
                    return true;
                }
                return false;
            }
            return false;
        }


        public async Task<IEnumerable<LectureReadDto>> GetAllAsync()
        {
            var lectures = await _lectureRepo.GetAllAsync();
            return _mapper.Map<List<LectureReadDto>>(lectures);
        }



        public async Task<LectureReadDto> GetByIdAsync(int id)
        {
            var lecture = await _lectureRepo.GetByIdAsync(id);
            if (lecture != null)
            {
                return _mapper.Map<LectureReadDto>(lecture);
            }
            return null;
        }


        public async Task UpdateAsync(LectureUpdateDto lectureUpdateDto)
        {
            var lecture = await _lectureRepo.GetByIdAsync(lectureUpdateDto.Id);
            if (lecture == null)
            {
                return;
            }
            lecture.Id = lectureUpdateDto.Id;
            lecture.Order = lectureUpdateDto.Order;
            lecture.CourseId = lectureUpdateDto.CourseId;
            lecture.Title = lectureUpdateDto.Title;

            await _lectureRepo.UpdateAsync(lecture);
        }
        public async Task<bool> CourseIdExist(int courseId)
        {
            bool courseExist = await _lectureRepo.CourseIdExist(courseId);
            if (courseExist)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> IdExist(int id)
        {
            bool idExist = await _lectureRepo.IdExist(id);
            if (idExist)
            {
                return true;
            }
            return false;
        }
    }
}
