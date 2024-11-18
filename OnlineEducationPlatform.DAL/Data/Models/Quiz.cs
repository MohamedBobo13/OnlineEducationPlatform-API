using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;

namespace OnlineEducationPlatform.DAL.Data.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TotalMarks { get; set; }
        public int TotalQuestions { get; set; }
        public bool IsDeleted { get; set; }
        [ForeignKey("Lecture")]
        public int LectureId { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Lecture Lecture { get; set; }
        public Course Course { get; set; }
        public ICollection<QuizResult> QuizResults { get; set; } = new HashSet<QuizResult>();
        public ICollection<Question> Questions { get; set; } = new HashSet<Question>();


    }
}
