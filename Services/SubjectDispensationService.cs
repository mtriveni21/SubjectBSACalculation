using SubjectBSACalculation.Models;

namespace SubjectBSACalculation.Services;

public interface ISubjectDispensationService
{
    /// <summary>Returns BSA in m^2. Weight in kg, height in cm.</summary>
    double CalculateDispensingBSA(BsaFormulaType formulaType, double weightKg, double heightCm);
}
public class SubjectDispensationService : ISubjectDispensationService
{
    public double CalculateDispensingBSA(BsaFormulaType formulaType, double weight_Kg, double height_Cm)
    {
        if (weight_Kg <= 0 || height_Cm <= 0)
            throw new ArgumentException("Weight and height must be positive.");

        double bsa = 0.0;
        if (formulaType == BsaFormulaType.DuBois)
        {
            bsa = 0.007184 * Math.Pow(weight_Kg, 0.425) * Math.Pow(height_Cm, 0.725);
        }
        else if (formulaType == BsaFormulaType.Mosteller)
        {
            bsa = 0.016667 * Math.Pow(weight_Kg, 0.5) * Math.Pow(height_Cm, 0.5);
        }   

        return Math.Round(bsa, 2);//just rounding off to the 2 points after decimal
    }
}