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
    public class ServiceRepository : ICommandAndQuery<Service>
    {
        private readonly string _ConnectionString;

        public ServiceRepository()
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

        public List<Service> GetAll()
        {
            throw new NotImplementedException();
        }

        public Service GetByID(int ID)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                string query = "SelectServicesByUserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", ID);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Service service = new Service
                            {
                                SType = reader["SType"].ToString(),
                                UID = Convert.ToInt32(reader["UID"]),
                                Description = reader["Description"].ToString()
                            };

                            return service;
                        }

                    }
                }
            }
            return null;
        }
        public int Insert(Service data)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                string query = "InsertService";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SType", data.SType);
                    command.Parameters.AddWithValue("@UID", data.UID);
                    command.Parameters.AddWithValue("@Description", data.Description);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        public bool Update(Service service, int sId)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UpdateService";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SType", service.SType);
                    command.Parameters.AddWithValue("@Desc", service.Description);
                    command.Parameters.AddWithValue("@SID", sId);

                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected > 0;
        }
    }
}
