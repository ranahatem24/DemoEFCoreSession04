using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C48_EFCore_Session_04.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        // علاقة 1 إلى متعدد: القسم الواحد يحتوي على عدة موظفين
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

        // علاقة أن القسم له مدير واحد (Employee)، وهو اختياري (Nullable)
        public int? ManagerId { get; set; }
        public virtual Employee? Manager { get; set; }
    }
}
