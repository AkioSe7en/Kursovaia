using Куровичок_Осокин.TempWindows;

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
        DataGrid.ItemsSource = Zapros;  
    }
    
    private void DataGrid_OnRowEditEnding(object? sender, DataGridRowEditEndingEventArgs e)
    {
        db.SaveChanges();
        CheckBD();
    }

    private void Create_OnClick(object sender, RoutedEventArgs e)
    {
        Zap1_Add add = new Zap1_Add(db);
        add.ShowDialog();
        CheckBD();
    }

    private void Delete_OnClick(object sender, RoutedEventArgs e)
    {
        for (var i = 0; i < DataGrid.SelectedItems.Count; i++)
        {
            db.Vacancy.RemoveRange((Vacancy)DataGrid.SelectedItems[i]!);
        }
        db.SaveChanges();
        CheckBD();
    }

    private void Change_OnClick(object sender, RoutedEventArgs e)
    {
        Zap1_Change change = new Zap1_Change(db, DataGrid.SelectedItem);
        change.ShowDialog();
        CheckBD();
    }
}