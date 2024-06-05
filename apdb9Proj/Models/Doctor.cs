using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace apdb9.Models;

public class Doctor
{
    [Key]
    public int IdDoctor { get; set; }

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
    
    private ICollection<Prescription> Prescriptions { get; set; }
    
    
}