using System.Windows;
using Куровичок_Осокин.Requests;

namespace Куровичок_Осокин.TempWindows;

public partial class TempZap1 : Window
{
    public TempZap1()
    {
        InitializeComponent();
    }
    private void Ok_OnClick(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
        Zapros1 zap1 = new Zapros1(VacText.Text); 
        zap1.Show();
    }
}