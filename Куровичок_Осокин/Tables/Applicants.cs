namespace Куровичок_Осокин.Tables;

public class Applicants
{
    public Guid Id_Soisk { get; set; }
    public string Familia { get; set; }
    public string Name { get; set; }
    public string Otchestvo { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Prof_Name { get; set; }
    public bool Activ { get; set; }
    public DateTime DateDelete { get; set; }
}