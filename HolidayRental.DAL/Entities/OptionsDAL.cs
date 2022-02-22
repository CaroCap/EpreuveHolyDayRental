
namespace HolidayRental.DAL.Entities
{
    public class OptionsDAL
    {
        public int idOption { get; set; }
        public string Libelle { get; set; }

        //[idOption] INT IDENTITY(1, 1) NOT NULL,
        //[Libelle]  NVARCHAR(50) NOT NULL,
    }
}
