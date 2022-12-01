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

        private void CreateBD_OnClick(object sender, RoutedEventArgs e)
        {
            if (db.Database.EnsureCreated() == false)
            {
                MessageBox.Show("БД уже создана. Если вы хотите ее пересоздать - удалите её и создайте снова.");   
            }
            else
            {
                /*  var Prof = new List<Professions>
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
                Familia = "Осокин", Name = "Тимофей", Otchestvo = "Сергеевич", Email = "tim_osokin@mail.ru",
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

            Employers employers = new Employers { FIO = "Куксин П.С.", Name_Org = "ООО Куриное царство" };
            Vacancy vacancy = new Vacancy
            {
                Employers = employers, Professions = db.Professions.Where(u => u.Prof_Name == "Кассир").ToList()[0],
                Salary = 25000.00
            };
            db.Employers.Add(employers);
            db.Vacancy.Add(vacancy);*/
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

        private void UIElement_OnFocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}