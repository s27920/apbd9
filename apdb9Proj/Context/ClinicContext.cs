using apdb9.Models;
using Microsoft.EntityFrameworkCore;

namespace apdb9.Context;

public partial class ClinicContext : DbContext
{
    public ClinicContext(DbContextOptions options) : base(options)
    {
    }

    protected ClinicContext()
    {
    }

    public DbSet<Doctor> Doctors{get; set; }
    public DbSet<Medicament> Medicaments{get; set; }
    public DbSet<Patient> Patients{get; set; }
    public DbSet<Prescription> Prescriptions{get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PrescriptionMedicament>().HasKey(medicament => new { medicament.IdMedicament, medicament.IdPrescription });
    }
}