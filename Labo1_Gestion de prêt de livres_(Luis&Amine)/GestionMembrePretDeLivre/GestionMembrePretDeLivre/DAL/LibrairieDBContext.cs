
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using GestionMembrePretDeLivre.Models;

namespace GestionMembrePretDeLivre.DAL
{
    public class LibrairieDBContext: DbContext
    {
        public LibrairieDBContext() : base("LibrairieDBContext")
        {
            Database.SetInitializer(new MembreInitializer());
        }

        public DbSet<Membre> Membre { get; set; }
        public DbSet<Pret> Pret { get; set; }
        public DbSet<Livre> Livre { get; set; }

       // customize the specific behavior of the Entity Framework
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //impede que os nomes das tabelas sejam pluralizados automaticamente.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }


    }//end class
}