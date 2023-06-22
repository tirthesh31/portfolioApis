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
    public class InterestRepository : ICommandAndQuery<Interest>
    {
        private readonly string _ConnectionString;
        public InterestRepository()
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

        public List<Interest> GetAll()
        {
            throw new NotImplementedException();
        }

        public Interest GetByID(int ID)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                string query = "SelectInterestsByUserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", ID);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Interest interest = new Interest
                            {
                                interestId = Convert.ToInt32(reader["InterestID"]),
                                name = reader["Name"].ToString(),
                                userId = Convert.ToInt32(reader["UserID"])
                            };
                            return interest;
                        }

                    }
                }
            }
            return null;
        }        
        public int Insert(Interest data)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                string query = "InsertInterest";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", data.name);
                    command.Parameters.AddWithValue("@UserID", data.userId);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        
        public int Update(Interest data, int ID)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                string query = "UpdateInterest";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@InterestID", ID);
                    command.Parameters.AddWithValue("@Name", data.name);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        bool ICommandAndQuery<Interest>.Update(Interest data, int ID)
        {
            throw new NotImplementedException();
        }
    }
}
