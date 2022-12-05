using Куровичок_Осокин.Requests;

namespace Куровичок_Осокин.TempWindows;

public partial class TempZap2 : Window
{
    public TempZap2()
    {
        InitializeComponent();
    }
    private void Ok_OnClick(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
        Zapros2 zap = new Zapros2(VacText.Text); 
        zap.Show();
    }
}