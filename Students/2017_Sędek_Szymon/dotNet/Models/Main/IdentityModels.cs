using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using dotNet.Models.User;
using dotNet.Service;
using Microsoft.AspNet.Identity.EntityFramework;

namespace dotNet.Models.Main
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>,ICarContex
    {
        public ApplicationDbContext() : base("Net")
        {
            Database.SetInitializer(new DotNetDbInitializer());

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }

        public DbSet<Car> Cars { get; set; }

        IQueryable<Car> ICarContex.Cars => Cars;

        IQueryable<Artist> ICarContex.Artists => Artists;

        int ICarContex.SaveChanges()
        {
            return SaveChanges();
        }

        T ICarContex.Add<T>(T entity)
        {
            return Set<T>().Add(entity);
        }

        Car ICarContex.FindCarById(int id)
        {
            return Set<Car>().Find(id);
        }

        Artist ICarContex.FindArtistById(int id)
        {
            return Set<Artist>().Find(id);
        }


        T ICarContex.Delete<T>(T entity)
        {
            return Set<T>().Remove(entity);
        }
        /*   protected override void OnModelCreating(DbModelBuilder modelBuilder)
           {
               base.OnModelCreating(modelBuilder);
               modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
               modelBuilder.Entity<IdentityUser>().ToTable("Users").Property(p => p.Id).HasColumnName("UserId");
               modelBuilder.Entity<ApplicationUser>().ToTable("Users").Property(p => p.Id).HasColumnName("UserId");
               modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
               modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
               modelBuilder.Entity<IdentityRole>().ToTable("Roles");
               modelBuilder.Entity<ApplicationUser>().HasMany<IdentityUserRole>((ApplicationUser u) => u.Roles);
               modelBuilder.Entity<IdentityUserRole>().HasKey((IdentityUserRole r) =>new
               {
                   UserId = r.UserId,
                   RoleId = r.RoleId
               }).ToTable("UserRoles");
               modelBuilder.Entity<Song>()
                      .HasRequired(s => s.Artist) 
                      .WithMany(s => s.Songs)
                      .HasForeignKey(s=>s.ArtId); 
               modelBuilder.Entity<Car>()
                   .HasOptional(a => a.Artist)
                   .WithMany(a => a.Cars)
                   .HasForeignKey(a => a.ArtId);
           }

           public DbSet<Artist> Artists { get; set; }

           public DbSet<Song> Songs { get; set; }

           public DbSet<Car> Cars { get; set; }
      */
    }

}