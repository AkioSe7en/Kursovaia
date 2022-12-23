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
            .Where(p=>EF.Functions.Like(p.Address, "%"+Like+"%")).Where(p=>p.Activ==true).ToList();
        DataGrid.ItemsSource = Zapros;
    }

    private void DataGrid_OnRowEditEnding(object? sender, DataGridRowEditEndingEventArgs e)
    {
        db.SaveChanges();
        CheckBD();
    }

    private void Create_OnClick(object sender, RoutedEventArgs e)
    {
        Zap2_Add add = new Zap2_Add(db);
        add.ShowDialog();
        CheckBD();
    }

    private void Delete_OnClick(object sender, RoutedEventArgs e)
    {
        for (var i = 0; i < DataGrid.SelectedItems.Count; i++)
        {
            ((Employers)DataGrid.SelectedItems[i]).Activ = false;
        }
        db.SaveChanges();
        CheckBD();
    }
}