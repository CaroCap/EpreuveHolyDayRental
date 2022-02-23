using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Models
{
    public class Pays
    {
        [ScaffoldColumn(false)]
        [Key]
        public int idPays { get; set; }
        
        [DisplayName("Pays")]
        public string Libelle { get; set; }
    }
}
