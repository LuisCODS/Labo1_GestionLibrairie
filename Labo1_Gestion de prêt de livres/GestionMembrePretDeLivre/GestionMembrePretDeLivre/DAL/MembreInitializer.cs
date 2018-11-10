using GestionMembrePretDeLivre.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionMembrePretDeLivre.DAL
{
    //Classe que configurar o EF para inicializar o banco de dados com dados de teste
    //O banco de dados deve ser descartado e recriado sempre que o modelo é alterado.
    public class MembreInitializer : DropCreateDatabaseAlways<MembreContext>//DropCreateDatabaseIfModelChanges / DropCreateDatabaseAlways
    {
        //Entity Framework chama esse metodo automaticamente depois de criar o banco de dados para preenchê-lo com dados de teste.
        protected override void Seed(MembreContext context)
        {
            var membres = new List<Membre>
            {
                new Membre{ MembreID = 1, Nom ="Santos",  Prenom ="Luis",   Email ="Lulu@gmail.com",  Telephone ="514-333-4545", EnRetard=false},
                new Membre{ MembreID = 2, Nom ="Goldman", Prenom ="Bores",  Email ="bores@gmail.com", Telephone ="438-222-7600", EnRetard=false},
                new Membre{ MembreID = 3, Nom ="Tremblay",Prenom ="Michel", Email ="mtrb@gmail.com",  Telephone ="514-222-3432", EnRetard=false}

            };
            membres.ForEach(m => context.Membres.Add(m));
            context.SaveChanges();//cela vous permet de localiser la source d’un problème si une exception se produit pendant que le code écrit 

            var livres = new List<Livre>
            {
                new Livre{ LivreID=1, Auteur="John Carter",  Categorie=Categorie.Romant,   Stock=3,   Titre="La Route" },
                new Livre{ LivreID=2, Auteur="Nelson Motta", Categorie=Categorie.Romant,   Stock=100, Titre="Ma vie" },
                new Livre{ LivreID=3,  Auteur="Nelson Motta", Categorie=Categorie.Romant,   Stock=100, Titre="Ma vie" }
            };
            livres.ForEach(l => context.Livres.Add(l));
            context.SaveChanges();//cela vous permet de localiser la source d’un problème si une exception se produit pendant que le code écrit 

            var prets = new List<Pret>
            {
                new Pret{  MembreID=1, LivreID=1},
                new Pret{  MembreID=2, LivreID=2},
                new Pret{  MembreID=3, LivreID=3 }
            };
            prets.ForEach(p => context.Prets.Add(p));
            context.SaveChanges();//cela vous permet de localiser la source d’un problème si une exception se produit pendant que le code écrit 

        }

    }
}