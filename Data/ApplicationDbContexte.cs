using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ges_commande.Models;
using Microsoft.Extensions.Logging;


public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {


    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

   


  
    // modelBuilder.Entity<Absence>()
    //     .HasOne(a => a.Course)
    //     .WithMany(c => c.Absences)
    //     .HasForeignKey(a => a.CourseId);


    // modelBuilder.Entity<Absence>()
    //     .HasOne(a => a.Student)
    //     .WithMany(s => s.Absences)
    //     .HasForeignKey(a => a.StudentId);

    // modelBuilder.Entity<Course>()
    //     .HasOne(c => c.professeur)
    //     .WithMany(p => p.Courses)
    //     .HasForeignKey(c => c.ProfessorId)
    //     .OnDelete(DeleteBehavior.Restrict);

   
    // modelBuilder.Entity<Course>()
    //     .HasOne(c => c.Module)
    //     .WithMany(m => m.Courses)
    //     .HasForeignKey(c => c.ModuleId)
    //     .OnDelete(DeleteBehavior.Restrict);
         



        base.OnModelCreating(modelBuilder);
    }
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .EnableSensitiveDataLogging()      // Affiche les données sensibles (utile pour débogage)
            .EnableDetailedErrors()   
            .LogTo(Console.WriteLine, LogLevel.Information);        // Ajoute plus de détails dans les erreurs
    }


   
    public DbSet<Cours.Models.Client> client { get; set; } = default!;

    public DbSet<ges_commande.Models.User> users { get; set; } = default!;

    public DbSet<Cours.Models.Commande> commande { get; set; } = default!;

    public DbSet<Cours.Models.DetailsCommande> detailCommande { get; set; } = default!;
    public DbSet<Cours.Models.Paiements> paiement { get; set; } = default!;

    public DbSet<Cours.Models.Produits> produit { get; set; } = default!;

    public DbSet<Cours.Models.Livreur> livreur { get; set; } = default!;





}