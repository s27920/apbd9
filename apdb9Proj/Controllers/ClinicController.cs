using apdb9.DTOs;
using apdb9.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace apdb9.Controllers;

[ApiController]
[Route("/api/prescriptions")]
public class ClinicController : ControllerBase
{

    private readonly IClinicService service;

    public ClinicController(IClinicService clinicService)
    {
        service = clinicService;
    }

    [HttpGet]
    public async Task<IActionResult> GetDoctorAsync([FromRoute]int id)
    {
    return Ok(await service.GetDoctorAsync(id));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteDoctorAsync(int id)
    {
        return Ok(await service.DeleteDoctorAsync(id));
    }

    [HttpPut]
    public async Task<IActionResult> ModifyDoctorAsync(int id, DoctorModifiedDto dto)
    {
        return Ok(await service.ModifyDoctorAsync(id, dto));
    }

    [HttpPost]
    public async Task<IActionResult> AddDoctorAsync([FromBody] DoctorDto dto)
    {
        return Ok(await service.AddDoctorAsync(dto));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetPrescriptionAsync(int id)
    {
        return Ok(await service.GetPrescriptionAsync(id));
    }
}