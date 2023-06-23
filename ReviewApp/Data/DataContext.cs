using Microsoft.EntityFrameworkCore;
using ReviewApp.Models;

namespace ReviewApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Owner> owners { get; set; }
        public DbSet<Character> characters { get; set; }
        public DbSet<Country> countries { get; set; }
        public DbSet<Reviewers> reviewers { get; set; }
        public DbSet<Reviews> reviews { get; set; }
        public DbSet<CharacterCategory> characterCategories { get; set; }
        public DbSet<CharacterOwner> characterOwners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //many to many relationship betwen category and character

            modelBuilder.Entity<CharacterCategory>().HasKey(pc => new { pc.CharacterId, pc.CategoryId });
            modelBuilder.Entity<CharacterCategory>().HasOne(p => p.Character).WithMany(pc => pc.characterCategories)
                .HasForeignKey(c => c.CharacterId);
            modelBuilder.Entity<CharacterCategory>().HasOne(p => p.Category).WithMany(pc => pc.Categories)
                .HasForeignKey(c => c.CategoryId);



            //many to many relationship betwen owner and character
            modelBuilder.Entity<CharacterOwner>().HasKey(pc => new { pc.CharacterId, pc.OwnerId });
            modelBuilder.Entity<CharacterOwner>().HasOne(p => p.character).WithMany(pc => pc.characterOwners)
                .HasForeignKey(c => c.CharacterId);
            modelBuilder.Entity<CharacterOwner>().HasOne(p => p.owner).WithMany(pc => pc.CharacterOwners)
                .HasForeignKey(c => c.OwnerId);



        }




    }
}
