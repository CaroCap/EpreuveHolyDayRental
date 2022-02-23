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
    public class MembreService : IMembreRepository<MembreBLL>
    {
        // On va créer un IRepository de ce IRepository
        private readonly IMembreRepository<MembreDAL> _MembreRepository;
        private readonly IPaysRepository<PaysDAL> _PaysRepository;

        public MembreService(IMembreRepository<MembreDAL> repository, IPaysRepository<PaysDAL> paysRepository)
        {
            _MembreRepository = repository;
            _PaysRepository = paysRepository;
        }

        // Création du CRUD 
        public void Delete(int id)
        {
            _MembreRepository.Delete(id);
        }

        public MembreBLL Get(int id)
        {
            MembreBLL result = _MembreRepository.Get(id).ToBLL();
            result.Pays = _PaysRepository.Get(result.Pays_ID).ToBLL();
            return result;
        }
        public IEnumerable<MembreBLL> Get()
        {
            return _MembreRepository.Get().Select(d =>
            {
                MembreBLL result = d.ToBLL();
                result.Pays = _PaysRepository.Get(result.Pays_ID).ToBLL();
                return result;
            });
        }

        public int Insert(MembreBLL entity)
        {
            return _MembreRepository.Insert(entity.ToDAL());
        }

        public void Update(int id, MembreBLL entity)
        {
            _MembreRepository.Update(id, entity.ToDAL());
        }
    }
}
