using AutoMapper;
using Azure;
using OnlineEducationPlatform.BLL.Dto.EnrollmentDto;
using OnlineEducationPlatform.BLL.Dto.ExamDto;
using OnlineEducationPlatform.BLL.Dto.QuizDto;
using OnlineEducationPlatform.DAL.Data.Models;
using OnlineEducationPlatform.DAL.Repo.Iexamrepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Manager.ExamManager
{
    public class ExamManager:IExamManager
    {
        private readonly Iexamrepo _examrepo;
        private readonly IMapper _mapper;

        public ExamManager(Iexamrepo examrepo,IMapper mapper)
        {
            _examrepo = examrepo;
            _mapper = mapper;
        }
        public async Task<List<ExamReadDto>> GetAllAsync()
        {
            //Auto-Mapping
            var exams = await _examrepo.GetAll();
            return _mapper.Map<List<ExamReadDto>>(exams);
        }

        public async Task<ExamReadDto> GetByIdAsync(int id)
        {
            var exam = await _examrepo.GetById(id);
            if (exam is null)
            {
                return null;
            }
            //Auto-Mapping
            return _mapper.Map<ExamReadDto>(exam);
        }

        public async Task<ExamAddDto> AddAsync(ExamAddDto examAddDto)

        {


            var exam = _mapper.Map<Exam>(examAddDto);



            await _examrepo.Add(exam);
            var saveresult = await _examrepo.CompleteAsync();
            if (saveresult == true)
            {
                return new ExamAddDto
                {

                   
                    CourseId = exam.CourseId,
                    Title = exam.Title,
                    TotalMarks = exam.TotalMarks,
                    TotalQuestions = exam.TotalQuestions,
                    DurationMinutes = exam.DurationMinutes,
                    PassingMarks = exam.PassingMarks,
                };

            }
            return null;
            //await _quizRepo.Add(_mapper.Map<Quiz>(quizAddDto));
        }


        public async Task<ExamUpdateDto> Update(ExamUpdateDto examUpdateDto)
        {
            var exam = await _examrepo.GetById(examUpdateDto.Id);
            var existingexam = await _examrepo.examExistsAsyncbyid(examUpdateDto.Id);
           
            if (existingexam == true)
            {
                exam.Id = examUpdateDto.Id;
                exam.DurationMinutes = examUpdateDto.DurationMinutes;
                exam.CourseId = examUpdateDto.CourseId;
                exam.Title = examUpdateDto.Title;
                exam.PassingMarks = examUpdateDto.PassingMarks; 
                exam.TotalMarks = examUpdateDto.TotalMarks;
                exam.TotalQuestions = examUpdateDto.TotalQuestions;
               //var updateexam= _mapper.Map<Exam>(examUpdateDto);

                await _examrepo.Updateasync(exam);
                var saveresult = await _examrepo.CompleteAsync();
                if (saveresult == true)
                {
                    return new ExamUpdateDto
                    {


                        CourseId = exam.CourseId,
                        Title = exam.Title,
                        TotalMarks = exam.TotalMarks,
                        TotalQuestions = exam.TotalQuestions,
                        DurationMinutes = exam.DurationMinutes,
                        PassingMarks = exam.PassingMarks,
                    };
                }
                else
                {
                    return null;
                }

                
            }
            return null;
        }

        public async Task DeleteAsync(int id)
        {
            var exam = await _examrepo.GetById(id);
            if (exam is null)
            {
                return;
            }
            await _examrepo.Delete(exam.Id);
        }
        public async Task<bool> CourseIdExist(int courseId)
        {
            bool courseExist = await _examrepo.CourseIdExist(courseId);
            if (courseExist)
            {
                return true;
            }
            return false;
        }
    }
}
