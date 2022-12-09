using System.Windows;

namespace Куровичок_Осокин.Forms;

public partial class EmpAll : Window
{
    ApplicationContext db = new ApplicationContext();
    public EmpAll()
    {
        InitializeComponent();
        CheckBD();
    }
    void CheckBD()
    {
        var Zapros = db.Employers.ToList();
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