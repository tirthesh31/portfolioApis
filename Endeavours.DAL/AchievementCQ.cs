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
    public class AchievementRepository : ICommandAndQuery<Achievement>
    {
        private readonly string _ConnectionString;

        public AchievementRepository()
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

        public List<Achievement> GetAll()
        {
            throw new NotImplementedException();
        }

        public Achievement GetByID(int ID)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                string query = "SelectAchievementByID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", ID);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Achievement achievement = new Achievement
                            {
                                UserID = Convert.ToInt32(reader["UserID"]),
                                AchievementName = reader["AchievementName"].ToString(),
                                Year = Convert.ToInt32(reader["Year"]),
                                Place = reader["Place"].ToString(),
                                Description = reader["Description"].ToString()
                            };

                            return achievement;
                        }
                    }
                }
            }
            return null;
        }
        public int Insert(Achievement data)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                string query = "InsertAchievement";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", data.UserID);
                    command.Parameters.AddWithValue("@AchievementName", data.AchievementName);
                    command.Parameters.AddWithValue("@Year", data.Year);
                    command.Parameters.AddWithValue("@Place", data.Place);
                    command.Parameters.AddWithValue("@Description", data.Description);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        public bool Update(Achievement achievement, int userId)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UpdateAchievement";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@AchievementName", achievement.AchievementName);
                    command.Parameters.AddWithValue("@Year", achievement.Year);
                    command.Parameters.AddWithValue("@Place", achievement.Place);
                    command.Parameters.AddWithValue("@Description", achievement.Description);
                    command.Parameters.AddWithValue("@UserID", userId);

                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected > 0;
        }
    }
}
