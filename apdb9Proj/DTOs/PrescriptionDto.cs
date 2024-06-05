using apdb9.Models;

namespace apdb9.DTOs;

public class PrescriptionDto
{
    public Prescription _prescription { get; set; }
    public Doctor _doctor{ get; set; }
    public Patient _patient{ get; set; }
}