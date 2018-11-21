using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionMembrePretDeLivre.Models
{
    public enum Categorie
    {
        Enfant, Jeunesse, Romant, Fiction
    }

    public class Livre
    {

        //[Display(AutoGenerateField = true)]
        //[Index(IsUnique = true)]//Pas de doublon
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LivreID { get; set; }

        [DisplayName("TITRE LIVRE"), StringLength(100)]
        [Required(ErrorMessage = "Champ obligatoire")]
        public string Titre { get; set; }

        [DisplayName("ACTEUR"), StringLength(100)]
        [Required(ErrorMessage = "Champ obligatoire")]
        public string Auteur { get; set; }

        [DisplayName("CATEGORIE")]
        public Categorie Categorie { get; set; }


        // ========================== RELATIONS ================================\\

        public virtual ICollection<Pret> Prets { get; set; }//1 to N



    }//fin classe
}