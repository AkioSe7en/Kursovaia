using System.Windows;

namespace Куровичок_Осокин.Requests;

public partial class Zapros5 : Window
{
    ApplicationContext db = new ApplicationContext();
    public Zapros5()
    {
        InitializeComponent();
        CheckBD();
    }
    void CheckBD()
    {
        var Zapros = db.Applicants.Where(p=>p.Activ==false).ToList();
        DataGrid.ItemsSource = Zapros;
    }
    
    private void Create_OnClick(object sender, RoutedEventArgs e)
    {
        Zap3_Add add = new Zap3_Add(db);
        add.ShowDialog();
        CheckBD();
    }

    private void Delete_OnClick(object sender, RoutedEventArgs e)
    {
        for (var i = 0; i < DataGrid.SelectedItems.Count; i++)
        {
            db.Applicants.Remove((Applicants)DataGrid.SelectedItems[i]!);
        }
        db.SaveChanges();
        CheckBD();
    }

    private void DataGrid_OnRowEditEnding(object? sender, DataGridRowEditEndingEventArgs e)
    {
        db.SaveChanges();
        CheckBD();
    }
}