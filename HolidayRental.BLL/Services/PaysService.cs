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
    public class PaysService : IPaysRepository<PaysBLL>
    {
        // On va créer un IRepository de ce IRepository
        private readonly IPaysRepository<PaysDAL> _PaysRepository;

        public PaysService(IPaysRepository<PaysDAL> repository)
        {
            _PaysRepository = repository;
        }

        // Création du CRUD 
        public void Delete(int id)
        {
            _PaysRepository.Delete(id);
        }

        public PaysBLL Get(int id)
        {
            return _PaysRepository.Get(id).ToBLL();

        }
        public IEnumerable<PaysBLL> Get()
        {
            return _PaysRepository.Get().Select(p => p.ToBLL());

        }

        public int Insert(PaysBLL entity)
        {
            return _PaysRepository.Insert(entity.ToDAL());
        }

        public void Update(int id, PaysBLL entity)
        {
            _PaysRepository.Update(id, entity.ToDAL());
        }
    }
}
