namespace Куровичок_Осокин.Requests;
public partial class Zapros1 : Window
{
    ApplicationContext db = new ApplicationContext();
    private string like;
    public Zapros1(string Like)
    {
        InitializeComponent();
        like = Like;
        var Zapros = db.Vacancy.Include(u=>u.Employers).Include(z=>z.Professions).Where(p=>EF.Functions.Like(p.Professions.Prof_Name, "%"+like+"%")).ToList(); //Cars.Where(p => p.Name == "Alfa Romeo").Where(p => p.IsStock == true).ToList();
        foreach (var z1 in Zapros)
        {
            TextBox.Text += z1.Employers.FIO;
            TextBox.Text += z1.Employers.Name_Org;
            TextBox.Text += z1.Id_Vac;
            TextBox.Text += z1.Professions.Prof_Name;
            TextBox.Text += z1.Salary;
            TextBox.Text += z1.Date_Create;
            TextBox.Text=$"{z1.Employers.FIO} {z1.Employers.Name_Org} {z1.Id_Vac} {z1.Professions.Prof_Name} {z1.Salary} {z1.Date_Create}\n";
        }
    }
    
}