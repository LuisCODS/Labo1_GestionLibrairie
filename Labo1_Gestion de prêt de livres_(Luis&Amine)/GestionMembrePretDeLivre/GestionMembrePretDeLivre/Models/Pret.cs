using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace GestionMembrePretDeLivre.Models
{
    //[CustomValidation(typeof(Pret), "ValiderDataDuPret")]
    public class Pret
    {
        public Pret()
        {
            this.DateDuPret = DateTime.Now;
            this.Statut = "Pas en retard";
            this.DateRetour = DateDuPret.AddDays(7);
            //source: https://eduogama.wordpress.com/dicas-net/trabalhando-com-datas-no-c/
        }

        //[Index(IsUnique = true)]//Pas de doublon
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PretID { get; set; }

        [DisplayName("DATE DU PRÊT"), DataType(DataType.Date)]
        public DateTime DateDuPret { get; set; }

        [DisplayName("DATE DE RETOUR"), DataType(DataType.Date)]
        public DateTime DateRetour { get; set; }

        [DisplayName("STATUT")]
        public string Statut { get; set; }

        // ========================== RELATIONS ================================\\
        // 1 to 1
        public int MembreID { get; set; }
        public virtual Membre Membre { get; set; }

        public int LivreID { get; set; }
        public virtual Livre Livre { get; set; }


        //public static ValidationResult ValiderDataDuPret(Pret pret)
        //{
        //    TimeSpan ts = pret.DateDuPret.Subtract(pret.DateRetour);
        //    int nbJours = ts.Days;

        //    if (nbJours > 7)
        //    {
        //        pret.Statut = "En retard";
        //        return new ValidationResult("Prêt en retard!");
        //    }
        //    return ValidationResult.Success;
        //}

    }//end class


}