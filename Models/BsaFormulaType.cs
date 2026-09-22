using System.ComponentModel.DataAnnotations;

namespace SubjectBSACalculation.Models;

/// <summary>Supported BSA formulas.</summary>
public enum BsaFormulaType
{
    [Display(Name = "-Select One-")]
    SelectOne = 0,

    [Display(Name = "Du Bois")]
    DuBois = 1,

    [Display(Name = "Mosteller")]
    Mosteller = 2
}
