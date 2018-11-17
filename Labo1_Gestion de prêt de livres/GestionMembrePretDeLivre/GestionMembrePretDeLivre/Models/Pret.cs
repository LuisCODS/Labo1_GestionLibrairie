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
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PretID { get; set; }

        [DisplayName("DATE DU PRÊT"), DataType(DataType.Date)]
        public DateTime DateDuPret { get; set; }

        [DisplayName("DATE DE RETOUR"), DataType(DataType.Date)]
        public DateTime DateRetour { get; set; }

        // ========================== RELATIONS ================================\\
        // 1 to 1
        public int MembreID { get; set; }
        public virtual Membre Membre { get; set; }

        public int LivreID { get; set; }
        public virtual Livre Livre { get; set; }

        
        //public static ValidationResult ValiderDataDuPret(Pret pret)
        //{
        //    DateTime today = DateTime.Now;

        //    TimeSpan ts = pret.DateDuPret.Subtract(today);

        //    if ()
        //    {
        //        return new ValidationResult("Vous êtes en retard pour");
        //    }
        //    return ValidationResult.Success;
        //}

    }//end class


}