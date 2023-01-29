namespace Scholarship_back.Outer.Models
{
    public class User
    { 
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public byte[] PasswordHash { get; set; } = new byte[32];
    public byte[] PasswordSalt { get; set; } = new byte[32];
    public DateTime Bday { get; set; }
    public string Role { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
}
}
