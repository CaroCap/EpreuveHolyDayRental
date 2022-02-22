
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HoliDayRental.Models
{
    public class BienEchangeListItem
    {
        [ScaffoldColumn(false)]
        [Key]
        public int idBien { get; set; }

        [DisplayName("Titre")]
        public string titre { get; set; }

        [DisplayName("Resumé")]
        public string DescCourte { get; set; }

        [DisplayName("Capacité")]
        public int NombrePerson { get; set; }
        
        [ScaffoldColumn(false)]
        public int idPays { get; set; }
        
        [DisplayName("Photo")]
        public string Photo { get; set; }

    }
}
