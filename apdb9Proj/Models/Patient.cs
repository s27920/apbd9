using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace apdb9.Models;

public class Patient
{
    [Key]
    public int IdPatient { get; set; }

    [MaxLength(100)]
    [Required]
    public string FirstName { get; set; } = null!;
    
    [MaxLength(100)]
    [Required]
    public string LastName { get; set; } = null!;

    public DateTime birthday { get; set; }

    private ICollection<Prescription> Prescriptions { get; set; }

}