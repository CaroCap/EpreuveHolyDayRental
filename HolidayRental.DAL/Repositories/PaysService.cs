using HolidayRental.Common.Repositories;
using HolidayRental.DAL.Entities;
using HolidayRental.DAL.Handlers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HolidayRental.DAL.Repositories
{
    public class PaysService : ServiceBase, IPaysRepository<PaysDAL>
    {
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM [Pays] WHERE [idPays] = @id";
                    SqlParameter p_id = new SqlParameter() { ParameterName = "id", Value = id };
                    command.Parameters.Add(p_id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public PaysDAL Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idPays],[Libelle] FROM [Pays] WHERE [idPays] = @id";
                    SqlParameter p_id = new SqlParameter() { ParameterName = "id", Value = id };
                    command.Parameters.Add(p_id);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read()) return Mapper.ToPays(reader);
                    return null;
                }
            }
        }

        public IEnumerable<PaysDAL> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idPays],[Libelle] FROM [Pays]";
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) yield return Mapper.ToPays(reader);
                }
            }
        }

        public int Insert(PaysDAL entity)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO [Pays]([Libelle]) OUTPUT [inserted].[idPays] " +
                        "VALUES (@Libelle)";
                    SqlParameter p_libelle = new SqlParameter { ParameterName = "Libelle", Value = entity.Libelle };


                    command.Parameters.Add(p_libelle);


                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public void Update(int id, PaysDAL entity)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE [Pays] SET [Libelle] = @Libelle" +
                        "WHERE [idPays] = @id";
                    SqlParameter p_libelle = new SqlParameter { ParameterName = "Libelle", Value = entity.Libelle };

                    command.Parameters.Add(p_libelle);


                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
