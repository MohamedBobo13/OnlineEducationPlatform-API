using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Dtos
{
    public class PdfFileAddDto
    {
      
        [Url]
        public string Url { get; set; }
        public string Title { get; set; }
        [ForeignKey("Lecture")]
        public int LectureId { get; set; }
       
    }
}
