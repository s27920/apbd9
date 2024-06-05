using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace apdb9.Models;

public class Prescription
{
    [Key]
    public int IdPrescription { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
    
    [Required]
    public DateTime DueDate { get; set; }

    public ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

    public int IdPatient { get; set; }
    [ForeignKey(nameof(IdPatient))] public Patient patient { get; set; }
    
    public int IdDoctor { get; set; }
    [ForeignKey(nameof(IdDoctor))] public Doctor doctor { get; set; }

}