using apdb9.DTOs;
using apdb9.Models;
using apdb9.Repositories;

namespace apdb9.Services;

public interface IClinicService
{
    public Task<Doctor> GetDoctorAsync(int id);
    public Task<bool> DeleteDoctorAsync();
    public Task<bool> ModifyDoctorAsync();
    public Task<bool> AddDoctorAsync(DoctorDto dto);

    public Task<PrescriptionDto> GetPrescriptionAsync(int id);


}

public class ClinicService : IClinicService
{
    private readonly IClinicRepository _repository;

    public ClinicService(IClinicRepository repository)
    {
        _repository = repository;
    }

    public async Task<Doctor> GetDoctorAsync(int id)
    {
        return await _repository.GetDoctorAsync(id);
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
        return await _repository.AddDoctorAsync(dto);
    }

    public async Task<PrescriptionDto> GetPrescriptionAsync(int id)
    {
        throw new NotImplementedException();
    }
}