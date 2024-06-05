using System.ComponentModel.DataAnnotations;

namespace apdb9.DTOs;

public class PatientDto
{
    [MaxLength(100)]
    [Required]
    public string FirstName { get; set; } = null!;
    
    [MaxLength(100)]
    [Required]
    public string LastName { get; set; } = null!;

    public DateTime birthday { get; set; }
}