namespace Курсовичок_Осокин.Tables;

public class Users
{
    public Guid UserID { get; set; }
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Level { get; set; } = null!;
}