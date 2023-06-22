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
    public class WorkExperienceRepository : ICommandAndQuery<WorkExperience>
    {
        private readonly string _ConnectionString;

        public WorkExperienceRepository()
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

        public List<WorkExperience> GetAll()
        {
            throw new NotImplementedException();
        }

        public WorkExperience GetByID(int ID)
        {
           using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                string query = "SelectWorkExperienceByID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", ID);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            WorkExperience workExperience = new WorkExperience
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                UserID = Convert.ToInt32(reader["UserID"]),
                                Position = reader["Position"].ToString(),
                                Company = reader["Company"].ToString(),
                                Location = reader["Location"].ToString(),
                                Duration = reader["Duration"].ToString(),
                                Description = reader["Description"].ToString()
                            };

                            return workExperience;
                        }
                    }
                }
            }

            return null;
        }
    

        public int Insert(WorkExperience data)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                string query = "InsertWorkExperience";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", data.UserID);
                    command.Parameters.AddWithValue("@Position", data.Position);
                    command.Parameters.AddWithValue("@Company", data.Company);
                    command.Parameters.AddWithValue("@Location", data.Location);
                    command.Parameters.AddWithValue("@Duration", data.Duration);
                    command.Parameters.AddWithValue("@Description", data.Description);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        public bool Update(WorkExperience workExperience, int id)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UpdateWorkExperience";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Position", workExperience.Position);
                    command.Parameters.AddWithValue("@Company", workExperience.Company);
                    command.Parameters.AddWithValue("@Location", workExperience.Location);
                    command.Parameters.AddWithValue("@Duration", workExperience.Duration);
                    command.Parameters.AddWithValue("@Description", workExperience.Description);
                    command.Parameters.AddWithValue("@ID", id);

                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected > 0;
        }
    }
}
