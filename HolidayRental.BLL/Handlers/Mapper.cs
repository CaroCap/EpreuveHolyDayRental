using HolidayRental.BLL.Entities;
using HolidayRental.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
// Ajouter une dépendance pour lier avec DAL et Common
namespace HolidayRental.BLL.Handlers
{
    public static class Mapper
    {
        public static MembreBLL ToBLL(this MembreDAL entity) 
        {
            if (entity == null) return null;
            return new MembreBLL(
                entity.idMembre, 
                entity.Nom, 
                entity.Prenom, 
                entity.Email, 
                // Est-ce que PAYS est correct ? pas Pays_Id ???
                entity.Pays, 
                entity.Telephone, 
                entity.Login, 
                entity.Password);
        }

        public static MembreDAL ToDAL(this MembreBLL entity)
        {
            if (entity == null) return null;
            return new MembreDAL
            {
                idMembre = entity.idMembre,
                Nom = entity.Nom,
                Prenom = entity.Prenom,
                Email = entity.Email,
                Pays = entity.idPays,
                Telephone = entity.Telephone,
                Login = entity.Login,
                Password = entity.Password
            };
        }

        public static BienEchangeBLL ToBLL(this BienEchangeDAL entity)
        {
            if (entity == null) return null;
            return new BienEchangeBLL(
                entity.idBien,
                entity.titre,
                entity.DescCourte,
                entity.DescLong,
                // Est-ce que PAYS est correct ? pas Pays_Id ???
                entity.NombrePerson,
                entity.Pays,
                entity.Ville,
                entity.Rue,
                entity.Numero,
                entity.CodePostal,
                entity.Photo,
                entity.AssuranceObligatoire,
                entity.Latitude,
                entity.Longitude,
                entity.idMembre
                );
        }

        public static BienEchangeDAL ToDAL(this BienEchangeBLL entity)
        {
            if (entity == null) return null;
            return new BienEchangeDAL
            {
                idBien = entity.idBien,
                titre = entity.titre,
                DescCourte = entity.DescCourte,
                DescLong = entity.DescLong,
                Pays = entity.Pays_ID,
                NombrePerson = entity.NombrePerson,
                Ville = entity.Ville,
                Rue = entity.Rue,
                Numero = entity.Numero,
                CodePostal = entity.CodePostal,
                Photo = entity.Photo,
                AssuranceObligatoire = entity.AssuranceObligatoire,
                Latitude = entity.Latitude,
                Longitude = entity.Longitude,
                idMembre = entity.Membre_ID
            };
        }

        public static PaysBLL ToBLL(this PaysDAL entity)
        {
            if (entity == null) return null;
            return new PaysBLL(
                entity.idPays,
                entity.Libelle);
        }

        public static PaysDAL ToDAL(this PaysBLL entity)
        {
            if (entity == null) return null;
            return new PaysDAL
            {
                idPays = entity.idPays,
                Libelle = entity.Libelle                
            };
        }
    }
}
