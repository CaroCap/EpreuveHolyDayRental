using System;

namespace HolidayRental.DAL.Entities
{
    public class AvisMembreBienDAL
    {
        public int idAvis { get; set; }
        public int note { get; set; }
        public string message { get; set; }
        public int idMembre { get; set; }
        public int idBien { get; set; }
        public DateTime DateAvis { get; set; }
        public bool Approuve { get; set; }
    }
}

//[idAvis]   INT IDENTITY(1, 1) NOT NULL,
//[note]     INT      NOT NULL,
//[message]  NTEXT    NOT NULL,
//[idMembre] INT      NOT NULL,
//[idBien]   INT      NOT NULL,
//[DateAvis] DATETIME NOT NULL,
//[Approuve] BIT 