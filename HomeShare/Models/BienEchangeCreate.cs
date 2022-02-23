
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HoliDayRental.Models
{
    public class BienEchangeCreate
    {

        [Required]
        [DisplayName("Titre")]
        [DataType(DataType.Text)]
        public string titre { get; set; }

        [Required]
        [DisplayName("Resumé")]
        [DataType(DataType.Text)]
        public string DescCourte { get; set; }

        [Required]
        [DisplayName("Description")]
        [DataType(DataType.Text)]
        public string DescLong { get; set; }

        [Required]
        [DisplayName("Capacité")]
        [DataType(DataType.Text)]
        public int NombrePerson { get; set; }

        [ScaffoldColumn(false)]
        [Required]
        public int idPays { get; set; }
        [DisplayName("Pays")]
        public IEnumerable<Pays> PaysList { get; set; }

        [Required]
        [DisplayName("Ville")]
        [DataType(DataType.Text)]
        public string Ville { get; set; }

        [Required]
        [DisplayName("Rue")]
        [DataType(DataType.Text)]
        public string Rue { get; set; }

        [Required]
        [DisplayName("Numéro")]
        [DataType(DataType.Text)]
        public string Numero { get; set; }

        [Required]
        [DisplayName("Code Postal")]
        [DataType(DataType.PostalCode)]
        public string CodePostal { get; set; }

        [Required]
        [DisplayName("Photo")]
        [DataType(DataType.Text)]
        public string Photo { get; set; }

        [Required]
        [DisplayName("Assurance")]
        public bool AssuranceObligatoire { get; set; }

        [Required]
        [DisplayName("Latitude")]
        [DataType(DataType.Text)]
        public string Latitude { get; set; }

        [Required]
        [DisplayName("Longitude")]
        [DataType(DataType.Text)]
        public string Longitude { get; set; }

        [Required]
        public int idMembre { get; set; }

    }
}
