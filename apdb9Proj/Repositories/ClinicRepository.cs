using apdb9.Context;
using apdb9.DTOs;
using apdb9.Models;

namespace apdb9.Repositories;

public interface IClinicRepository
{
    public Task<Doctor> GetDoctorAsync(int id);
    public Task<bool> DeleteDoctorAsync();
    public Task<bool> ModifyDoctorAsync();
    public Task<bool> AddDoctorAsync(DoctorDto dto);
    public Task<PrescriptionDto> GetPrescriptionAsync();
 
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
        return _context.Doctors.First(doctor => doctor.IdDoctor == id);
    }

    public async Task<bool> DeleteDoctorAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ModifyDoctorAsync()
    {
        throw new NotImplementedException();
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

    public async Task<PrescriptionDto> GetPrescriptionAsync()
    {
        throw new NotImplementedException();
    }
}