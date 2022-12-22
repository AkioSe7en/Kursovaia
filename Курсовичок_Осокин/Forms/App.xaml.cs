using System.Windows;

namespace Куровичок_Осокин.Forms;

public partial class App : Window
{
    static ApplicationContext db = new ApplicationContext();
    List<Applicants> Zapros;
    private int number = 0;
    public App()
    {
        InitializeComponent(); 
        Zapros = db.Applicants.ToList();
        CheckBD();
    }
    
    void CheckBD()
    {
        if (Zapros[number].ID_App != null)
        {
            ID.Text = Zapros[number].ID_App.ToString();
            Familia.Text = Zapros[number].Familia;
            Name.Text = Zapros[number].Name;
            Otchestvo.Text = Zapros[number].Otchestvo;
            Phone.Text = Zapros[number].Phone;
            Email.Text = Zapros[number].Email;
            Activ.IsChecked = Zapros[number].Activ;
            Prof_Name.ItemsSource = db.Professions.ToList();
            Prof_Name.SelectedItem = Zapros[number].Professions;
            if (Zapros[number].DateDelete!=null)
                Date_Delete.Text = Zapros[number].DateDelete?.ToShortDateString();
        }
    }

    private void Next_OnClick(object sender, RoutedEventArgs e)
    {
        if (number+1 < Zapros.Count)
        {
            number++;
            CheckBD();
        }
    }

    private void Prev_OnClick(object sender, RoutedEventArgs e)
    {
        if (number-1 >= 0)
        {
            number--;
            CheckBD();
        }
        
    }

    private void PrevAll_OnClick(object sender, RoutedEventArgs e)
    {
        number = 0;
        CheckBD();
    }

    private void NextAll_OnClick(object sender, RoutedEventArgs e)
    {
        number = Zapros.Count-1;
        CheckBD();
    }

    private void New_OnClick(object sender, RoutedEventArgs e)
    {
        Zap3_Add zap = new Zap3_Add(db);
        zap.ShowDialog();
        Zapros = db.Applicants.ToList();
        number = Zapros.Count-1;
        CheckBD();
        
    }

    private void Del_OnClick(object sender, RoutedEventArgs e)
    {
        db.Applicants.Remove(Zapros[number]);
        Zapros.RemoveAt(number);
        number=0;
        db.SaveChanges();
        CheckBD();
    }
}