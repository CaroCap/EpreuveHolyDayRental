using HolidayRental.BLL.Entities;
using HolidayRental.BLL.Handlers;
using HolidayRental.Common.Repositories;
using HolidayRental.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HolidayRental.BLL.Services
{
    //Ajouter public pour la classe + :IRepository pour qu'elle implémente la classe
    public class BienEchangeService : IBienEchangeRepository<BienEchangeBLL>
    {
        // On va créer un IRepository de ce IRepository
        private readonly IBienEchangeRepository<BienEchangeDAL> _BienEchangeRepository;
        private readonly IMembreRepository<MembreDAL> _MembreRepository;
        private readonly IPaysRepository<PaysDAL> _PaysRepository;

        public BienEchangeService(IBienEchangeRepository<BienEchangeDAL> repository, IMembreRepository<MembreDAL> membreRepository, IPaysRepository<PaysDAL> paysRepository)
        {
            _BienEchangeRepository = repository;
            _MembreRepository = membreRepository;
            _PaysRepository = paysRepository;
        }

        // Création du CRUD 
        public void Delete(int id)
        {
            _BienEchangeRepository.Delete(id);
        }

        public BienEchangeBLL Get(int id)
        {
            BienEchangeBLL result = _BienEchangeRepository.Get(id).ToBLL();
            result.Membre = _MembreRepository.Get(result.Membre_ID).ToBLL();
            result.Pays = _PaysRepository.Get(result.Pays_ID).ToBLL();
            return result;
        }
        public IEnumerable<BienEchangeBLL> Get()
        {
            return _BienEchangeRepository.Get().Select(d =>
            {
                BienEchangeBLL result = d.ToBLL();
                result.Membre = _MembreRepository.Get(result.Membre_ID).ToBLL();
                result.Pays = _PaysRepository.Get(result.Pays_ID).ToBLL();
                return result;
            });
        }

        public int Insert(BienEchangeBLL entity)
        {
            return _BienEchangeRepository.Insert(entity.ToDAL());
        }

        public void Update(int id, BienEchangeBLL entity)
        {
            _BienEchangeRepository.Update(id, entity.ToDAL());
        }
    }
}
