namespace Куровичок_Осокин.TempWindows;

public partial class Zap3_Add : Window
{
    private ApplicationContext db;
    public Zap3_Add(ApplicationContext db)
    {
        InitializeComponent();
        this.db = db;
        Prof_Name.ItemsSource = db.Professions.ToList();
    }

    private void OK_OnClick(object sender, RoutedEventArgs e)
    {
        Applicants app = new Applicants
        {
            
            Familia = Familia.Text,
            Name = Name.Text,
            Otchestvo = Otchestvo.Text,
            Email = Email.Text,
            Phone = Phone.Text,
            Professions = (Professions)Prof_Name.SelectedItem,
            Activ = Activ.IsChecked.Value

        };
        
        db.Applicants.Add(app);
        db.SaveChanges();
        DialogResult = true;
    }

    private void Prof_Name_OnLostFocus(object sender, RoutedEventArgs e)
    {
        int count = 0;
        if (Prof_Name.Text != "")
        {
            foreach (var z in db.Professions)
            {
                if (z.Prof_Name == Prof_Name.Text)
                {
                    count++;
                    break;
                }
            }

            if (count == 0)
            {
                MessageBox.Show("Вы неверно ввели профессию. Для правильного ввода выберите профессию из списка.");
            }
        }
    }
}