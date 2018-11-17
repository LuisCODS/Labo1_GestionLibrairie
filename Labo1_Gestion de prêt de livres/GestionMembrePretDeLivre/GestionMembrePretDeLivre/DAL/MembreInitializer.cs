using GestionMembrePretDeLivre.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionMembrePretDeLivre.DAL
{
    //Classe que configurar o EF para inicializar o banco de dados com dados de teste
    //O banco de dados deve ser descartado e recriado sempre que o modelo é alterado.
    public class MembreInitializer : DropCreateDatabaseAlways<LibrairieDBContext>//DropCreateDatabaseIfModelChanges / DropCreateDatabaseAlways
    {
        //Entity Framework chama esse metodo automaticamente depois de criar o banco de dados para preenchê-lo com dados de teste.
        protected override void Seed(LibrairieDBContext context)
        {
            var santos = new Membre { MembreID = 10, Nom = "Santos", Prenom = "Luis", Email = "Luis@gmail.com", Telephone = "514-333-4545" };
            var amine = new Membre { MembreID = 20, Nom = "Mohamed", Prenom = "Amine", Email = "Amine@gmail.com", Telephone = "514-555-7777" };
            context.Membre.Add(santos);
            context.Membre.Add(amine);
            context.SaveChanges();

            var laRoute = new Livre { LivreID = 100, ISBN = 564747, Auteur = "John Carter", Categorie = Categorie.Romant, Titre = "La Route" };
            var lifeStyle = new Livre { LivreID = 200, ISBN = 888888, Auteur = "Mike Stwart", Categorie = Categorie.Jeunesse, Titre = "Life Style" };
            context.Livre.Add(laRoute);
            context.Livre.Add(lifeStyle);
            context.SaveChanges();       

        }

    }
}