﻿using System.Windows;

namespace Куровичок_Осокин;

public partial class Login : Window
{
    private ApplicationContext db = new ApplicationContext();
    public Login()
    {
        InitializeComponent();
    }

    private void Reg_OnClick(object sender, RoutedEventArgs e)
    {
        User_Add add = new User_Add();
        add.ShowDialog();
    }

    private void Auth_OnClick(object sender, RoutedEventArgs e)
    {
        var user = db.Users.Where(p => p.Login == LoginBox.Text).Where(p => p.Password == PasswordBox.Password)
            .ToList();

        if (user.Count==0)
        {
            MessageBox.Show("Неверный логин или пароль");
        }
        else
        {
            Login log;
            switch (user[0].Level)
            {
                case "2":
                    MainWindow Kons = new MainWindow();
                    Kons.Show();
                    log = this;
                    log.Close();
                    break;
                case "1":
                    Rekrut Rekr = new Rekrut();
                    Rekr.Show();
                    log = this;
                    log.Close();
                    break;
                default:
                    MessageBox.Show("Произошла непредвиденная ошибка. Обратитесь к системному администратору");
                    break;
            }
        }
    }
}