
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using GestionMembrePretDeLivre.Models;

namespace GestionMembrePretDeLivre.DAL
{
    public class MembreContext: DbContext
    {
        public MembreContext() : base("MembreContext")  { }

        public DbSet<Membre> Membres { get; set; }
        //Les 2 DbSets pourrait être enlevé, car E.F.  les ajoutent implicitement.
        //...l'entité Membre fait deja reference à celle du Pret1 et cette derniere 
        //...point vers l'entité Livre. 
        public DbSet<Pret> Prets { get; set; }
        public DbSet<Livre> Livres { get; set; }

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