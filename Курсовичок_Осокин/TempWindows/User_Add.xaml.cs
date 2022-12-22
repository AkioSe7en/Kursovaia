using System.Windows;

namespace Куровичок_Осокин.TempWindows;

public partial class User_Add : Window
{
    ApplicationContext db = new ApplicationContext();
    public User_Add()
    {
        InitializeComponent();
    }

    private void OK_OnClick(object sender, RoutedEventArgs e)
    {
        int check = 0;
        foreach (var users in db.Users.ToList())
        {
            if (users.Login.ToLower() == Login.Text.ToLower())
            {
                MessageBox.Show("Такой пользователь уже существует");
                check++;
                break;
            }
        }
        if (check==0)
        {
            db.Users.Add(new Users { Login = Login.Text, Password = Password.Text, Level = "1" });
            db.SaveChanges();
            DialogResult = true;
        }
        
    }
}