namespace personapi_dotnet.Models.Entities;

using Microsoft.EntityFrameworkCore;

public partial class PersonDbContext : DbContext
{
    public PersonDbContext()
    {
    }

    public PersonDbContext(DbContextOptions<PersonDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Phone> Phones { get; set; }

    public virtual DbSet<Profession> Professions { get; set; }

    public virtual DbSet<Study> Studies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=persona_db;Trusted_Connection=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Cc).HasName("PK__Person__3213666DDE7A03D6");

            entity.ToTable("Person");

            entity.Property(e => e.Cc)
                .ValueGeneratedNever()
                .HasColumnName("cc");

            entity.Property(e => e.Age).HasColumnName("age");

            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("gender");

            entity.Property(e => e.LastName)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("lastName");

            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Phone>(entity =>
        {
            entity.HasKey(e => e.Number).HasName("PK__Phone__FD291E40437D50C1");

            entity.ToTable("Phone");

            entity.Property(e => e.Number)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("number");

            entity.Property(e => e.CcPerson).HasColumnName("cc_person");

            entity.Property(e => e.Operator)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("operator");

            entity.HasOne(d => d.CcPersonNavigation)
                .WithMany()
                .HasForeignKey(d => d.CcPerson)
                .HasConstraintName("FK_Phone_Person");
        });

        modelBuilder.Entity<Profession>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Professi__3213E83FE8467766");

            entity.ToTable("Profession");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");

            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");

            entity.Property(e => e.Name)
                .HasMaxLength(90)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Study>(entity =>
        {
            entity.HasKey(e => new { e.IdProffesion, e.CcPerson }).HasName("PK__Study__55A70038F8C87724");

            entity.ToTable("Study");

            entity.Property(e => e.IdProffesion).HasColumnName("id_proffesion");

            entity.Property(e => e.CcPerson).HasColumnName("cc_person");

            entity.Property(e => e.EndDate).HasColumnName("end_date");

            entity.Property(e => e.University)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("university");

            entity.HasOne(d => d.CcPersonNavigation)
                  .WithMany()
                  .HasForeignKey(d => d.CcPerson)
                  .HasConstraintName("FK_Phone_Person");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
