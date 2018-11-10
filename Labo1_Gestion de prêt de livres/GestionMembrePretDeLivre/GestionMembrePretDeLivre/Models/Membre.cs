using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionMembrePretDeLivre.Models
{
    [Table("Membres")]
    public class Membre
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key, Index(IsUnique = true)]
        [DisplayName("Membre")]
        public int MembreID { get; set; }

        [DisplayName("NOM")]
        [Required(ErrorMessage = "Champ obligatoire"),MaxLength(100)]
        public string Nom { get; set; }

        [DisplayName("PRÉNOM")]
        [Required(ErrorMessage = "Champ obligatoire"), MaxLength(100)]
        public string Prenom { get; set; }

        [DisplayName("TELEPHONE")]
        [Required(ErrorMessage = "Champ obligatoire"), MaxLength(12)]
        public string Telephone { get; set; }

        [DisplayName("COURRIEL")]
        [Required(ErrorMessage = "Champ obligatoire"), MaxLength(200), EmailAddress]
        public string Email { get; set; }

        [DisplayName("EN RETARD")]
        public bool EnRetard { get; set; }

        // ========================== RELATIONS ================================\\

        //1 to N
        // [InverseProperty("")]
       // public virtual ICollection<Pret> Prets { get; set; }
       // public int PretID { get; set; }
        //public virtual Pret Pret { get; set; }
    }
}