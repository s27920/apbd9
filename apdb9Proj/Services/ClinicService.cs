using apdb9.DTOs;
using apdb9.Models;
using apdb9.Repositories;

namespace apdb9.Services;

public interface IClinicService
{
    public Task<Doctor> GetDoctorAsync(int id);
    public Task<bool> DeleteDoctorAsync(int id);
    public Task<Doctor> ModifyDoctorAsync(int id, DoctorModifiedDto dto);
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

    public async Task<bool> DeleteDoctorAsync(int id)
    {
        return await _repository.DeleteDoctorAsync(id);
    }

    public async Task<Doctor> ModifyDoctorAsync(int id, DoctorModifiedDto dto)
    {
        return await _repository.ModifyDoctorAsync(id, dto);
    }

    public async Task<bool> AddDoctorAsync(DoctorDto dto)
    {
        return await _repository.AddDoctorAsync(dto);
    }

    public async Task<PrescriptionDto> GetPrescriptionAsync(int id)
    {
        return await _repository.GetPrescriptionAsync(id);
    }
}