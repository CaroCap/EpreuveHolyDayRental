
namespace HolidayRental.BLL.Entities
{
    public class PaysBLL
    {
        public int idPays { get; set; }
        public string Libelle { get; set; }

        //[idPays] INT IDENTITY(1, 1) NOT NULL,
        //[Libelle] NVARCHAR(50) NOT NULL,

        public PaysBLL(int id, string libelle)
        {
            idPays = id;
            Libelle = libelle;
        }
    }
}
