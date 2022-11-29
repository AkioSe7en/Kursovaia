namespace Курсовичок_Осокин;

public class ApplicationContext : DbContext
{
    public DbSet<Applicants> Applicants => Set<Applicants>();
    public DbSet<Employers> Employers => Set<Employers>();
    public DbSet<Diploma> Diploma => Set<Diploma>();
    public DbSet<Vacancy> Vacancy => Set<Vacancy>();
    public DbSet<Professions> Professions => Set<Professions>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vacancy>().Property(p => p.Salary).HasPrecision(6, 2);
        
        modelBuilder.Entity<Applicants>().HasKey(u => u.Id_App);
        modelBuilder.Entity<Employers>().HasKey(u => u.ID_Rab);
        modelBuilder.Entity<Diploma>().HasKey(u => u.ID_Dipl);
        modelBuilder.Entity<Professions>().HasKey(u=>u.Prof_Name);
        modelBuilder.Entity<Vacancy>().HasKey(u => u.Id_Vac);

        modelBuilder.Entity<Employers>().HasMany(p => p.Vacancies); // 1 emp - М vac
        modelBuilder.Entity<Applicants>().HasMany(p => p.Diplomas); // 1 app - М dip
        
        // modelBuilder.Entity<Professions>().HasMany(p => p.Applicants);
        // modelBuilder.Entity<Professions>().HasMany(p => p.Vacancy);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=ИскателиТочкаРу.db");
    }
}