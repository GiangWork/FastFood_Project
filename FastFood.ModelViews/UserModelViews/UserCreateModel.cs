namespace FastFood.ModelViews.UserModelViews;

public class UserCreateModel
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public string Gender { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
}
