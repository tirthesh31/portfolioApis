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
    public class ReferenceRepository : ICommandAndQuery<Reference>
    {
        private readonly string _ConnectionString;

        public ReferenceRepository()
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

        public List<Reference> GetAll()
        {
            throw new NotImplementedException();
        }

        public Reference GetByID(int ID)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                string query = "SelectReferencesByUserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", ID);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Reference reference = new Reference
                            {
                                UserID = Convert.ToInt32(reader["UserID"]),
                                ReferenceName = reader["ReferenceName"].ToString(),
                                OrgName = reader["OrgName"].ToString(),
                                Passion = reader["Passion"].ToString(),
                                Email = reader["Email"].ToString()
                            };

                            return reference;
                        }

                    }
                }
            }
            return null;
        }
        public int Insert(Reference data)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                string query = "InsertReference";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", data.UserID);
                    command.Parameters.AddWithValue("@ReferenceName", data.ReferenceName);
                    command.Parameters.AddWithValue("@OrgName", data.OrgName);
                    command.Parameters.AddWithValue("@Passion", data.Passion);
                    command.Parameters.AddWithValue("@Email", data.Email);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        public bool Update(Reference reference, int userId)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UpdateReference";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ReferenceName", reference.ReferenceName);
                    command.Parameters.AddWithValue("@OrgName", reference.OrgName);
                    command.Parameters.AddWithValue("@Passion", reference.Passion);
                    command.Parameters.AddWithValue("@Email", reference.Email);
                    command.Parameters.AddWithValue("@UserID", userId);

                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected > 0;
        }
    }
}
