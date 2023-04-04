using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Model
{
    public class EvaluationDTO
    {
        public string CourseId { get; set; }
        public string StudentId { get; set; }
        public string? StudentName { get; set; }
        public int Stars { get; set; }
        public string Description { get; set; }
    }
}
