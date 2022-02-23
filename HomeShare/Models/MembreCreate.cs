
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HoliDayRental.Models
{
    public class MembreCreate
    {

        [Required]
        [DisplayName("Nom")]
        [DataType(DataType.Text)]
        public string Nom { get; set; }

        [Required]
        [DisplayName("Prénom")]
        [DataType(DataType.Text)]
        public string Prenom { get; set; }

        [Required]
        [DisplayName("Email")]
        [DataType(DataType.Text)]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        [Required]
        public int idPays { get; set; }
        [DisplayName("Pays")]
        public IEnumerable<Pays> PaysList { get; set; }

        [Required]
        [DisplayName("Téléphone")]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }

        [Required]
        [DisplayName("Login")]
        [DataType(DataType.Text)]
        public string Login { get; set; }

        [Required]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
