using System.Windows;

namespace Куровичок_Осокин.Forms;

public partial class Prof : Window
{
    ApplicationContext db = new ApplicationContext();
    public Prof()
    {
        InitializeComponent();
        CheckBD();
    }

    void CheckBD()
    {
        DataGrid.ItemsSource = db.Professions.ToList();  
    }
    
    private void DataGrid_OnRowEditEnding(object? sender, DataGridRowEditEndingEventArgs e)
    {
        db.Professions.Update((Professions)DataGrid.SelectedItem);
        db.SaveChanges();
        CheckBD();
    }

    private void DataGrid_OnPreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Delete)
        {
            foreach (var z in DataGrid.SelectedItems)
            {
                db.Professions.Remove((Professions)z);  
            }
            db.SaveChanges();
        }
    }
}