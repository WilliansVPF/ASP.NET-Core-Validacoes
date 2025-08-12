using System.ComponentModel.DataAnnotations;

namespace TWValidacao.Attributes;

public class AgeBetweenAttribute : ValidationAttribute
{

    public int Min { get; }
    public int Max { get; }

    public AgeBetweenAttribute(int max, int min = 0)
    {
        Min = min;
        Max = max;
    }

    public override bool IsValid(object? value)
    {
        if (value is null) return true;

        var birthDate = Convert.ToDateTime(value);
        var age = CalculateAge(birthDate);

        return age >= Min && age <= Max;
    }

    private int CalculateAge(DateTime birthDate)
    {
        var today = DateTime.Today;
        var age = today.Year - birthDate.Year;

        if (birthDate.Date > today.AddYears(-age)) age--;

        return age;
    }
}

