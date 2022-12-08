using System.Windows;

namespace Куровичок_Осокин.TempWindows;

public partial class Zap1_Add : Window
{
    private ApplicationContext db;
    public Zap1_Add(ApplicationContext db)
    {
        InitializeComponent();
        this.db = db;
        Prof_Name.ItemsSource = db.Professions.ToList();
        foreach (var emps in db.Employers.ToList())
        {
            Name_Org.Items.Add(new StackPanel{Children = { new TextBlock{Text = emps.Name_Org}, new TextBlock{Text = emps.FIO} }});
        }

    }

    private void OK_OnClick(object sender, RoutedEventArgs e)
    {
        string Name_Org_Org = (string)((TextBlock)(((StackPanel)Name_Org.SelectedItem).Children[0])).Text; //Тройное преобразование чтобы вытащить из комбобокса оргу
        string Name_Org_FIO = (string)((TextBlock)(((StackPanel)Name_Org.SelectedItem).Children[1])).Text; //Тройное преобразование чтобы вытащить из комбобокса фио
        Vacancy vac = new Vacancy
        {
          Salary  = Double.Parse(Salary.Text),
          Employers = db.Employers.Where(p=>p.Name_Org==Name_Org_Org).Where(p=>p.FIO==Name_Org_FIO).ToList()[0],
          //Professions = db.Professions.Where(p=>p.Prof_Name == Prof_Name.SelectedItem).ToList()[0]
          Professions = (Professions)Prof_Name.SelectedItem
        };
        db.Vacancy.Add(vac);
        db.SaveChanges();
        DialogResult = true;
    }

    private void Prof_Name_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // var a =(Professions)Prof_Name.SelectedItem;
        // if (db.Professions.Find(a)==null)
        // {
        //     MessageBox.Show("Вы неверно ввели профессию. Для правильного ввода выберите профессию из списка.");
        // }
    }

    private void Prof_Name_OnFocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        MessageBox.Show("Вы неверно ввели профессию. Для правильного ввода выберите профессию из списка.");
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