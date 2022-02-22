
using System;
using System.Collections.Generic;

namespace HolidayRental.BLL.Entities
{
    public class MembreBLL
    {
        public int idMembre { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public PaysBLL Pays { get; set; }
        public int Pays_Id { get; set; }
        public string Telephone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }


        public IEnumerable<PaysBLL> LesPays { get; set; }

        // Constructeur
        public MembreBLL(int id, string nom, string prenom, string email, PaysBLL pays, string telephone, string login, string password )
        {
            idMembre = id;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Pays = pays;
            if (pays == null) throw new ArgumentNullException(nameof(Pays_Id));
            Pays_Id = pays.idPays;
            Telephone = telephone;
            Login = login;
            Password = password;
        }

        public MembreBLL(int id, string nom, string prenom, string email, int paysID, string telephone, string login, string password)
        {
            idMembre = id;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Pays_Id = paysID;
            Telephone = telephone;
            Login = login;
            Password = password;
        }
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