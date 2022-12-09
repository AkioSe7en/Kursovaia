using System.Windows;

namespace Куровичок_Осокин.Requests;

public partial class Zapros6 : Window
{
    ApplicationContext db = new ApplicationContext();
    public Zapros6()
    {
        InitializeComponent();
        CheckBD();
    }
    void CheckBD()
    {
        var Zapros = db.Employers.Where(p=>p.Activ==false).ToList();
        DataGrid.ItemsSource = Zapros;
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
            db.Employers.Remove((Employers)DataGrid.SelectedItems[i]!);
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