using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C48_EFCore_Session_04.Models
{
    public class CourseStudent
    {
        public int CourseId { get; set; }
        public virtual Course Course { get; set; } = null!;

        public int StudentId { get; set; }
        public virtual Student Student { get; set; } = null!;
    }
}
