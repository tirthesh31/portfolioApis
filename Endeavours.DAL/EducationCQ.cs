using Endeavours.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endeavours.DAL
{
    public class EducationRepository : ICommandAndQuery<Education>
    {
        private readonly string _ConnectionString;

        public EducationRepository()
        {
            Connection connect = new Connection();
            _ConnectionString = connect.GetConnectionString();
            connect = null;
        }
        public int Count()
        {
            throw new NotImplementedException();
        }

        public bool Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public List<Education> GetAll()
        {
            throw new NotImplementedException();
        }

        public Education GetByID(int ID)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                string query = "SelectEducation";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", ID);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Education education = new Education
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                UserID = Convert.ToInt32(reader["UserID"]),
                                Degree = reader["Degree"].ToString(),
                                Institution = reader["Institution"].ToString(),
                                Location = reader["Location"].ToString(),
                                StartYear = Convert.ToInt32(reader["StartYear"]),
                                EndYear = Convert.ToInt32(reader["EndYear"])
                            };

                            return education;
                        }
                    }
                }
            }

            return null;
        }

        public int Insert(Education data)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                string query = "InsertEducation";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", data.UserID);
                    command.Parameters.AddWithValue("@Degree", data.Degree);
                    command.Parameters.AddWithValue("@Institution", data.Institution);
                    command.Parameters.AddWithValue("@Location", data.Location);
                    command.Parameters.AddWithValue("@StartYear", data.StartYear);
                    command.Parameters.AddWithValue("@EndYear", data.EndYear);

                    connection.Open();
                    int rows = command.ExecuteNonQuery();
                    return rows;
                }
                return 0;
            }
        }

        public bool Update(Education education, int id)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UpdateEducation";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Degree", education.Degree);
                    command.Parameters.AddWithValue("@Institution", education.Institution);
                    command.Parameters.AddWithValue("@Location", education.Location);
                    command.Parameters.AddWithValue("@StartYear", education.StartYear);
                    command.Parameters.AddWithValue("@EndYear", education.EndYear);
                    command.Parameters.AddWithValue("@ID", id);

                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected > 0;
        }
    }
}
