using System.Windows;

namespace Куровичок_Осокин.Forms;

public partial class Emp : Window
{
    static ApplicationContext db = new ApplicationContext();
    List<Employers> Zapros;
    private int number = 0;
    public Emp()
    {
        InitializeComponent();
        Zapros = db.Employers.ToList();
        CheckBD();
    }
    void CheckBD()
    {
        if (Zapros[number].ID_Rab != null)
        {
            this.DataContext = Zapros[number];
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
        Zap2_Add zap = new Zap2_Add(db);
        zap.ShowDialog();
        Zapros = db.Employers.ToList();
        number = Zapros.Count-1;
        CheckBD();
        
    }

    private void Del_OnClick(object sender, RoutedEventArgs e)
    {
        db.Employers.Remove(Zapros[number]);
        Zapros.RemoveAt(number);
        number=0;
        db.SaveChanges();
        CheckBD();
    }

    private void OnLostFocus(object sender, RoutedEventArgs e)
    {
        db.Employers.UpdateRange(Zapros);
        db.SaveChanges();
        Zapros = db.Employers.ToList();
        CheckBD();
    }
}