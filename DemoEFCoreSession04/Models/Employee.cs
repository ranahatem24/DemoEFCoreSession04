using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C48_EFCore_Session_04.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Salary { get; set; }

        // علاقة أن الموظف يعمل في قسم واحد
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; } = null!;

        // خاصية عكسية لمدير القسم (في حال كان هذا الموظف مديراً لقسم ما)
        public virtual Department? ManagedDepartment { get; set; }

        // علاقة جدول الوسيط مع المشاريع
        public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; } = new HashSet<EmployeeProject>();
    }
}
