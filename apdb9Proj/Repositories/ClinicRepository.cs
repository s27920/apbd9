using apdb9.Context;
using apdb9.DTOs;
using apdb9.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace apdb9.Repositories;

public interface IClinicRepository
{
    public Task<Doctor> GetDoctorAsync(int id);
    public Task<bool> DeleteDoctorAsync(int id);
    public Task<Doctor> ModifyDoctorAsync(int id, DoctorModifiedDto dto);
    public Task<bool> AddDoctorAsync(DoctorDto dto);
    public Task<PrescriptionDto> GetPrescriptionAsync(int id);
 
}

public class ClinicRepository : IClinicRepository
{
    private readonly ClinicContext _context;

    public ClinicRepository(ClinicContext context)
    {
        _context = context;
    }

    public async Task<Doctor> GetDoctorAsync(int id)
    {
        return await _context.Doctors.FirstAsync(doctor => doctor.IdDoctor == id);
    }

    public async Task<bool> DeleteDoctorAsync(int id)
    {
        var toDelete = new Doctor
        {
            IdDoctor = id
        };
        _context.Attach(toDelete);
        var entry = _context.Entry(toDelete);
        entry.State = EntityState.Deleted;
        return await _context.SaveChangesAsync()>1;
    }

    public async Task<Doctor> ModifyDoctorAsync(int id, DoctorModifiedDto dto)
    {
        var doctorToUpdate = new Doctor
        {
            IdDoctor = id
        };
        _context.Attach(doctorToUpdate);
        var entry = _context.Entry(doctorToUpdate);
        if (!dto.FirstName.IsNullOrEmpty())
        {
            doctorToUpdate.FirstName = dto.FirstName;
            entry.Property(p => p.FirstName).IsModified = true;
        }

        if (!dto.LastName.IsNullOrEmpty())
        {
            doctorToUpdate.LastName = dto.LastName;
            entry.Property(p => p.LastName).IsModified = true;
        }
        if (!dto.Email.IsNullOrEmpty())
        {
            doctorToUpdate.Email = dto.Email;
            entry.Property(p => p.Email).IsModified = true;
        }

        await _context.SaveChangesAsync();
        return doctorToUpdate;
    }

    public async Task<bool> AddDoctorAsync(DoctorDto dto)
    {
        await _context.AddAsync(new Doctor()
        {
            Email = dto.Email,
            FirstName = dto.FirstName,
            LastName = dto.LastName
        });
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<PrescriptionDto> GetPrescriptionAsync(int id)
    {
        var prescription = _context.Prescriptions.First(p => p.IdPrescription == id);
        return new PrescriptionDto()
                           {
                               _prescription = prescription,
                               _doctor = await _context.Doctors.FirstAsync(d => d.IdDoctor == prescription.IdDoctor),
                               _patient = await _context.Patients.FirstAsync(p => p.IdPatient == prescription.IdPrescription)
                           };
    }
    
    public static void Seed(ClinicContext context)
    {
        context.Database.EnsureCreated();
        if (context.Doctors.Any() || context.Patients.Any() || context.Medicaments.Any() || context.Prescriptions.Any())
        {
            return; 
        }
        var doctors = new Doctor[]
        {
            new Doctor { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" },
            new Doctor { FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com" }
        };
        var patients = new Patient[]
        {
            new Patient { FirstName = "Alice", LastName = "Johnson", birthday = DateTime.Parse("1980-01-01") },
            new Patient { FirstName = "Bob", LastName = "Brown", birthday = DateTime.Parse("1990-02-02") }
        };
        var medicaments = new Medicament[]
        {
            new Medicament { Name = "Aspirin", Description = "Pain reliever", Type = "Analgesic" },
            new Medicament { Name = "Amoxicillin", Description = "Antibiotic", Type = "Antibiotic" }
        };
        var prescriptions = new Prescription[]
        {
            new Prescription { Date = DateTime.Now, DueDate = DateTime.Now.AddDays(10), IdPatient = patients[0].IdPatient, IdDoctor = doctors[0].IdDoctor },
            new Prescription { Date = DateTime.Now, DueDate = DateTime.Now.AddDays(5), IdPatient = patients[1].IdPatient, IdDoctor = doctors[1].IdDoctor }
        };
        context.Doctors.AddRange(doctors);
        context.Patients.AddRange(patients);
        context.Medicaments.AddRange(medicaments);
        context.Prescriptions.AddRange(prescriptions);
        context.SaveChanges();
        
        var prescriptionMedicaments = new PrescriptionMedicament[]
        {
            new PrescriptionMedicament { IdMedicament = medicaments[0].IdMedicament, IdPrescription = prescriptions[0].IdPrescription, Dose = 100, Details = "Take one tablet daily" },
            new PrescriptionMedicament { IdMedicament = medicaments[1].IdMedicament, IdPrescription = prescriptions[1].IdPrescription, Dose = 200, Details = "Take two tablets daily" }
        };

        context.PrescriptionMedicaments.AddRange(prescriptionMedicaments);
        context.SaveChanges();
    }
}