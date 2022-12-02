namespace Курсовичок_Осокин.Tables;

public class Employers
{
    public Guid ID_Rab { get; }
    public string FIO { get; set; } = null!;
    [MaxLength(11, ErrorMessage = "Максимальное количество символов")] public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string Name_Org { get; set; } = null!;
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
    public List<Vacancy> Vacancies { get; set; }
}