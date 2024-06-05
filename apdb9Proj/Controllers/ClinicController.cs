using apdb9.DTOs;
using apdb9.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace apdb9.Controllers;

[ApiController]
[Route("/api/clinic")]
public class ClinicController : ControllerBase
{

    private readonly IClinicService service;

    public ClinicController(IClinicService clinicService)
    {
        service = clinicService;
    }

    [HttpGet("doctors/{id:int}")]
    public async Task<IActionResult> GetDoctorAsync(int id)
    {
    return Ok(await service.GetDoctorAsync(id));
    }

    [HttpDelete("doctors/{id:int}")]
    public async Task<IActionResult> DeleteDoctorAsync(int id)
    {
        return Ok(await service.DeleteDoctorAsync(id));
    }

    [HttpPut("doctors")]
    public async Task<IActionResult> ModifyDoctorAsync(int id, DoctorModifiedDto dto)
    {
        return Ok(await service.ModifyDoctorAsync(id, dto));
    }

    [HttpPost("doctors")]
    public async Task<IActionResult> AddDoctorAsync([FromBody] DoctorDto dto)
    {
        return Ok(await service.AddDoctorAsync(dto));
    }

    [HttpGet("prescriptions/{id:int}")]
    public async Task<IActionResult> GetPrescriptionAsync(int id)
    {
        return Ok(await service.GetPrescriptionAsync(id));
    }
}