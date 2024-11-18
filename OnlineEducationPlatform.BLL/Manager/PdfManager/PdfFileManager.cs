using AutoMapper;
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
    public class PdfFileManager:IPdfFileManager
    {
        private readonly IPdfFileRepo _pdfFileRepo;
        private readonly IMapper _mapper;

        public PdfFileManager(IPdfFileRepo pdfFileRepo, IMapper mapper)
        {
            _pdfFileRepo = pdfFileRepo;
            _mapper = mapper;
        }
        public async Task AddAsync(PdfFileAddDto pdfFileAddDto) 
        {
            var pdf = _mapper.Map<PdfFile>(pdfFileAddDto);
            await _pdfFileRepo.AddAsync(pdf);

        }


        public async Task<bool> DeleteAsync(int id)
        {
            var pdf = await _pdfFileRepo.GetByIdAsync(id);
            if (pdf != null)
            {
                var result = await _pdfFileRepo.DeleteAsync(pdf.Id);
               
                if (result == true)
                {
                    return true;
                }
                return false;
            }
            return false;
        }


        public async Task<IEnumerable<PdfFileReadDto>> GetAllAsync()
        {
            var pdfs = await _pdfFileRepo.GetAllAsync();
            return _mapper.Map<List<PdfFileReadDto>>(pdfs);
        }



        public async Task<PdfFileReadDto> GetByIdAsync(int id)
        {
            var pdf = await _pdfFileRepo.GetByIdAsync(id);
            if (pdf != null)
            {
                return _mapper.Map<PdfFileReadDto>(pdf);
            }
            return null;
        }


        public async Task UpdateAsync(PdfFileUpdateDto pdfFileUpdateDto)
        {
            var pdf = await _pdfFileRepo.GetByIdAsync(pdfFileUpdateDto.Id);
            if (pdf != null)
            {
                pdf.Id = pdfFileUpdateDto.Id;
                pdf.Url = pdfFileUpdateDto.Url;
                pdf.LectureId = pdfFileUpdateDto.LectureId;
                pdf.Title = pdfFileUpdateDto.Title;

                await _pdfFileRepo.UpdateAsync(pdf);
            }
            
            return ;
        }
        public async Task<bool> LectureIdExist(int LectrueId)
        {
            bool Lectureexist = await _pdfFileRepo.LectureIdExist(LectrueId);
            if (Lectureexist)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> IdExist(int id)
        {
            bool idExist = await _pdfFileRepo.IdExist(id);
            if (idExist)
            {
                return true;
            }
            return false;
        }
    }
}

