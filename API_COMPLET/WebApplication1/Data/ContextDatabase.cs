using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.Data
{
    //DbContext formule de base integree a entity
    public class ContextDatabase(DbContextOptions<ContextDatabase> options) : DbContext(options)
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }

        //Cette méthode configure la structure de votre base de données via l'API Fluent.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration User
            modelBuilder.Entity<User>(entity =>
            {
                //Définit Id comme clé primaire de la table Users
                entity.HasKey(u => u.Id);

                entity.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(128);

                entity.Property(u => u.LastName)
                .HasMaxLength(128);

                entity.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(128);

                /// Index unique sur l'email
                entity.HasIndex(u => u.Email).IsUnique();

                // Relation 1-to-Many
                entity.HasMany(u => u.ListAddresses)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            });
            // Configuration Address
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.Property(a => a.StreetNumber)
                .HasMaxLength(100);

                entity.Property(a => a.Town)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(a => a.Country)
                .IsRequired()
                .HasMaxLength(100);

                // Index pour les recherches par ville
                entity.HasIndex(a => a.Town);
            });

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                modelBuilder.Entity<User>().HasData(
                    new User
                    {
                        Id = 1, // S'assurer que les identifiants sont fournis pour seed
                        FirstName = "John",
                        LastName = "Doe",
                        Email = "johndoe@domain.be"
                    }
                );

                modelBuilder.Entity<Address>().HasData(
                    new Address
                    {
                        Id = 1,
                        UserId = 1,
                        StreetNumber = "221B Baker Street",
                        ZipCode = 75752,
                        Town = "Londre",
                        Country = "Angleterre"


                    }
                );
            }
        }
    }
}
