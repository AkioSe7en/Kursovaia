namespace Куровичок_Осокин.Requests;

public partial class Zapros1 : Window
{
    ApplicationContext db = new ApplicationContext();
    private string Like;

    private List<Vacancy> Zapros;
    private List<Professions> Prof;

    public Zapros1(string Like)
    {
        InitializeComponent();
        this.Like = Like;
        CheckBD();

    }

    void CheckBD()
    {
        Zapros = db.Vacancy.Include(u=>u.Employers).Include(z=>z.Professions)
            .Where(p=>EF.Functions.Like(p.Professions.Prof_Name, "%"+Like+"%")).Where(u=>u.Employers.Activ==true)
            .ToList();
       // Prof = db.Professions.Include(p=>p.Vacancies).ToList();
       // Combo123.ItemsSource = Zapros;
        DataGrid.ItemsSource = Zapros;  
    }
    
    private void DataGrid_OnRowEditEnding(object? sender, DataGridRowEditEndingEventArgs e)
    {
        db.SaveChanges();
        CheckBD();
    }
}