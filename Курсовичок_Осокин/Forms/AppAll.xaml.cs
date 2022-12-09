using System.Windows;

namespace Куровичок_Осокин.Forms;

public partial class AppAll : Window
{
    ApplicationContext db = new ApplicationContext();
    public AppAll()
    {
        InitializeComponent();
        CheckBD();
    }
    void CheckBD()
    {
        var Zapros = db.Applicants.ToList();
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