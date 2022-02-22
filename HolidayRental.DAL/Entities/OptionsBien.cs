using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayRental.DAL.Entities
{
    public class OptionsBien
    {
        public int idBien { get; set; }
        public int idOption { get; set; }
        public string Valeur { get; set; }
    }
}

//    [idOption] INT NOT NULL,
//    [idBien]   INT           NOT NULL,
//    [Valeur]   NVARCHAR (50) NOT NULL,