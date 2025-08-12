namespace TWValidacao.ViewModels;

public class CreateUserViewModelFluentValidadtion
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public DateTime BirthDate { get; set; }

    public string PhoneNumber { get; set; } = string.Empty;

    public string ProfilePicture { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string PasswordConfirmation { get; set; } = string.Empty;
}