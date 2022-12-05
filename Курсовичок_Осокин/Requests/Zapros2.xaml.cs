namespace Куровичок_Осокин.Requests;

// public class Zapros
// {
//     public Guid Id { get; set; }
//     public string FIO { get; set; }
//     public string? Phone { get; set; } 
//     public string? Email { get; set; }
//     public string? Address { get; set; }
//     public string Org { get; set; }
//     public bool Activ { get; set; }
//     public DateTime? DateDelete { get; set; }
// }

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
    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        db.SaveChanges();
        CheckBD();

    }

    private void DataGrid_OnCellEditEnding(object? sender, DataGridCellEditEndingEventArgs e)
    {
        db.SaveChanges();
        CheckBD();
    }
}