namespace Куровичок_Осокин.Requests;
public partial class Zapros2 : Window
{
    ApplicationContext db = new ApplicationContext();
    private string Like;
    public Zapros2(string Like)
    {
        InitializeComponent();
        this.Like = Like;
        CheckBD();
    }
    void CheckBD()
    {
        var Zapros = db.Employers
            .Where(p=>EF.Functions.Like(p.Address, "%"+Like+"%")).ToList();
        DataGrid.ItemsSource = Zapros;
    }

    private void DataGrid_OnRowEditEnding(object? sender, DataGridRowEditEndingEventArgs e)
    {
        db.SaveChanges();
        CheckBD();
    }
}