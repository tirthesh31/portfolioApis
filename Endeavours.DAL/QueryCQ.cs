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
    public class QueryRepository : ICommandAndQuery<Query>
    {
        private readonly string _ConnectionString;

        public QueryRepository()
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

        public List<Query> GetAll()
        {
            throw new NotImplementedException();
        }

        public Query GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public int Insert(Query data)
        {
            return 0;
        }

        public bool Update(Query query, int fId)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UpdateQuery";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", query.Name);
                    command.Parameters.AddWithValue("@Email", query.Email);
                    command.Parameters.AddWithValue("@Subject", query.Subject);
                    command.Parameters.AddWithValue("@Message", query.Message);
                    command.Parameters.AddWithValue("@AskDate", query.AskDate);
                    command.Parameters.AddWithValue("@ReplySubject", query.ReplySubject);
                    command.Parameters.AddWithValue("@ReplyMessage", query.ReplyMessage);
                    command.Parameters.AddWithValue("@ReplyDate", query.ReplyDate);
                    command.Parameters.AddWithValue("@FID", fId);

                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected > 0;
        }
    }
}
