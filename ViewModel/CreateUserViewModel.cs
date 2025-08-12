using System.ComponentModel.DataAnnotations;
using TWValidacao.Attributes;

namespace TWValidacao.ViewModels;

public class CreateUserViewModel : IValidatableObject
{
    [Required(ErrorMessage = "Campo Obrigatório")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Deve ter entre 3 e 100 caracteres")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Campo Obrigatório")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Deve ter entre 3 e 100 caracteres")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Campo Obrigatório")]
    [StringLength(255, ErrorMessage = "Deve ter no maximo 255 caracteres")]
    [EmailAddress(ErrorMessage = "Formato de e-mail invalido")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Campo Obrigatório")]
    //[AgeBetween(100, 18, ErrorMessage = "A idade deve ser entre 18 e 100 anos")]
    public DateTime BirthDate { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório")]
    [Phone(ErrorMessage = "Formato de telefone invalido")]
    [RegularExpression("\\([0-9]{2}\\) [0-9]{1} [0-9]{4}-[0-9]{4}", ErrorMessage = "Formato de telefone invalido Ex.: (99) 9 9999-9999")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "Campo Obrigatório")]
    [Url(ErrorMessage = "Formato de URL invalido")]
    public string ProfilePicture { get; set; } = string.Empty;

    [Required(ErrorMessage = "Campo Obrigatório")]
    [StringLength(255, MinimumLength = 5, ErrorMessage = "Deve ter entre 5 e 255 caracteres")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Campo Obrigatório")]
    [StringLength(255, MinimumLength = 5, ErrorMessage = "Deve ter entre 5 e 255 caracteres")]
    [Compare(nameof(Password), ErrorMessage = "Senhas não conferem")]
    public string PasswordConfirmation { get; set; } = string.Empty;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var age = CalculateAge(BirthDate);
        Console.WriteLine(age);
        if (age < 18 || age > 100)
        {
            yield return new ValidationResult("A idade deve ser entre 18 e 100 anos", new[] { nameof(BirthDate) });
        }
    }
    
    private int CalculateAge(DateTime birthDate)
    {
        var today = DateTime.Today;
        var age = today.Year - birthDate.Year;

        if (birthDate.Date > today.AddYears(-age)) age--;

        return age;
    }
}
