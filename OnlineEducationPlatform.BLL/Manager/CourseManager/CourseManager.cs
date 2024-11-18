using AutoMapper;
using OnlineEducationPlatform.BLL.Dto.CourseDto;
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
    public class CourseManager : ICourseManager
    {
        private readonly ICourseRepo _courseRepo;
        private readonly IMapper _mapper;

        public CourseManager(ICourseRepo courseRepo,IMapper mapper)
        {
           _courseRepo = courseRepo;
            _mapper = mapper;
        }
        
        public async Task AddAsync(CourseAddDto courseAddDto)
        {
            var course = _mapper.Map<Course>(courseAddDto);
            await _courseRepo.AddAsync(course);
           
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var course =await _courseRepo.GetByIdAsync(id);
            if (course != null)
            {
                var result= await _courseRepo.DeleteAsync(course.Id);
                
                if (result == true)
                {
                    return true;
                }
                return false;
            }
            return false;
        }


        public async Task<IEnumerable<CourseReadDto>> GetAllAsync()
        {
            var courses =await _courseRepo.GetAllAsync();
            return _mapper.Map<List<CourseReadDto>>(courses);
        }

        

        public async Task<CourseReadDto> GetByIdAsync(int id)
        {
            var course=await _courseRepo.GetByIdAsync(id);
            if (course != null )
            {
                return _mapper.Map<CourseReadDto>(course);
            }
            return null;
        }

        
        public async Task UpdateAsync(CourseUpdateDto courseUpdateDto)
        {
            var course = await _courseRepo.GetByIdAsync(courseUpdateDto.Id);
            if (course == null)
            {
                return;
            }
            course.Id = courseUpdateDto.Id;
            course.TotalHours = courseUpdateDto.TotalHours;
            course.CreatedDate = courseUpdateDto.CreatedDate;
            course.Description = courseUpdateDto.Description;
            course.Title = courseUpdateDto.Title;
            course.InstructorId = courseUpdateDto.InstructorId;

            await _courseRepo.UpdateAsync(course);
        }
        public async Task<bool> InstructorIdExist(string InstructorId)
        {
            bool InstructorExist = await _courseRepo.InstructorIdExist(InstructorId);
            if (InstructorExist)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> IdExist(int id)
        {
            bool idExist = await _courseRepo.IdExist(id);
            if (idExist)
            {
                return true;
            }
            return false;
        }


    }
}
