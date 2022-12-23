using System.Windows;

namespace Куровичок_Осокин.Forms;

public partial class UsersList : Window
{
    ApplicationContext db = new ApplicationContext();
    public UsersList()
    {
        InitializeComponent();
        CheckBD();
    }
    
    void CheckBD()
    {
        var Zapros = db.Users.ToList();
        DataGrid.ItemsSource = Zapros;
    }
    
    private void DataGrid_OnRowEditEnding(object? sender, DataGridRowEditEndingEventArgs e)
    {
        db.SaveChanges();
        CheckBD();
    }

    private void AddUser_OnClick(object sender, RoutedEventArgs e)
    {
        User_Add_Kons Add = new User_Add_Kons();
        Add.ShowDialog();
        CheckBD();
    }

    private void DeleteUser_OnClick(object sender, RoutedEventArgs e)
    {
        for (var i = 0; i < DataGrid.SelectedItems.Count; i++)
        {
            if (((Users)DataGrid.SelectedItems[i]).Login != "Admin")
            db.Users.Remove((Users)DataGrid.SelectedItems[i]!);
            else
            {
                MessageBox.Show("Вы не можете удалить первоначальную роль Admin");
            }
        }
        db.SaveChanges();
        CheckBD();
    }
}