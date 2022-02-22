
using System;

namespace HolidayRental.DAL.Entities
{
    public class MembreBienEchangeDAL
    {
        public int idMembre { get; set; }
        public int idBien { get; set; }
        public DateTime DateDebEchange { get; set; }
        public DateTime DateFinEchange { get; set; }
        public bool? Assurance { get; set; }
        public bool Valide { get; set; }
    }
}


//    [idMembre]       INT NOT NULL,
//    [idBien]         INT  NOT NULL,
//    [DateDebEchange] DATE NOT NULL,
//    [DateFinEchange] DATE NOT NULL,
//    [Assurance]      BIT  NULL,
//    [Valide]         BIT