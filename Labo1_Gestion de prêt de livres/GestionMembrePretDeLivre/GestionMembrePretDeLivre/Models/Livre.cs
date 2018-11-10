using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionMembrePretDeLivre.Models
{
    public enum Categorie
    {
        Enfant, Jeunesse, Romant, Fiction
    }

    [Table("Livres")]
    public class Livre
    {
        [Index(IsUnique = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key,DisplayName("ISBN"), Required(ErrorMessage = "Champ obligatoire")]
        public int LivreID { get; set; }

        [DisplayName("TITRE")]
        [Required(ErrorMessage = "Champ obligatoire")]
        public string Titre { get; set; }

        [DisplayName("STOCK")]
        [Required(ErrorMessage = ("Champs obligatoire"))]
        public int Stock { get; set; }

        [DisplayName("ACTEUR")]
        [Required(ErrorMessage = "Champ obligatoire")]
        public string Auteur { get; set; }

        [DisplayName("CATEGORIE")]
        public Categorie? Categorie { get; set; }

        // ========================== RELATIONS ================================\\
        //[InverseProperty("Membre")]
        // 1 to N
        //public virtual ICollection<Pret> Prets { get; set; }

        //public int PretID { get; set; }
        //public virtual Pret Pret { get; set; }


    }
}