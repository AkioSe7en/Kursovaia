﻿namespace Куровичок_Осокин.Tables;

public class Employers
{
    public Guid ID_Rab { get; set; }
    public string FIO { get; set; } = null!;
    [MaxLength(11, ErrorMessage = "Максимальное количество символов")] public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Name_Org { get; set; } = null!;
    public bool Activ { get; set; }
    public DateTime DateDelete { get; set; }
    public ICollection<Vacancy> Vacancies { get; set; }
    
    public Employers()
    {
        Vacancies = new List<Vacancy>();
    }
    
    }