using Modeles.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Modeles
{
    public class Utilisateur
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ce champ est obligatoire")]
        [MaxLength(50, ErrorMessage = "Maximum 50 caractères")]
        [RegularExpression(@"^[a-zA-Z""'\s]*$", ErrorMessage ="Les caractères spéciaux et les chiffres ne sont pas acceptés")]
        public string Nom { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ce champ est obligatoire")]
        [MaxLength(50, ErrorMessage = "Maximum 50 caractères")]
        [RegularExpression(@"[a-zA-Z]", ErrorMessage = "Les caractères spéciaux et les chiffres ne sont pas acceptés")]
        public string Prenom { get; set; }

        //doit être unique
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ce champ est obligatoire")]
        [EmailAddress(ErrorMessage = "L'adresse mail doit être valide")]
        [MaxLength(255, ErrorMessage = "Maximum 255 caractères")]
        public string AdresseEmail { get; set; }

        [Display(Name = "Numéro de gsm")]
        [MaxLength(25, ErrorMessage = "Maximum 25 caractères")]
        [Phone(ErrorMessage = "Le numéro de téléphone doit être valide")]
        public string NumeroTelephone { get; set; }

        //liste déroulante
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ce champ est obligatoire")]
        [GenreAttributeRange(ErrorMessage = "Il n'y a que 3 valeurs possibles pour ce champ : Homme, Femme, Non-Binaire")]
        public string Sexe { get; set; }

        //a vérif
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ce champ est obligatoire")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateNaissance { get; set; }

        //voir comment se traduit le bool
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ce champ est obligatoire")]
        public bool estProfessionel { get; set; }

        public string Role { get; set; }
    }
}
