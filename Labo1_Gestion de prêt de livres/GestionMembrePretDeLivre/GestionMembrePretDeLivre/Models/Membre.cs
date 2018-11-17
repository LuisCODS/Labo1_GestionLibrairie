﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionMembrePretDeLivre.Models
{
    //[CustomValidation(typeof(Membre), "ValiderLimitePret")]
    public class Membre
    {
        public Membre()
        {
            this.Prets = new List<Pret>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MembreID { get; set; }

        [DisplayName("NOM/MEMBRE")]
        [Required(ErrorMessage = "Champ obligatoire"), StringLength(100)]
        public string Nom { get; set; }

        [DisplayName("PRÉNOM/MEMBRE")]
        [Required(ErrorMessage = "Champ obligatoire"), StringLength(100)]
        public string Prenom { get; set; }

        [Index(IsUnique = true)]//Pas de doublon dans la BD
        [DisplayName("TELEPHONE/MEMBRE")]
        [Required(ErrorMessage = "Champ obligatoire"), StringLength(12)]
        public string Telephone { get; set; }

        [Index(IsUnique = true)]//Pas de doublon dans la BD
        [DisplayName("COURRIEL/MEMBRE"), DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Champ obligatoire"), StringLength(200)]
        public string Email { get; set; }

        // ========================== RELATIONS ================================\\

        public virtual ICollection<Pret> Prets { get; set; }//1 to N


        //TO DO   
        //public static ValidationResult ValiderLimitePret(Membre m)
        //{
        //    try
        //    {
        //        if (m.QuantiteLivre == 3)                
        //            return new ValidationResult("Limite max de livre empruté!");                
        //        return ValidationResult.Success;
        //    }
        //    catch (Exception )
        //    {
        //        throw ;
        //    }
        //}

    }//fin classe
}