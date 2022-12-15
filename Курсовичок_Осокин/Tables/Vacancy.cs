namespace Курсовичок_Осокин.Tables;

public class Vacancy
{
    public Guid Id_Vac { get; }
    public Professions Professions { get; set; }
    public Employers Employers { get; set; }
    public DateTime Date_Create { get; } = DateTime.Now;
    public double Salary { get; set; }
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
}