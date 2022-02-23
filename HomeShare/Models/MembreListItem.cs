
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HoliDayRental.Models
{
    public class MembreListItem
    {
        [ScaffoldColumn(false)]
        [Key]
        public int idMembre { get; set; }

        [DisplayName("Nom")]
        public string Nom { get; set; }

        [DisplayName("Prénom")]
        public string Prenom { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public int idPays { get; set; }
        public Pays Pays { get; set; }

        [DisplayName("Pays")]
        public string NomPays { get { return this.Pays.Libelle; } }

        [DisplayName("Téléphone")]
        public string Telephone { get; set; }

    }
}
