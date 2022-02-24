using HolidayRental.Common.Repositories;
using HolidayRental.DAL.Entities;
using HolidayRental.DAL.Handlers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HolidayRental.DAL.Repositories
{
    public class BienEchangeService : ServiceBase, IBienEchangeRepository<BienEchangeDAL>
    {
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM [BienEchange] WHERE [idBien] = @id";
                    SqlParameter p_id = new SqlParameter() { ParameterName = "id", Value = id };
                    command.Parameters.Add(p_id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public BienEchangeDAL Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idBien],[titre],[DescCourte],[DescLong],[NombrePerson],[Pays],[Ville],[Rue],[Numero],[CodePostal],[Photo],[AssuranceObligatoire],[isEnabled],[DisabledDate],[Latitude],[Longitude],[idMembre],[DateCreation] FROM [BienEchange] WHERE [idBien] = @id";
                    SqlParameter p_id = new SqlParameter() { ParameterName = "id", Value = id };
                    command.Parameters.Add(p_id);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read()) return Mapper.ToBienEchange(reader);
                    return null;
                }
            }
        }

        public IEnumerable<BienEchangeDAL> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idBien],[titre],[DescCourte],[DescLong],[NombrePerson],[Pays],[Ville],[Rue],[Numero],[CodePostal],[Photo],[AssuranceObligatoire],[isEnabled],[DisabledDate],[Latitude],[Longitude],[idMembre],[DateCreation] FROM [BienEchange]";
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) yield return Mapper.ToBienEchange(reader);
                }
            }
        }

        public int Insert(BienEchangeDAL entity)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO [BienEchange]([titre],[DescCourte],[DescLong],[NombrePerson],[Pays],[Ville],[Rue],[Numero],[CodePostal],[Photo],[AssuranceObligatoire],[Latitude],[Longitude],[idMembre]) OUTPUT [inserted].[idBien] " +
                        "VALUES (@titre,@DescCourte,@DescLong,@NombrePerson,@Pays,@Ville,@Rue,@Numero,@CodePostal,@Photo,@AssuranceObligatoire,@Latitude,@Longitude,@idMembre)";
                    SqlParameter p_titre = new SqlParameter { ParameterName = "titre", Value = entity.titre };
                    SqlParameter p_DescCourte = new SqlParameter { ParameterName = "DescCourte", Value = entity.DescCourte };
                    SqlParameter p_DescLong = new SqlParameter { ParameterName = "DescLong", Value = entity.DescLong };
                    SqlParameter p_NombrePerson = new SqlParameter { ParameterName = "NombrePerson", Value = entity.NombrePerson };
                    SqlParameter p_Pays = new SqlParameter { ParameterName = "Pays", Value = entity.Pays };
                    SqlParameter p_Ville = new SqlParameter { ParameterName = "Ville", Value = entity.Ville };
                    SqlParameter p_Rue = new SqlParameter { ParameterName = "Rue", Value = entity.Rue };
                    SqlParameter p_Numero = new SqlParameter { ParameterName = "Numero", Value = entity.Numero };
                    SqlParameter p_CodePostal = new SqlParameter { ParameterName = "CodePostal", Value = entity.CodePostal };
                    SqlParameter p_Photo = new SqlParameter { ParameterName = "Photo", Value = entity.Photo };
                    SqlParameter p_AssuranceObligatoire = new SqlParameter { ParameterName = "AssuranceObligatoire", Value = entity.AssuranceObligatoire };
                    SqlParameter p_Latitude = new SqlParameter { ParameterName = "Latitude", Value = entity.Latitude };
                    SqlParameter p_Longitude = new SqlParameter { ParameterName = "Longitude", Value = entity.Longitude };
                    SqlParameter p_idMembre = new SqlParameter { ParameterName = "idMembre", Value = entity.idMembre };

                    command.Parameters.Add(p_titre);
                    command.Parameters.Add(p_DescCourte);
                    command.Parameters.Add(p_DescLong);
                    command.Parameters.Add(p_NombrePerson);
                    command.Parameters.Add(p_Pays);
                    command.Parameters.Add(p_Ville);
                    command.Parameters.Add(p_Rue);
                    command.Parameters.Add(p_Numero);
                    command.Parameters.Add(p_CodePostal);
                    command.Parameters.Add(p_Photo);
                    command.Parameters.Add(p_AssuranceObligatoire);
                    command.Parameters.Add(p_Latitude);
                    command.Parameters.Add(p_Longitude);
                    command.Parameters.Add(p_idMembre);

                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public IEnumerable<BienEchangeDAL> Last5Biens()
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM [Vue_CinqDernierBiens]";
                    //Parameters...
                    
                    connection.Open();
                    //Choose Execution method
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) yield return Mapper.ToBienEchange(reader);
                }
            }

        }

        public void Update(int id, BienEchangeDAL entity)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE [BienEchange] SET [titre] = @titre, [DescCourte] = @DescCourte, [DescLong] = @DescLong, [NombrePerson]=@NombrePerson, [Pays]=@Pays, [Ville]=@Ville, [Rue]=@Rue, [Numero]=@Numero, [CodePostal]=@CodePostal, [Photo]=@Photo, [AssuranceObligatoire]=@AssuranceObligatoire, [isEnabled]=@isEnabled, [DisabledDate]=@DisabledDate, [Latitude]=@Latitude, [Longitude]=@Longitude, [idMembre]=@idMembre, [DateCreation]=@DateCreation" +
                        "WHERE [idBien] = @id";
                    SqlParameter p_titre = new SqlParameter { ParameterName = "titre", Value = entity.titre };
                    SqlParameter p_DescCourte = new SqlParameter { ParameterName = "DescCourte", Value = entity.DescCourte };
                    SqlParameter p_DescLong = new SqlParameter { ParameterName = "DescLong", Value = entity.DescLong };
                    SqlParameter p_NombrePerson = new SqlParameter { ParameterName = "NombrePerson", Value = entity.NombrePerson };
                    SqlParameter p_Pays = new SqlParameter { ParameterName = "Pays", Value = entity.Pays };
                    SqlParameter p_Ville = new SqlParameter { ParameterName = "Ville", Value = entity.Ville };
                    SqlParameter p_Rue = new SqlParameter { ParameterName = "Rue", Value = entity.Rue };
                    SqlParameter p_Numero = new SqlParameter { ParameterName = "Numero", Value = entity.Numero };
                    SqlParameter p_CodePostal = new SqlParameter { ParameterName = "CodePostal", Value = entity.CodePostal };
                    SqlParameter p_Photo = new SqlParameter { ParameterName = "Photo", Value = entity.Photo };
                    SqlParameter p_AssuranceObligatoire = new SqlParameter { ParameterName = "AssuranceObligatoire", Value = entity.AssuranceObligatoire };
                    SqlParameter p_isEnabled = new SqlParameter { ParameterName = "isEnabled", Value = entity.isEnabled };
                    SqlParameter p_DisabledDate = new SqlParameter { ParameterName = "DisabledDate", Value = entity.DisabledDate };
                    SqlParameter p_Latitude = new SqlParameter { ParameterName = "Latitude", Value = entity.Latitude };
                    SqlParameter p_Longitude = new SqlParameter { ParameterName = "Longitude", Value = entity.Longitude };
                    SqlParameter p_idMembre = new SqlParameter { ParameterName = "idMembre", Value = entity.idMembre };

                    command.Parameters.Add(p_titre);
                    command.Parameters.Add(p_DescCourte);
                    command.Parameters.Add(p_DescLong);
                    command.Parameters.Add(p_NombrePerson);
                    command.Parameters.Add(p_Pays);
                    command.Parameters.Add(p_Ville);
                    command.Parameters.Add(p_Rue);
                    command.Parameters.Add(p_Numero);
                    command.Parameters.Add(p_CodePostal);
                    command.Parameters.Add(p_Photo);
                    command.Parameters.Add(p_AssuranceObligatoire);
                    command.Parameters.Add(p_isEnabled);
                    command.Parameters.Add(p_DisabledDate);
                    command.Parameters.Add(p_Latitude);
                    command.Parameters.Add(p_Longitude);
                    command.Parameters.Add(p_idMembre);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
