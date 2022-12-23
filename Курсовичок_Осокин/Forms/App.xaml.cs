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
        if (Zapros.Count > 0)
            {
                DataContext = Zapros[number];
                Prof_Name.ItemsSource = db.Professions.ToList();
                Prof_Name.SelectedItem = Zapros[number].Professions;
            }
            else
            {
                DataContext = null;
                Prof_Name.SelectedItem = null;
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
        if (Zapros.Count > 0)
        {
            db.Applicants.Remove(Zapros[number]);
            Zapros.RemoveAt(number);
            number = 0;
            db.SaveChanges();
        }
        CheckBD();
        
    }
    private void OnLostFocus(object sender, RoutedEventArgs e)
    {
        if (Zapros.Count > 0)
        {
            Zapros[number].Professions = (Professions)Prof_Name.SelectedItem;
            db.Applicants.UpdateRange(Zapros);
            db.SaveChanges();
        }

        CheckBD();
    }
}