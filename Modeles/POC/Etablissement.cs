using Modeles.Validation;
using ModelesApi.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ModelesApi.POC
{
    public class Etablissement
    {
        [Key]
        public Guid Id { get; set; }

        //sensé être une enum
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ce champ est obligatoire")]
        [TypeEtablissementAttributeRange(ErrorMessage = "Il n'y a que 4 valeurs possibles pour ce champ : Bar, Boite de Nuit, Salle de Concert, Cercle Etudiant")]
        public string Type { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ce champ est obligatoire")]
        [MaxLength(50, ErrorMessage = "Maximum 50 charactères")]
        public string Nom { get; set; }

        // a verifie via l'api
        public string NumeroTva { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ce champ est obligatoire")]
        [EmailAddress(ErrorMessage = "L'adresse mail doit être valide")]
        [MaxLength(255, ErrorMessage = "Maximum 255 charactères")]
        public string AdresseEmailPro { get; set; }

        [MaxLength(2000, ErrorMessage = "Maximum 2000 charactères")]
        public string ZoneTexteLibre { get; set; }

        // a voir si il s'agit juste du nom du fichier ? vérifier l'extension ?
        public string Logo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ce champ est obligatoire")]
        [MaxLength(20, ErrorMessage = "Maximum 20 charactères")]
        public string CodePostal { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ce champ est obligatoire")]
        [MaxLength(100, ErrorMessage = "Maximum 100 charactères")]
        public string Ville { get; set; }

        //liste déroulante avec tous les pays
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ce champ est obligatoire")]
        public Pays pays { get; set; }
       
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ce champ est obligatoire")]
        [MaxLength(100, ErrorMessage = "Maximum 100 charactères")]
        public string Rue { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ce champ est obligatoire")]
        [MaxLength(20, ErrorMessage = "Maximum 20 charactères")]
        public string NumeroBoite { get; set; }

        [Display(Name = "Numéro de gsm ou fixe")]
        [MaxLength(25, ErrorMessage = "Maximum 25 charactères")]
        [Phone(ErrorMessage = "Le numéro de téléphone doit être valide")]
        public string NumeroTelephone { get; set; }

        [EmailAddress(ErrorMessage = "L'adresse mail doit être valide")]
        [MaxLength(255, ErrorMessage = "Maximum 255 charactères")]
        public string AdresseEmailEtablissement { get; set; }

        [Url(ErrorMessage = "L'adresse web doit être valide")]
        public string AdresseSiteWeb { get; set; }

        [Url(ErrorMessage = "L'adresse web doit être valide")]
        public string AdresseInstagram { get; set; }

        [Url(ErrorMessage = "L'adresse web doit être valide")]
        public string AdresseFacebook { get; set; }

        [Url(ErrorMessage = "L'adresse web doit être valide")]
        public string AdresseLinkedin { get; set; }

        [ListePhotoEtablissementValidationRange(5)]
        public List<PhotoEtablissement> lPhotos { get; set; }

        public List<Horaire> lHoraire { get; set; }

    }
}
