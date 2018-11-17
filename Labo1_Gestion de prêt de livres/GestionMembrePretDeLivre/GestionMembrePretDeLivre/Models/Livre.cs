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

    //[Table("Livres")]
    public class Livre
    {

        public Livre()
        {
            //this.TotalStock = TotalStock + 1;
        }
        //[Display(AutoGenerateField = true)]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LivreID { get; set; }

        //entre 10 et 13
        [Required(ErrorMessage = ("Champs obligatoire"))]
        public long ISBN { get; set; }

        [DisplayName("TITRE/LIVRE"), StringLength(100)]
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