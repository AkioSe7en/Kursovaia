using System.Windows;

namespace Куровичок_Осокин.Forms;

public partial class Vac : Window
{
    ApplicationContext db = new ApplicationContext();

    private List<Vacancy> Zapros;
    private List<Professions> Prof;
    public Vac()
    {
        InitializeComponent();
        CheckBD();
    }
    
    void CheckBD()
    {
        Zapros = db.Vacancy.Include(u=>u.Employers).Include(z=>z.Professions).ToList();
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
        if (DataGrid.SelectedItem != null)
        {
            Zap1_Change change = new Zap1_Change(db, DataGrid.SelectedItem);
            change.ShowDialog();
            CheckBD();
        }
        else
        {
            MessageBox.Show("Запись не выбрана");
        }
    }
}