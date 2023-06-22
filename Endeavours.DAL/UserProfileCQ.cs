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
    public class UserProfileRepository : ICommandAndQuery<UserProfile>
    {
        private readonly string _ConnectionString;

        public UserProfileRepository()
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

        public List<UserProfile> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserProfile GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public int Insert(UserProfile data)
        {
            throw new NotImplementedException();
        }

        public bool Update(UserProfile data, int ID)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUserProfile(UserProfile userProfile, int userId)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UpdateUserProfile";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FullName", userProfile.FullName);
                    command.Parameters.AddWithValue("@Bio", userProfile.Bio);
                    command.Parameters.AddWithValue("@ProfilePicture", userProfile.ProfilePicture);
                    command.Parameters.AddWithValue("@Dob", userProfile.Dob);
                    command.Parameters.AddWithValue("@Website", userProfile.Website);
                    command.Parameters.AddWithValue("@Contact", userProfile.Contact);
                    command.Parameters.AddWithValue("@Address", userProfile.Address);
                    command.Parameters.AddWithValue("@Profession", userProfile.Profession);
                    command.Parameters.AddWithValue("@City", userProfile.City);
                    command.Parameters.AddWithValue("@JobType", userProfile.JobType);
                    command.Parameters.AddWithValue("@UserID", userId);

                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected > 0;
        }
    }
}
