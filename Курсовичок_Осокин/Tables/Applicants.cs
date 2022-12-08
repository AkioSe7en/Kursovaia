namespace Курсовичок_Осокин.Tables;
    
public class Applicants
{
    public Guid ID_App { get; set; }
    public string Familia { get; set; }
    public string Name { get; set; }
    public string Otchestvo { get; set; }
    [MaxLength(11, ErrorMessage = "Максимальное количество символов")] public string? Phone { get; set; }
    public string? Email { get; set; }
    private bool activ = true;

    public bool Activ
    {
        get { return activ;}
        set
        {
            activ = value;
            if (activ == false)
            {
                DateDelete = DateTime.Now;
            }
            else
            {
                DateDelete = null;
            }
        }
    }
    public DateTime? DateDelete { get; set; }

    public List<Diploma> Diplomas { get; set; } = new();
    public Professions Professions { get; set; }
}