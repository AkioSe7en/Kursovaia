namespace Куровичок_Осокин.Requests;
public partial class Zapros1 : Window
{
    ApplicationContext db = new ApplicationContext();
    private string like;
    public Zapros1(string Like)
    {
        InitializeComponent();
        like = Like;
        var Zapros = db.Vacancy.Include(u=>u.Employers).Include(z=>z.Professions)
            .Where(p=>EF.Functions.Like(p.Professions.Prof_Name, "%"+like+"%")).Where(u=>u.Employers.Activ==true)
            .Select(p=> new 
                {
                    Id_Vac = p.Id_Vac,
                    Vacancy = p.Professions.Prof_Name, 
                    Salary = p.Salary+" руб.",
                    Create = p.Date_Create.ToShortDateString(),
                    Org = p.Employers.Name_Org,
                    FIO = p.Employers.FIO,
                    Phone = p.Employers.Phone,
                    Address = p.Employers.Address,
                    Activ = p.Employers.Activ,
                }).ToList();
        DataGrid.ItemsSource = Zapros;
    }

}