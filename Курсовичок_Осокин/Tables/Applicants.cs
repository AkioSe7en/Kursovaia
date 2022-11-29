namespace Курсовичок_Осокин.Tables;
    
public class Applicants
{
    public Guid Id_App { get; set; }
    public string Familia { get; set; }
    public string Name { get; set; }
    public string Otchestvo { get; set; }
    [MaxLength(11, ErrorMessage = "Максимальное количество символов")] public string Phone { get; set; }
    public string Email { get; set; }
    public string Prof_Name { get; set; }
    public bool Activ { get; set; }
    public DateTime DateDelete { get; set; }
    
    public ICollection<Diploma> Diplomas { get; set; }
    public ICollection<Professions> ProfessionsCollection { get; set; }

    public Applicants()
    {
        Diplomas = new List<Diploma>(); 
        ProfessionsCollection = new List<Professions>();
    }
}