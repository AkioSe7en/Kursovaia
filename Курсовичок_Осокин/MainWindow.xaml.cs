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
        
        private void CreateBD_OnClick(object sender, RoutedEventArgs e)
        {
            ApplicationContext db = new ApplicationContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            Applicants User = new Applicants {Familia = "Осокин", Name = "Тимофей", Otchestvo = "Сергеевич", Email = "tim_osokin@mail.ru"};
            Diploma Diplom = new Diploma{ID_Dipl = "1334501", Institution = "БГК", Specialties = "Информационные системы", Date_Receiving = new DateTime(2023, 05, 29).ToShortDateString(), Applicants = User};
            db.Applicants.Add(User);
            db.Diploma.Add(Diplom);
            
            Employers employers = new Employers{FIO = "Куксин П.С.", Name_Org = "ООО Куриное царство"};
            Vacancy vacancy = new Vacancy{Employers = employers, Prof_Name = "Кассир", Salary = 25000.00};
            db.Employers.Add(employers);
            db.Vacancy.Add(vacancy);
            
            db.SaveChanges();
            MessageBox.Show("БД создана");
        }
    }
}