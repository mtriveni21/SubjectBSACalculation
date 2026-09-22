using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SubjectBSACalculation.Models;

/// <summary>
/// Subject record. Fields declaration
/// </summary>
public class Subject
{
    public int SubjectId { get; set; }

    /// <summary> SubjectId swquence from, e.g. 1 -> "001".</summary>
    [NotMapped]
    [Display(Name = "Subject ID")]
    public string SubjectCode => SubjectId.ToString("D3");

    [Required]
    [Range(20, 300, ErrorMessage = "Please enter the Height between 20 and 300 cm.")]
    [Display(Name = "Height (cm)")]
    public double HeightCm { get; set; }

    [Required]
    [Range(1, 500, ErrorMessage = "Please enter the Weight between 1.00 and 300.00 kg.")]
    [Display(Name = "Weight (kg)")]
    public double WeightKg { get; set; }

    [Required]
    [StringLength(20)]
    public string Gender { get; set; } = string.Empty;

    [Required]
    [Range(1, 100, ErrorMessage = "Please enter the Age between 1 and 100.")]
    public int Age { get; set; }

    [Required]
    [Range(1, 2, ErrorMessage = "Please select a valid BSA Formula.")]
    [Display(Name = "BSA Formula")]
    public BsaFormulaType BsaFormulaType { get; set; }

    /// <summary>Computed BSA in m^2 (caluclated).</summary>
    public double BsaResult { get; set; }

    public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
}
