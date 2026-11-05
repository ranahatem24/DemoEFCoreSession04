using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C48_EFCore_Session_04.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        // علاقة جدول الوسيط مع الكورسات
        public virtual  ICollection<CourseStudent> CourseStudents { get; set; } = new HashSet<CourseStudent>();
    }
}
