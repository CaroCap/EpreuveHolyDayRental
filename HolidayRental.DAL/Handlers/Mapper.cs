using HolidayRental.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HolidayRental.DAL.Handlers
{
    public static class Mapper
    {

        public static AvisMembreBienDAL ToAvisMembreBien(IDataRecord record)
        {
            if (record is null) return null;
            return new AvisMembreBienDAL
            {
                idAvis = (int)record[nameof(AvisMembreBienDAL.idAvis)],
                note = (int)record[nameof(AvisMembreBienDAL.note)],
                message = (string)record[nameof(AvisMembreBienDAL.message)],
                idMembre = (int)record[nameof(AvisMembreBienDAL.idMembre)],
                idBien = (int)record[nameof(AvisMembreBienDAL.idBien)],
                DateAvis = (DateTime)record[nameof(AvisMembreBienDAL.DateAvis)],
                Approuve = (bool)record[nameof(AvisMembreBienDAL.Approuve)]
            };
        }

        public static BienEchangeDAL ToBienEchange(IDataRecord record)
        {
            if (record is null) return null;
            return new BienEchangeDAL
            {
                idBien = (int)record[nameof(BienEchangeDAL.idBien)],
                titre = (string)record[nameof(BienEchangeDAL.titre)],
                DescCourte = (string)record[nameof(BienEchangeDAL.Prenom)],
                DescLong = (string)record[nameof(BienEchangeDAL.DescLong)],
                NombrePerson = (int)record[nameof(BienEchangeDAL.NombrePerson)],
                Pays = (int)record[nameof(BienEchangeDAL.Pays)],
                Ville = (string)record[nameof(BienEchangeDAL.Ville)],
                Rue = (string)record[nameof(BienEchangeDAL.Rue)],
                Numero = (string)record[nameof(BienEchangeDAL.Numero)],
                CodePostal = (string)record[nameof(BienEchangeDAL.CodePostal)],
                Photo = (string)record[nameof(BienEchangeDAL.Photo)],
                AssuranceObligatoire = (bool)record[nameof(BienEchangeDAL.AssuranceObligatoire)],
                isEnabled = (bool)record[nameof(BienEchangeDAL.isEnabled)],
                DisabledDate = (record[nameof(BienEchangeDAL.DisabledDate)] is DBNull)? null :(DateTime?)record[nameof(BienEchangeDAL.DisabledDate)],
                Latitude = (string)record[nameof(BienEchangeDAL.Latitude)],
                Longitude = (string)record[nameof(BienEchangeDAL.Longitude)],
                idMembre = (int)record[nameof(BienEchangeDAL.idMembre)],
                DateCreation = (DateTime)record[nameof(BienEchangeDAL.DateCreation)]
            };
        }

        public static MembreBienEchangeDAL ToMembreBienEchange(IDataRecord record)
        {
            if (record is null) return null;
            return new MembreBienEchangeDAL
            {
                idMembre = (int)record[nameof(MembreBienEchangeDAL.idMembre)],
                idBien = (int)record[nameof(MembreBienEchangeDAL.idBien)],
                DateDebEchange = (DateTime)record[nameof(MembreBienEchangeDAL.DateDebEchange)],
                DateFinEchange = (DateTime)record[nameof(MembreBienEchangeDAL.DateFinEchange)],
                Assurance = (record[nameof(MembreBienEchangeDAL.Assurance)] is DBNull)? null :(bool?)record[nameof(MembreBienEchangeDAL.Assurance)],
                Valide = (bool)record[nameof(MembreBienEchangeDAL.Valide)]
            };
        }

        public static MembreDAL ToMembre(IDataRecord record)
        {
            if (record is null) return null;
            return new MembreDAL
            {
                Id = (int)record[nameof(MembreDAL.Id)],
                Nom = (string)record[nameof(MembreDAL.Nom)],
                Prenom = (string)record[nameof(MembreDAL.Prenom)],
                Email = (string)record[nameof(MembreDAL.Email)],
                Pays = (int)record[nameof(MembreDAL.Pays)],
                Telephone = (string)record[nameof(MembreDAL.Telephone)],
                Login = (string)record[nameof(MembreDAL.Login)],
                Password = (string)record[nameof(MembreDAL.Password)]
            };
        }

        public static OptionsBienDAL ToOptionsBien(IDataRecord record)
        {
            if (record is null) return null;
            return new OptionsBienDAL
            {
                idBien = (int)record[nameof(OptionsBienDAL.idBien)],
                idOption = (int)record[nameof(OptionsBienDAL.idOption)],
                Valeur = (string)record[nameof(OptionsBienDAL.Valeur)]
            };
        }

        public static OptionsDAL ToOptions(IDataRecord record)
        {
            if (record is null) return null;
            return new OptionsDAL
            {
                idOption = (int)record[nameof(OptionsDAL.idOption)],
                Libelle = (string)record[nameof(OptionsDAL.Libelle)]
            };
        }

        public static PaysDAL ToPays(IDataRecord record)
        {
            if (record is null) return null;
            return new PaysDAL
            {
                idPays = (int)record[nameof(PaysDAL.idPays)],
                Libelle = (string)record[nameof(PaysDAL.Libelle)]
            };
        }
    }
}


    /// <summary>
    /// Si une colone est nullable, il faut faire un test de sa nullité avant de l'envoyer dans le DTO
    /// </summary>
    // DateDiffusion = (record[nameof(Diffusion.DateDiffusion)] is DBNull)? null :(DateTime?)record[nameof(Diffusion.DateDiffusion)],