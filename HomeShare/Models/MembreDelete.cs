using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Models
{
    public class MembreDelete
    {
        [DisplayName("Nom de famille")]
        public string Nom { get; set; }
        [DisplayName("Prénom")]
        public string Prenom { get; set; }
        public string Login { get; set; }
        [Required]
        [DisplayName("Êtes-vous sûr de vouloir supprimer ce compte ?")]
        public bool Validate { get; set; }
    }
}
