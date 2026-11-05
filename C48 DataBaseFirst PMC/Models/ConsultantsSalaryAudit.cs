using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace C48_DatabaseFirst_PMC.Models;

[Table("ConsultantsSalaryAudit")]
public partial class ConsultantsSalaryAudit
{
    [Key]
    public int AuditId { get; set; }

    public int? ConsultantId { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? OldSalary { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? NewSalary { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ActionDate { get; set; }
}
