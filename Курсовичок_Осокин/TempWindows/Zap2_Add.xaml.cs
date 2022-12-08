namespace Куровичок_Осокин.TempWindows;

public partial class Zap2_Add : Window
{
    private ApplicationContext db;
    public Zap2_Add(ApplicationContext db)
    {
        InitializeComponent();
        this.db = db;
    }

    private void OK_OnClick(object sender, RoutedEventArgs e)
    {
       Employers emp = new Employers
        {
            FIO = FIO.Text,
            Email = Email.Text,
            Phone = Phone.Text,
            Address = Address.Text,
            Name_Org = Name_Org.Text,
            Activ = Activ.IsChecked.Value
        };
        db.Employers.Add(emp);
        db.SaveChanges();
        DialogResult = true;
    }
}