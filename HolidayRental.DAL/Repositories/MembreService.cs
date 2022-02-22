using HolidayRental.Common.Repositories;
using HolidayRental.DAL.Entities;
using HolidayRental.DAL.Handlers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HolidayRental.DAL.Repositories
{
    public class MembreService : ServiceBase, IMembreRepository<MembreDAL>
    {
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM [Membre] WHERE [idMembre] = @id";
                    SqlParameter p_id = new SqlParameter() { ParameterName = "id", Value = id };
                    command.Parameters.Add(p_id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public MembreDAL Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idMembre],[Nom],[Prenom],[Email],[Pays],[Telephone],[Login],[Password] FROM [Membre] WHERE [idMembre] = @id";
                    SqlParameter p_id = new SqlParameter() { ParameterName = "id", Value = id };
                    command.Parameters.Add(p_id);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read()) return Mapper.ToMembre(reader);
                    return null;
                }
            }
        }

        public IEnumerable<MembreDAL> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idBien],[Nom],[Prenom],[Email],[Pays],[Telephone],[Login],[Password] FROM [Membre]";
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) yield return Mapper.ToMembre(reader);
                }
            }
        }

        public int Insert(MembreDAL entity)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO [Membre]([Nom],[Prenom],[Email],[Pays],[Telephone],[Login],[Password]) OUTPUT [inserted].[idMembre] " +
                        "VALUES (@Nom,@Prenom,@Email,@Pays,@Telephone,@Login,@Password)";
                    SqlParameter p_titre = new SqlParameter { ParameterName = "Nom", Value = entity.Nom };
                    SqlParameter p_DescCourte = new SqlParameter { ParameterName = "Prenom", Value = entity.Prenom };
                    SqlParameter p_DescLong = new SqlParameter { ParameterName = "Email", Value = entity.Email };
                    SqlParameter p_Pays = new SqlParameter { ParameterName = "Pays", Value = entity.Pays };
                    SqlParameter p_Ville = new SqlParameter { ParameterName = "Telephone", Value = entity.Telephone };
                    SqlParameter p_Rue = new SqlParameter { ParameterName = "Login", Value = entity.Login };
                    SqlParameter p_Numero = new SqlParameter { ParameterName = "Password", Value = entity.Password };

                    command.Parameters.Add(p_titre);
                    command.Parameters.Add(p_DescCourte);
                    command.Parameters.Add(p_DescLong);
                    command.Parameters.Add(p_Pays);
                    command.Parameters.Add(p_Ville);
                    command.Parameters.Add(p_Rue);
                    command.Parameters.Add(p_Numero);

                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public void Update(int id, MembreDAL entity)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE [Membre] SET [Nom] = @Nom, [Prenom] = @Prenom, [Email] = @Email, [Pays]=@Pays, [Telephone]=@Telephone, [Login]=@Login, [Password]=@Password" +
                        "WHERE [idMembre] = @id";
                    SqlParameter p_titre = new SqlParameter { ParameterName = "Nom", Value = entity.Nom };
                    SqlParameter p_DescCourte = new SqlParameter { ParameterName = "Prenom", Value = entity.Prenom };
                    SqlParameter p_DescLong = new SqlParameter { ParameterName = "Email", Value = entity.Email };
                    SqlParameter p_Pays = new SqlParameter { ParameterName = "Pays", Value = entity.Pays };
                    SqlParameter p_Ville = new SqlParameter { ParameterName = "Telephone", Value = entity.Telephone };
                    SqlParameter p_Rue = new SqlParameter { ParameterName = "Login", Value = entity.Login };
                    SqlParameter p_Numero = new SqlParameter { ParameterName = "Password", Value = entity.Password };

                    command.Parameters.Add(p_titre);
                    command.Parameters.Add(p_DescCourte);
                    command.Parameters.Add(p_DescLong);
                    command.Parameters.Add(p_Pays);
                    command.Parameters.Add(p_Ville);
                    command.Parameters.Add(p_Rue);
                    command.Parameters.Add(p_Numero);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
