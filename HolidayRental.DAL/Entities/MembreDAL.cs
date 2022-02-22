
namespace HolidayRental.DAL.Entities
{
    public class MembreDAL
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public int Pays { get; set; }
        public string Telephone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

    }
}

//[idMembre]  INT IDENTITY(1, 1) NOT NULL,
//[Nom]       NVARCHAR (50)  NOT NULL,
//[Prenom]    NVARCHAR (50)  NOT NULL,
//[Email]     NVARCHAR (256) NOT NULL,
//[Pays]      INT            NOT NULL,
//[Telephone] NVARCHAR (20)  NOT NULL,
//[Login]     NVARCHAR (50)  NOT NULL,
//[Password]  NVARCHAR (256) NOT NULL,