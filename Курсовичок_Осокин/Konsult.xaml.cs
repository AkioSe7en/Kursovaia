namespace Курсовичок_Осокин
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db = new ApplicationContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        //_______________Вкладка "Формы"_________________________________________
        private void ButProf_OnClick(object sender, RoutedEventArgs e)
        {
            if (db.Database.CanConnect())
            {
                Prof win = new Prof();
                win.Show();
            }
        }
        private void ButApp_OnClick(object sender, RoutedEventArgs e)
        {
            if (db.Database.CanConnect())
            {
                App win = new App();
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

        private void ButDip_OnClick(object sender, RoutedEventArgs e)
        {
            if (db.Database.CanConnect())
            {
                Dip win = new Dip();
                win.Show();
            }
        }

        private void ButEmp_OnClick(object sender, RoutedEventArgs e)
        {
            if (db.Database.CanConnect())
            {
                Emp win = new Emp();
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

        private void ButVac_OnClick(object sender, RoutedEventArgs e)
        {
            if (db.Database.CanConnect())
            {
                Vac win = new Vac();
                win.Show();
            }
        }
     
        //_________________Вкладка "Запросы"______________________________
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

        private void Zap3_OnClick(object sender, RoutedEventArgs e)
        {
            if (db.Database.CanConnect())
            {
                Zapros3 zap3 = new Zapros3();
                zap3.Show();
            }
        }

        private void Zap4_OnClick(object sender, RoutedEventArgs e)
        {
            if (db.Database.CanConnect())
            {
                Zapros4 zap4 = new Zapros4();
                zap4.Show();
            }
        }

        private void Zap5_OnClick(object sender, RoutedEventArgs e)
        {
            if (db.Database.CanConnect())
            {
                Zapros5 zap5 = new Zapros5();
                zap5.Show();
            }
        }

        private void Zap6_OnClick(object sender, RoutedEventArgs e)
        {
            if (db.Database.CanConnect())
            {
                Zapros6 zap6 = new Zapros6();
                zap6.Show();
            }
        }
        
        //_____________________Вкладка "Функционал"__________________________________
       private void DeleteNoActiv_OnClick(object sender, RoutedEventArgs e)
        {
            if (db.Database.CanConnect())
            {
                int DelAp = db.Applicants.Where(p => p.Activ == false).Where(p=>p.DateDelete < DateTime.Now.AddMonths(-3)).ExecuteDelete();
                int DelEmp = db.Employers.Where(p => p.Activ == false).Where(p=>p.DateDelete < DateTime.Now.AddMonths(-3)).ExecuteDelete();
                int DelVac = db.Vacancy.Where(p => p.Activ == false).Where(p=>p.DateDelete < DateTime.Now.AddMonths(-3)).ExecuteDelete();
                MessageBox.Show("Удалено:\n" + DelAp + " анкет соискателей\n" + DelEmp + " анкет работодателей\n" +
                                DelVac + " вакансий\n");
            }
        }

        private void Users_OnClick(object sender, RoutedEventArgs e)
        {
            UsersList adduser = new UsersList();
            adduser.Show();
        }
    }
}