using System.Windows;

namespace Куровичок_Осокин.TempWindows;

public partial class User_Add_Kons : Window
{
    ApplicationContext db = new ApplicationContext();
    public User_Add_Kons()
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

        if (check == 0)
        {
            if (!string.IsNullOrWhiteSpace(Login.Text) &&
                !string.IsNullOrWhiteSpace(Password.Text) &&
                !string.IsNullOrWhiteSpace(Level.Text))
            {
                if (Level.Text == "1 - Рекрутер")
                {
                    db.Users.Add(new Users { Login = Login.Text, Password = Password.Text, Level = "1" });
                }
                else
                {
                    db.Users.Add(new Users { Login = Login.Text, Password = Password.Text, Level = "2" });
                }

                db.SaveChanges();
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Одно из полей не заполнено");
            }
        }

    }
}