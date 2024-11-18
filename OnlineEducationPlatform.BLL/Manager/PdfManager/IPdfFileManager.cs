using OnlineEducationPlatform.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Manager
{
    public interface IPdfFileManager
    {
        Task AddAsync(PdfFileAddDto pdfFileAddDto);
        Task<IEnumerable<PdfFileReadDto>> GetAllAsync();
        Task<PdfFileReadDto> GetByIdAsync(int id);
        Task UpdateAsync(PdfFileUpdateDto pdfFileUpdateDto);
        Task<bool> DeleteAsync(int id);
        Task<bool> LectureIdExist(int LectrueId);
        Task<bool> IdExist(int id);
     

    }
}
