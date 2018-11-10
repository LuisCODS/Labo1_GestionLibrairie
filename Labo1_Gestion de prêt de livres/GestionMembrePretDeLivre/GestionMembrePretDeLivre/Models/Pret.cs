using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionMembrePretDeLivre.Models
{
    [Table("Prets")]
    //[CustomValidation(typeof(Pret1), "ValiderDataDuPret")]
    public class Pret
    {

        public Pret() {
            this.DateDuPret = DateTime.Now;
        }

     
        [Key, Index(IsUnique = true)]
        public int PretID { get; set; }
        [DisplayName("DATE DU PRÊT"), DataType(DataType.Date)]
        public DateTime DateDuPret { get; set; }


        // ========================== RELATIONS ================================\\
        // 1 to 1
        public int MembreID { get; set; }
        //[ForeignKey("MembreID")]
        public virtual Membre Membre { get; set; }

        //1 to 1
        public int LivreID { get; set; }
        public virtual Livre Livre { get; set; }


        //public static ValidationResult ValiderDataDuPret(Pret1 pret)
        //{
        //    if ()
        //    {
        //        return new ValidationResult("Vous êtes en retard pour");                      
        //    }
        //    return ValidationResult.Success;
        //}

    }//end class


}