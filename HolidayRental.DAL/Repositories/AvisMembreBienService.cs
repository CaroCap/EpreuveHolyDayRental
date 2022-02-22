using HolidayRental.Common.Repositories;
using HolidayRental.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HolidayRental.DAL.Repositories
{
    public class AvisMembreBienService : ServiceBase, IAvisMembreBienRepository<AvisMembreBienDAL>
    {
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM [AvisMembreBien] WHERE [idAvis] = @id";
                    SqlParameter p_id = new SqlParameter() { ParameterName = "id", Value = id };
                    command.Parameters.Add(p_id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public AvisMembreBienDAL Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AvisMembreBienDAL> Get()
        {
            throw new NotImplementedException();
        }

        public int Insert(AvisMembreBienDAL entity)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, AvisMembreBienDAL entity)
        {
            throw new NotImplementedException();
        }
    }
}
