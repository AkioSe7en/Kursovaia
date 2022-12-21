using System.Windows;

namespace Куровичок_Осокин.Forms;

public partial class Dip : Window
{
    ApplicationContext db = new ApplicationContext();
    public Dip()
    {
        InitializeComponent();
        CheckBD();
    }
    
    void CheckBD()
    {
        var Zapros = db.Diploma.Include(p=>p.Applicants).ToList();
            DataGrid.ItemsSource = Zapros;
    }

    private void Create_OnClick(object sender, RoutedEventArgs e)
    {
        Zap4_Add add = new Zap4_Add(db);
        add.ShowDialog();
        CheckBD();
    }

    private void Delete_OnClick(object sender, RoutedEventArgs e)
    {
        for (var i = 0; i < DataGrid.SelectedItems.Count; i++)
        {
            db.Diploma.Remove((Diploma)DataGrid.SelectedItems[i]!);
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