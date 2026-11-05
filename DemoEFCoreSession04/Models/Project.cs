using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C48_EFCore_Session_04.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string PName { get; set; } = null!;

        // علاقة جدول الوسيط مع الموظفين
        public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; } = new HashSet<EmployeeProject>();
    }
}
