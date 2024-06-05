using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apdb9.Models;

public class PrescriptionMedicament
{
    public int IdMedicament { get; set; }
    [ForeignKey(nameof(IdMedicament))] public Medicament Medicament { get; set; } 

    public int IdPrescription { get; set; }
    [ForeignKey(nameof(IdPrescription))] private Prescription _prescription { get; set; }
    
    public int Dose { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Details { get; set; } = null!;

}