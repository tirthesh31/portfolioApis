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
    public class SkillRepository : ICommandAndQuery<Skill>
    {
        private readonly string _ConnectionString;

        public SkillRepository()
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

        public List<Skill> GetAll()
        {
            throw new NotImplementedException();
        }

        public Skill GetByID(int ID)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                string query = "SelectSkillByID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", ID);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Skill skill = new Skill
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                UserID = Convert.ToInt32(reader["UserID"]),
                                SkillName = reader["SkillName"].ToString(),
                                Proficiency = Convert.ToInt32(reader["Proficiency"])
                            };

                            return skill;
                        }
                    }
                }
            }

            return null;
        }

        public int Insert(Skill data)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                string query = "InsertSkill";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", data.UserID);
                    command.Parameters.AddWithValue("@SkillName",data.SkillName);
                    command.Parameters.AddWithValue("@Proficiency", data.Proficiency);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        public bool Update(Skill skill, int id)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UpdateSkill";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SkillName", skill.SkillName);
                    command.Parameters.AddWithValue("@Proficiency", skill.Proficiency);
                    command.Parameters.AddWithValue("@ID", id);

                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected > 0;
        }
    }
}
