using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace C48_DatabaseFirst_PMC.Models;

[Table("EmployeesG02")]
[Index("Name", Name = "IX_EmployeeName")]
[Index("Name", Name = "UX_Employees_Name", IsUnique = true)]
public partial class EmployeesG02
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Salary { get; set; }

    public int? Age { get; set; }
}
