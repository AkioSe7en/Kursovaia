﻿namespace Курсовичок_Осокин.Tables;

public class Vacancy
{
    public Guid Id_Vac { get; }
    public Employers Employers { get; set; }
    public string Prof_Name { get; set; }
    public DateTime Date_Create { get; }
    public double Salary { get; set; }
    
    // public ICollection<Professions> ProfessionsCollection { get; set; }
    // public Vacancy()
    // {
    //     ProfessionsCollection = new List<Professions>();
    // }
}