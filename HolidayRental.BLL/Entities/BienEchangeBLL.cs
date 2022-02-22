using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayRental.BLL.Entities
{
    public class BienEchangeBLL
    {
        public int idBien { get; set; }
        public string titre { get; set; }
        public string DescCourte { get; set; }
        public string DescLong { get; set; }
        public int NombrePerson { get; set; }
        public PaysBLL Pays { get; set; }
        public int idPays { get; set; }
        public string Ville { get; set; }
        public string Rue { get; set; }
        public string Numero { get; set; }
        public string CodePostal { get; set; }
        public string Photo { get; set; }
        public bool AssuranceObligatoire { get; set; }
        public bool isEnabled { get; set; }
        public DateTime? DisabledDate { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public MembreBLL Membre { get; set; }
        public int idMembre { get; set; }
        public DateTime DateCreation { get; set; }


        //Constructor
        // int paysID
        // int membreID
        public BienEchangeBLL(int id, string titr, string descCourte, string descLong, int nbrePerson, PaysBLL pays, string ville, string rue, string num, string codeP, string photo, bool assurance, string lat, string longitude, MembreBLL membre)
        {
            idBien = id;
            titre = titr;
            DescCourte = descCourte;
            DescLong = descLong;
            NombrePerson = nbrePerson;
            Pays = pays;
            if (pays == null) throw new ArgumentNullException(nameof(idPays));
            idPays = pays.idPays;
            Ville = ville;
            Rue = rue;
            Numero = num;
            CodePostal = codeP;
            Photo = photo;
            AssuranceObligatoire = assurance;
            Latitude = lat;
            Longitude = longitude;
            Membre = membre;
            if (membre == null) throw new ArgumentNullException(nameof(idMembre));
            idMembre = membre.idMembre;
        }

        public BienEchangeBLL(int id, string titr, string descCourte, string descLong, int nbrePerson, int paysID, string ville, string rue, string num, string codeP, string photo, bool assurance, string lat, string longitude, int membreID)
        {
            idBien = id;
            titre = titr;
            DescCourte = descCourte;
            DescLong = descLong;
            NombrePerson = nbrePerson;
            idPays = paysID;
            Ville = ville;
            Rue = rue;
            Numero = num;
            CodePostal = codeP;
            Photo = photo;
            AssuranceObligatoire = assurance;
            Latitude = lat;
            Longitude = longitude;
            idMembre = membreID;
        }
    }
}

//[idBien]               INT IDENTITY(1, 1) NOT NULL,
//[titre]                NVARCHAR(50)  NOT NULL,
//[DescCourte]           NVARCHAR(150) NOT NULL,
//[DescLong]             NTEXT NOT NULL,
//[NombrePerson]         INT NOT NULL,
//[Pays]                 INT CONSTRAINT[DF_BienEchange_Pays] DEFAULT((1)) NOT NULL,
//[Ville]                NVARCHAR(50)  NOT NULL,
//[Rue]                  NVARCHAR(50)  NOT NULL,
//[Numero]               NVARCHAR(5)   NOT NULL,
//[CodePostal]           NVARCHAR(50)  NOT NULL,
//[Photo]                NVARCHAR(50)  NOT NULL,
//[AssuranceObligatoire] BIT CONSTRAINT[DF_BienEchange_AssuranceObligatoire] DEFAULT((0)) NOT NULL,
//[isEnabled]            BIT CONSTRAINT[DF_BienEchange_isEnabled] DEFAULT((0)) NOT NULL,
//[DisabledDate]         DATE NULL,
//[Latitude]             NVARCHAR(50)  NOT NULL,
//[Longitude]            NVARCHAR(50)  NOT NULL,
//[idMembre]             INT NOT NULL,
//[DateCreation]         DATE