namespace Курсовичок_Осокин.Tables;

public class Vacancy
{
    public Guid Id_Vac { get; }
    public Professions Professions { get; set; }
    public Employers Employers { get; set; }
    public DateTime Date_Create { get; } = DateTime.Now;
    public double Salary { get; set; }
}