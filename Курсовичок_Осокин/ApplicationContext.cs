namespace Курсовичок_Осокин;

public class ApplicationContext : DbContext
{
    public DbSet<Applicants> Applicants => Set<Applicants>();
    public DbSet<Employers> Employers => Set<Employers>();
    public DbSet<Diploma> Diploma => Set<Diploma>();
    public DbSet<Vacancy> Vacancy => Set<Vacancy>();
    public DbSet<Professions> Professions => Set<Professions>();
    public DbSet<Users> Users => Set<Users>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vacancy>().Property(p => p.Salary).HasPrecision(6, 2);
        
        modelBuilder.Entity<Applicants>().HasKey(u => u.ID_App);
        modelBuilder.Entity<Employers>().HasKey(u => u.ID_Rab);
        modelBuilder.Entity<Diploma>().HasKey(u => u.ID_Dipl);
        modelBuilder.Entity<Professions>().HasKey(u=>u.ProfessionsID);
        modelBuilder.Entity<Vacancy>().HasKey(u => u.Id_Vac);
        modelBuilder.Entity<Users>().HasKey(u => u.UserID);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=ИскателиТочкаРу.db");
    }
}