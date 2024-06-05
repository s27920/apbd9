using apdb9.Services;
using Microsoft.AspNetCore.Mvc;

namespace apdb9.Controllers;

[ApiController]
[Route("/api/prescriptions")]
public class ClinicController : ControllerBase
{

    private readonly IClinicService _clinicService;

    public ClinicController(IClinicService clinicService)
    {
        _clinicService = clinicService;
    }

    [HttpGet]
    public Task<IActionResult> GetDoctorAsync()
    {
        
    }

    [HttpDelete]
    public Task<IActionResult> DeleteDoctorAsync()
    {
        
    }
    
    [HttpPut]
    public Task<IActionResult> ModifyDoctorAsync()
    {
        
    }
    
    [HttpPost]
    public Task<IActionResult> AddDoctorAsync()
    {
        
    }

    [HttpGet("{id:int}")]
    public Task<IActionResult> GetPrescriptionAsync()
    {
        
    }
}