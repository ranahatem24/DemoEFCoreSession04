using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace C48_DatabaseFirst_PMC.Models;

[Keyless]
[Index("Salary", Name = "X_EmployeeSalary")]
public partial class Employee
{
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Namee { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Salary { get; set; }

    public int? Age { get; set; }
}
