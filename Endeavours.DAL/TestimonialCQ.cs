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
    public class TestimonialRepository : ICommandAndQuery<Testimonial>
    {
        private readonly string _ConnectionString;

        public TestimonialRepository()
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

        public List<Testimonial> GetAll()
        {
            throw new NotImplementedException();
        }

        public Testimonial GetByID(int ID)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                string query = "SelectTestimonialsByUserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", ID);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Testimonial testimonial = new Testimonial
                            {
                                UserID = Convert.ToInt32(reader["UserID"]),
                                CommentorID = Convert.ToInt32(reader["CommentorID"]),
                                Message = reader["Message"].ToString()
                            };
                            return testimonial;
                        }

                    }
                }
            }
            return null;
        }
        public int Insert(Testimonial data)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                string query = "InsertTestimonils";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", data.UserID);
                    command.Parameters.AddWithValue("@CommentorID", data.CommentorID);
                    command.Parameters.AddWithValue("@Message", data.Message);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        public bool Update(Testimonial testimonial, int userId)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UpdateTestimonial";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CommentorId", testimonial.CommentorID);
                    command.Parameters.AddWithValue("@Message", testimonial.Message);
                    command.Parameters.AddWithValue("@UserID", userId);

                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected > 0;
        }
    }
}
