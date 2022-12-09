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
            if (db.Database.CanConnect())
                CheckBD.Text = "БД создана";
            else
            {
                CheckBD.Text = "БД не создана";
            }
        }

        //_______________Вкладка "Формы"_________________________________________
        private void ButProf_OnClick(object sender, RoutedEventArgs e)
        {
            Prof win = new Prof();
            win.Show();
        }
        private void ButApp_OnClick(object sender, RoutedEventArgs e)
        {
            App win = new App();
            win.Show();
        }

        private void ButAppAll_OnClick(object sender, RoutedEventArgs e)
        {
            AppAll win = new AppAll();
            win.Show();
        }

        private void ButDip_OnClick(object sender, RoutedEventArgs e)
        {
            Dip win = new Dip();
            win.Show();
        }

        private void ButEmp_OnClick(object sender, RoutedEventArgs e)
        {
            Emp win = new Emp();
            win.Show();
        }

        private void ButEmpAll_OnClick(object sender, RoutedEventArgs e)
        {
            EmpAll win = new EmpAll();
            win.Show();
        }

        private void ButVac_OnClick(object sender, RoutedEventArgs e)
        {
            Vac win = new Vac();
            win.Show();
        }
     
        //_________________Вкладка "Запросы"______________________________
        private void Zap1_OnClick(object sender, RoutedEventArgs e)
        {

            TempZap1 tempZap1 = new TempZap1();
            tempZap1.ShowDialog();
        }

        private void Zap2_OnClick(object sender, RoutedEventArgs e)
        {
            TempZap2 tempZap2 = new TempZap2();
            tempZap2.ShowDialog();
        }

        private void Zap3_OnClick(object sender, RoutedEventArgs e)
        {
            Zapros3 zap3 = new Zapros3();
            zap3.Show();
        }

        private void Zap4_OnClick(object sender, RoutedEventArgs e)
        {
            Zapros4 zap4 = new Zapros4();
            zap4.Show();
        }

        private void Zap5_OnClick(object sender, RoutedEventArgs e)
        {
            Zapros5 zap5 = new Zapros5();
            zap5.Show();
        }

        private void Zap6_OnClick(object sender, RoutedEventArgs e)
        {
            Zapros6 zap6 = new Zapros6();
            zap6.Show();
        }
        
        //_____________________Вкладка "Функционал"__________________________________
        private void CreateBD_OnClick(object sender, RoutedEventArgs e)
        {
            if (db.Database.EnsureCreated() == false)
            {
                MessageBox.Show("БД уже создана. Если вы хотите ее пересоздать - удалите её и создайте снова.");   
            }
            else
            {
                  var Prof = new List<Professions>
            {
                new() { Prof_Name = "Кассир-администратор" },
                new() { Prof_Name = "Кассир" },
                new() { Prof_Name = "Грузчик" },
                new() { Prof_Name = "Маляр" },
                new() { Prof_Name = "Учитель" }
            };
            db.Professions.AddRange(Prof);
            db.SaveChanges();

            Applicants User = new Applicants
            {
                Familia = "Осокин", Name = "Тимофей", Otchestvo = "Сергеевич", Email = "tim_osokin@mail.ru", Activ = false,
                Professions = db.Professions.Where(u => u.Prof_Name == "Кассир-администратор").ToList()[0]
            };
            Diploma Diplom = new Diploma
            {
                ID_Dipl = "1334501", Institution = "БГК", Specialties = "Информационные системы",
                Date_Receiving = new DateTime(2023, 05, 29).ToShortDateString(), Applicants = User
            };
            db.Applicants.Add(User);
            db.Diploma.Add(Diplom);
            db.SaveChanges();

            Employers employers = new Employers { FIO = "Куксин П.С.", Name_Org = "ООО Куриное царство", Address = "г. Бийск, ул. 8 Марта, дом 16", Email = "p_kocksin@mail.ru", Phone = "+79609776666"};
            
            Vacancy vacancy = new Vacancy
            {
                Employers = employers, Professions = db.Professions.Where(u => u.Prof_Name == "Кассир").ToList()[0],
                Salary = 25000.00
            };
            db.Employers.Add(employers);
            employers = new Employers{ FIO = "Кравцов И.Д.", Name_Org = "Соц защита", Address = "г. Бийск, ул. Ленина, дом 236", Phone = "+79609667755"};
            db.Employers.Add(employers);
            
            db.Vacancy.Add(vacancy);
                
                db.SaveChanges();
                CheckBD.Text = "БД создана";
                MessageBox.Show("БД создана"); 
            } 
        }
        
        private void DeleteBD_OnClick(object sender, RoutedEventArgs e)
        {
            if (db.Database.EnsureDeleted() == false)
            {
               MessageBox.Show("База данных не найдена");
            }
            else
            {
                CheckBD.Text = "БД не создана";
                MessageBox.Show("БД удалена");
            }
            
        }
    }
}