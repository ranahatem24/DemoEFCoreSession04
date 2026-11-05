using System;
using System.Collections.Generic;
using C48_DatabaseFirst_PMC.Models;
using Microsoft.EntityFrameworkCore;

namespace C48_DatabaseFirst_PMC.DbContexts;

public partial class HospitalContext : DbContext
{
    public HospitalContext()
    {
    }

    public HospitalContext(DbContextOptions<HospitalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Consultant> Consultants { get; set; }

    public virtual DbSet<ConsultantsSalaryAudit> ConsultantsSalaryAudits { get; set; }

    public virtual DbSet<DeletedPatient> DeletedPatients { get; set; }

    public virtual DbSet<Drug> Drugs { get; set; }

    public virtual DbSet<DrugAdministration> DrugAdministrations { get; set; }

    public virtual DbSet<DrugBrand> DrugBrands { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeesG02> EmployeesG02s { get; set; }

    public virtual DbSet<Nurse> Nurses { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PatientConsultantAssignment> PatientConsultantAssignments { get; set; }

    public virtual DbSet<PatientHeap> PatientHeaps { get; set; }

    public virtual DbSet<PatientHeapG02> PatientHeapG02s { get; set; }

    public virtual DbSet<VwIndexedConsultantInformationG01> VwIndexedConsultantInformationG01s { get; set; }

    public virtual DbSet<VwIndexedConsultantInformationG02> VwIndexedConsultantInformationG02s { get; set; }

    public virtual DbSet<VwPatientAssignedToWard> VwPatientAssignedToWards { get; set; }

    public virtual DbSet<VwPatientBasicInformationG01> VwPatientBasicInformationG01s { get; set; }

    public virtual DbSet<VwPatientBasicInformationG02> VwPatientBasicInformationG02s { get; set; }

    public virtual DbSet<VwPatientBasicInformationG03> VwPatientBasicInformationG03s { get; set; }

    public virtual DbSet<VwPatientDrug> VwPatientDrugs { get; set; }

    public virtual DbSet<VwPatientDrugsG01> VwPatientDrugsG01s { get; set; }

    public virtual DbSet<VwPatientWithWardInformation> VwPatientWithWardInformations { get; set; }

    public virtual DbSet<VwPatientsAssignedToWard> VwPatientsAssignedToWards { get; set; }

    public virtual DbSet<VwPatientsAssinedToWardsG02> VwPatientsAssinedToWardsG02s { get; set; }

    public virtual DbSet<VwPatientsDrugsG02> VwPatientsDrugsG02s { get; set; }

    public virtual DbSet<VwPatientsWithWardInformation> VwPatientsWithWardInformations { get; set; }

    public virtual DbSet<VwPatientsWithWardInformationG01> VwPatientsWithWardInformationG01s { get; set; }

    public virtual DbSet<Ward> Wards { get; set; }

    public virtual DbSet<WvIndexedConsultantInformation> WvIndexedConsultantInformations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;DataBase=Hospital;Trusted_Connection=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Consultant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Consulta__3214EC07C7B23124");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<ConsultantsSalaryAudit>(entity =>
        {
            entity.HasKey(e => e.AuditId).HasName("PK__Consulta__A17F239847BBC5BA");
        });

        modelBuilder.Entity<Drug>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__Drug__A25C5AA675E6519A");

            entity.Property(e => e.Code).ValueGeneratedNever();
        });

        modelBuilder.Entity<DrugAdministration>(entity =>
        {
            entity.HasKey(e => new { e.NurseId, e.DrugCode, e.PatientId, e.Date, e.Time }).HasName("PK_Gives");

            entity.HasOne(d => d.DrugCodeNavigation).WithMany(p => p.DrugAdministrations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Gives_Drug");

            entity.HasOne(d => d.Nurse).WithMany(p => p.DrugAdministrations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Gives_Nurse");

            entity.HasOne(d => d.Patient).WithMany(p => p.DrugAdministrations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Gives_Patient");
        });

        modelBuilder.Entity<DrugBrand>(entity =>
        {
            entity.HasKey(e => new { e.DrugCode, e.Brand }).HasName("PK_DrugBrand");

            entity.HasOne(d => d.DrugCodeNavigation).WithMany(p => p.DrugBrands).HasConstraintName("FK_DrugBrand_Drug");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasIndex(e => e.Namee, "Ix_Employee_Name").IsClustered();
        });

        modelBuilder.Entity<EmployeesG02>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC0706664606");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Nurse>(entity =>
        {
            entity.HasKey(e => e.Number).HasName("PK__Nurse__78A1A19C115514F9");

            entity.Property(e => e.Number).ValueGeneratedNever();

            entity.HasOne(d => d.ServesInWard).WithMany(p => p.NurseServesInWards).HasConstraintName("FK__Nurse__ServesInW__4BAC3F29");

            entity.HasOne(d => d.SupervisedWard).WithMany(p => p.NurseSupervisedWards).HasConstraintName("FK__Nurse__Supervise__4AB81AF0");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Patient__3214EC073485B1E6");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Ward).WithMany(p => p.Patients).HasConstraintName("FK__Patient__WardId__49C3F6B7");

            entity.HasMany(d => d.Consultants).WithMany(p => p.Patients)
                .UsingEntity<Dictionary<string, object>>(
                    "PatientExamination",
                    r => r.HasOne<Consultant>().WithMany()
                        .HasForeignKey("ConsultantId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FKamine_Consultant"),
                    l => l.HasOne<Patient>().WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Examine_Patient"),
                    j =>
                    {
                        j.HasKey("PatientId", "ConsultantId").HasName("PK_Examine");
                        j.ToTable("PatientExaminations");
                    });
        });

        modelBuilder.Entity<PatientConsultantAssignment>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK_PatientConsultantAssignments_1");

            entity.Property(e => e.PatientId).ValueGeneratedNever();

            entity.HasOne(d => d.Consultant).WithMany(p => p.PatientConsultantAssignments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assigned_Consultant");

            entity.HasOne(d => d.Patient).WithOne(p => p.PatientConsultantAssignment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assigned_Patient");
        });

        modelBuilder.Entity<VwIndexedConsultantInformationG01>(entity =>
        {
            entity.ToView("vw_IndexedConsultantInformationG01");
        });

        modelBuilder.Entity<VwIndexedConsultantInformationG02>(entity =>
        {
            entity.ToView("VW_IndexedConsultantInformationG02");
        });

        modelBuilder.Entity<VwPatientAssignedToWard>(entity =>
        {
            entity.ToView("vw_PatientAssignedToWards");
        });

        modelBuilder.Entity<VwPatientBasicInformationG01>(entity =>
        {
            entity.ToView("vw_PatientBasicInformationG01");
        });

        modelBuilder.Entity<VwPatientBasicInformationG02>(entity =>
        {
            entity.ToView("VW_PatientBasicInformationG02");
        });

        modelBuilder.Entity<VwPatientBasicInformationG03>(entity =>
        {
            entity.ToView("vw_PatientBasicInformationG03");
        });

        modelBuilder.Entity<VwPatientDrug>(entity =>
        {
            entity.ToView("vw_PatientDrugs");
        });

        modelBuilder.Entity<VwPatientDrugsG01>(entity =>
        {
            entity.ToView("vw_PatientDrugsG01");
        });

        modelBuilder.Entity<VwPatientWithWardInformation>(entity =>
        {
            entity.ToView("VW_PatientWithWardInformation");
        });

        modelBuilder.Entity<VwPatientsAssignedToWard>(entity =>
        {
            entity.ToView("vw_PatientsAssignedToWard");
        });

        modelBuilder.Entity<VwPatientsAssinedToWardsG02>(entity =>
        {
            entity.ToView("VW_PatientsAssinedToWardsG02");
        });

        modelBuilder.Entity<VwPatientsDrugsG02>(entity =>
        {
            entity.ToView("VW_PatientsDrugsG02");
        });

        modelBuilder.Entity<VwPatientsWithWardInformation>(entity =>
        {
            entity.ToView("VW_PatientsWithWardInformation");
        });

        modelBuilder.Entity<VwPatientsWithWardInformationG01>(entity =>
        {
            entity.ToView("vw_PatientsWithWardInformationG01");
        });

        modelBuilder.Entity<Ward>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ward__3214EC070D021CBC");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<WvIndexedConsultantInformation>(entity =>
        {
            entity.ToView("wv_IndexedConsultantInformation");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
