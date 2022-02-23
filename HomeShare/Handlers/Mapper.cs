using HolidayRental.BLL.Entities;
using HoliDayRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Handlers
{
    public static class Mapper
    {
        public static BienEchangeListItem ToListItem(this BienEchangeBLL entity)
        {
            if (entity == null) return null;
            return new BienEchangeListItem
            {
                idBien = entity.idBien,
                titre = entity.titre,
                DescCourte = entity.DescCourte,
                idPays = entity.Pays.idPays,
                NombrePerson = entity.NombrePerson,
                Photo = entity.Photo,
                Ville = entity.Ville
            };
        }

        public static BienEchangeDetails ToDetails(this BienEchangeBLL entity)
        {
            if (entity == null) return null;
            return new BienEchangeDetails
            {
                idBien = entity.idBien,
                titre = entity.titre,
                DescCourte = entity.DescCourte,
                DescLong = entity.DescLong,
                idPays = entity.Pays.idPays,
                NombrePerson = entity.NombrePerson,
                Ville = entity.Ville,
                Rue = entity.Rue,
                Numero = entity.Numero,
                CodePostal = entity.CodePostal,
                Photo = entity.Photo,
                AssuranceObligatoire = entity.AssuranceObligatoire,
                Latitude = entity.Latitude,
                Longitude = entity.Longitude,
                idMembre = entity.Membre.idMembre,
            };
        }

        public static Pays ToDetails(this PaysBLL entity)
        {
            if (entity == null) return null;
            return new Pays
            {
                idPays = entity.idPays,
                Libelle = entity.Libelle
            };
        }
    }
}
