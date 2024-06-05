using System.ComponentModel.DataAnnotations;

namespace apdb9.DTOs;

public class DoctorDto
{
    [MaxLength(100)]
    [Required]
    public string FirstName { get; set; } = null!;

    [MaxLength(100)]
    [Required]
    public string LastName { get; set; } = null!;
    
    [MaxLength(100)]
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
}

public class DoctorModifiedDto
{
    [MaxLength(100)]
    public string FirstName { get; set; } = null!;

    [MaxLength(100)]
    public string LastName { get; set; } = null!;
    
    [MaxLength(100)]
    [EmailAddress]
    public string Email { get; set; } = null!;
}