namespace Куровичок_Осокин;

public partial class Rekrut : Window
{
    ApplicationContext db = new ApplicationContext();
    public Rekrut()
    {
        InitializeComponent();
    }
    
    private void ButProf_OnClick(object sender, RoutedEventArgs e)
        {
            if (db.Database.CanConnect())
            {
                Prof win = new Prof();
                win.Show();
            }
        }

        private void ButAppAll_OnClick(object sender, RoutedEventArgs e)
        {
            if (db.Database.CanConnect())
            {
                AppAll win = new AppAll();
                win.Show();
            }
        }
    
        private void ButEmpAll_OnClick(object sender, RoutedEventArgs e)
        {
            if (db.Database.CanConnect())
            {
                EmpAll win = new EmpAll();
                win.Show();
            }
        }

        private void Zap1_OnClick(object sender, RoutedEventArgs e)
        {
            if (db.Database.CanConnect())
            {
                TempZap1 tempZap1 = new TempZap1();
                tempZap1.ShowDialog();
            }
        }

        private void Zap2_OnClick(object sender, RoutedEventArgs e)
        {
            if (db.Database.CanConnect())
            {
                TempZap2 tempZap2 = new TempZap2();
                tempZap2.ShowDialog();
            }
        }
}