using GestionMembrePretDeLivre.Models;
using System.Data.Entity;
using System;

namespace GestionMembrePretDeLivre.DAL
{
    //Classe que configurar o EF para inicializar o banco de dados com dados de teste
    //O banco de dados deve ser descartado e recriado sempre que o modelo é alterado.
    public class MembreInitializer : DropCreateDatabaseAlways<LibrairieDBContext>//DropCreateDatabaseAlways / DropCreateDatabaseAlways
    {
        //Entity Framework chama esse metodo automaticamente depois de criar o banco de dados para preenchê-lo com dados de teste.
        protected override void Seed(LibrairieDBContext context)
        {
            var santos = new Membre { MembreID = 10, Nom = "Santos", Prenom = "Luis", Email = "Luis@gmail.com", Telephone = "514-333-4545" };
            var amine  = new Membre { MembreID = 20, Nom = "Mohamed", Prenom = "Amine", Email = "Amine@gmail.com", Telephone = "514-555-7777" };
            var membreTesteDate = new Membre { MembreID = 30, nbLivres = 1, Nom = "Michel", Prenom = "Tramblay", Email = "teste@gmail.com", Telephone = "000-000-0000" };

            context.Membre.Add(santos);
            context.Membre.Add(amine);
            context.Membre.Add(membreTesteDate);

            context.SaveChanges();

            var laRoute = new Livre { LivreID = 100, Auteur = "John Carter", Categorie = Categorie.Romant, Titre = "La Route" };
            var lifeStyle = new Livre { LivreID = 200,  Auteur = "Mike Stwart", Categorie = Categorie.Jeunesse, Titre = "Life Style" };
            var livreTesteDate = new Livre { LivreID = 300, Auteur = "Lays britto", Categorie = Categorie.Enfant, Titre = "Le loups méchant" };
            context.Livre.Add(laRoute);
            context.Livre.Add(lifeStyle);
            context.Livre.Add(livreTesteDate);

            context.SaveChanges();

            var PretTesteDate = new Pret
            {
                MembreID = 30,
                LivreID = 300,
                DateDuPret = DateTime.Parse("2018-09-01"),
                DateRetour = DateTime.Parse("2018-09-28"),               
        };
            
            context.Pret.Add(PretTesteDate);
            context.SaveChanges();

        }

    }
}