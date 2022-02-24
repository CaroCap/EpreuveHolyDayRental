
//using System;
//using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;

//namespace HoliDayRental.Models
//{
//    public class BienEchange5Last
//    {
//        [ScaffoldColumn(false)]
//        [Key]
//        public int idBien { get; set; }

//        [DisplayName("Titre")]
//        public string titre { get; set; }

//        [DisplayName("Photo")]
//        public string Photo { get; set; }
//        public string Ville { get; set; }


//        [ScaffoldColumn(false)]
//        public int idPays { get; set; }
//        public Pays Pays { get; set; }

//        [DisplayName("Pays")]
//        public string NomPays { get { return this.Pays.Libelle; } }

//    }
//}
