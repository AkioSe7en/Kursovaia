namespace Куровичок_Осокин.Tables;

public class Vacancy
{
    public Guid Id_Vac { get; set; }
    public Guid ID_Rab { get; set; }
    public string Name { get; set; }
    public DateTime Date_Create { get; set; }
    public float Salary { get; set; }
}