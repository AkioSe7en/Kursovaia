namespace Куровичок_Осокин.TempWindows;

public partial class Zap4_Add : Window
{
    private ApplicationContext db;
    public Zap4_Add(ApplicationContext db)
    {
        InitializeComponent();
        this.db = db;
        foreach (var app in db.Applicants.ToList())
        {
            Anketa.Items.Add(new StackPanel{Children = { new TextBlock{Text = app.Familia}, new TextBlock{Text = app.Name}, new TextBlock{Text = app.Otchestvo} }});
        }
    }

    private void OK_OnClick(object sender, RoutedEventArgs e)
    {
        Diploma dip = new Diploma()
        {
            ID_Dipl = ID_Dip.Text,
            Institution = Institution.Text,
            Specialties = Specialties.Text,
            Date_Receiving = Date_Receiving.Text,
            Applicants = db.Applicants.Where(z=>z.Familia == (string)((TextBlock)(((StackPanel)Anketa.SelectedItem).Children[0])).Text).Where(z=>z.Name == (string)((TextBlock)(((StackPanel)Anketa.SelectedItem).Children[1])).Text).Where(z=>z.Otchestvo == (string)((TextBlock)(((StackPanel)Anketa.SelectedItem).Children[2])).Text).ToList()[0]
        };
        
        db.Diploma.Add(dip);
        db.SaveChanges();
        DialogResult = true;
    }

    private void Anketa_OnLostFocus(object sender, RoutedEventArgs e)
    {
        int count = 0;
        if (Anketa.Text != "")
        {
            foreach (var z in db.Applicants)
            {
                if (z.Familia == (string)((TextBlock)(((StackPanel)Anketa.SelectedItem).Children[0])).Text && z.Name == (string)((TextBlock)(((StackPanel)Anketa.SelectedItem).Children[1])).Text && z.Otchestvo == (string)((TextBlock)(((StackPanel)Anketa.SelectedItem).Children[2])).Text )
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