using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Models
{
    public class HomeIndex
    {
        public IEnumerable<BienEchangeListItem> BiensEchanges { get; set; }
        public IEnumerable<Pays> ListPays { get; set; }
        public IEnumerable<MembreDetails> Membres { get; set; }
        public ConnectionForm Connection { get; set; }
        public MembreCreate CreationMembre { get; set; }

        //public IEnumerable<CategoriesDetails> Categories { get; set; }
    }
}
