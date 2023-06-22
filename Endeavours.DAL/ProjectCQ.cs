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
    public class ProjectRepository : ICommandAndQuery<Project>
    {
        private readonly string _ConnectionString;

        public ProjectRepository()
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

        public List<Project> GetAll()
        {
            throw new NotImplementedException();
        }

        public Project GetByID(int ID)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                string query = "SelectProjectByID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", ID);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Project project = new Project
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                UserID = Convert.ToInt32(reader["UserID"]),
                                ProjectName = reader["ProjectName"].ToString(),
                                Category = reader["Category"].ToString(),
                                Description = reader["Description"].ToString(),
                                TechnologiesUsed = reader["TechnologiesUsed"].ToString(),
                                Year = Convert.ToInt32(reader["Year"]),
                                Client = reader["Client"].ToString(),
                                StartDate = Convert.ToDateTime(reader["StartDate"]),
                                EndDate = Convert.ToDateTime(reader["EndDate"]),

                                // Convert the comma-separated string of images to an array
                                Images = reader["Images"].ToString().Split(',')
                            };

                            return project;
                        }
                    }
                }
            }

            return null;
        }

        public int Insert(Project data)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                string query = "InsertProject";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", data.UserID);
                    command.Parameters.AddWithValue("@ProjectName", data.ProjectName);
                    command.Parameters.AddWithValue("@Category", data.Category);
                    command.Parameters.AddWithValue("@Description", data.Description);
                    command.Parameters.AddWithValue("@TechnologiesUsed", data.TechnologiesUsed);
                    command.Parameters.AddWithValue("@Year", data.Year);
                    command.Parameters.AddWithValue("@Client", data.Client);
                    command.Parameters.AddWithValue("@StartDate", data.StartDate);
                    command.Parameters.AddWithValue("@EndDate", data.EndDate);

                    // Convert the array of images to a single string
                    string imagesString = string.Join(",", data.Images);
                    command.Parameters.AddWithValue("@Images", imagesString);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        public bool Update(Project project, int id)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UpdateProject";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProjectName", project.ProjectName);
                    command.Parameters.AddWithValue("@Category", project.Category);
                    command.Parameters.AddWithValue("@Description", project.Description);
                    command.Parameters.AddWithValue("@TechnologiesUsed", project.TechnologiesUsed);
                    command.Parameters.AddWithValue("@Year", project.Year);
                    command.Parameters.AddWithValue("@Client", project.Client);
                    command.Parameters.AddWithValue("@StartDate", project.StartDate);
                    command.Parameters.AddWithValue("@EndDate", project.EndDate);
                    command.Parameters.AddWithValue("@ID", id);

                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected > 0;
        }
    }
}
