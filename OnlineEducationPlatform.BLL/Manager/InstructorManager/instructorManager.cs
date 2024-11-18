﻿using AutoMapper;
using OnlineEducationPlatform.BLL.Dto.InstructorDto;
using OnlineEducationPlatform.BLL.Dto.StudentDto;
using OnlineEducationPlatform.BLL.handleresponse;
using OnlineEducationPlatform.DAL.Data.Models;
using OnlineEducationPlatform.DAL.Repo.InstructorRepo;
using OnlineEducationPlatform.DAL.Repo.StudentRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Manager.InstructorManager
{
    public class instructorManager : IInstructorManager
    {

        private readonly IInstructorRepo _instructorrepo;
        private readonly IMapper _mapper;

        public instructorManager(IInstructorRepo instructorrepo, IMapper mapper)
        {
            _instructorrepo = instructorrepo;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<InstructorReadDto>>> GetAllInstructorsAsync()
        {
            var response = new ServiceResponse<List<InstructorReadDto>>();
            try
            {
                var instructors = await _instructorrepo.GetAllInstructors();
                if (instructors == null || instructors.Any() == false)
                {
                    response.Message = "There Are No Instructors yet or all Instructors are soft deleted!!";
                    response.Success = false;
                    return response;


                }
                
               
             
                else
                {

                   
                    response.Data = _mapper.Map<List<InstructorReadDto>>(instructors);
                    response.Message = "There Are Instructors : ";
                    response.Success = true;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error fetching Studens: {ex.Message}";

            }
            return response;
        }

        public async Task<ServiceResponse<InstructorReadDto>> GetInstructorbyid(string InstructorId)
        {
            var instructor = new Instructor
            {
                Id = InstructorId,


            };
            var response = new ServiceResponse<InstructorReadDto>();
            var instructorexist = await _instructorrepo.InstructorExistsAsync(InstructorId);
            if (instructorexist == false)
            {
                response.Data = null;
                response.Message = $"Failed to Get Instructor because Instructor with ID {InstructorId} not found..";
                response.Success = false;

                return response;
                
            }
            var softdeletedinstructor = await _instructorrepo.IsInstructorSoftDeletedAsync(InstructorId);
            if (softdeletedinstructor == true)
            {

                response.Data = null;
                response.Message = $"Failed to Get Instructor because Instructor with  Id {InstructorId} already exist but it is soft deleted.";
                response.Success = false;
                return response;
            }





            else
            {
                var getstudent = await _instructorrepo.GetInstructorByIdAsync(InstructorId);
                response.Data = new InstructorReadDto
                {
                    Id = getstudent.Id,
                    Username = getstudent.UserName,
                    Email = getstudent.Email,
                    PhoneNumber = getstudent.PhoneNumber,


                };
                response.Message = "Instructor Information :.";

                response.Success = true;
                return response;
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> softdeleteInstructor(string InstructorId)
        {
            var instructor = await _instructorrepo.GetInstructorByIdAsyncsoftornot(InstructorId);

            var response = new ServiceResponse<bool>();
            try

            {

                var softdeletedstudent = await _instructorrepo.IsInstructorSoftDeletedAsync(InstructorId);

                if (softdeletedstudent == true)
                {

                    response.Message = $"Failed to soft delete Instructor because Instructor is already soft deleted ";
                    response.Success = false;
                    return response;


                }
                if (instructor == null)
                {
                    response.Success = false;
                    response.Message = "Failed to delete Instructor because it is not existed !!";
                    return response;
                }






                var saveresult = await _instructorrepo.RemoveAsync(instructor);




                if (saveresult)
                {

                    response.Data = true;

                    response.Message = "Instructor Soft deleted successfully.";

                    response.Success = true;


                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occurred: {ex.Message}";

            }
            return response;


        }
    }
}