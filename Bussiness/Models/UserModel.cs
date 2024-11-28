namespace Bussiness.Models;

public class UserModel
{
    public string Id { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string CreatedAt { get; set; } = null!;

}
