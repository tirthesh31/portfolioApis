using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endeavours.DAL;
using Endeavours.Entities;

namespace Endeavours.DAL
{
    public class UserRepository : ICommandAndQuery<User>
    {
        private readonly string _ConnectionString;

        public UserRepository()
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

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public FirstPageView GetFirstPageView(int ID)
        {
            try
            {
                // Create a SqlConnection object
                using (SqlConnection connection = new SqlConnection(_ConnectionString))
                {
                    connection.Open();

                    // Create a SqlCommand object for the stored procedure
                    using (SqlCommand command = new SqlCommand("[dbo].[GetUserProfileDetails]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@id", ID);
                        SqlDataReader reader = command.ExecuteReader();
                        FirstPageView view = new FirstPageView();

                        while (reader.Read())
                        {
                            view.FullName = reader["FullName"].ToString();
                            view.Profession = reader["Profession"].ToString();
                            view.City = reader["City"].ToString();
                            view.InstaLink = reader["InstaLink"].ToString();
                            view.FacebookLink = reader["FacebookLink"].ToString();
                            view.GithubLink = reader["GithubLink"].ToString();
                            view.LinkedInLink = reader["LinkedInLink"].ToString();
                            view.OtherLinks = reader["OtherLinks"].ToString();
                        }
                        reader.Close();
                        connection.Close();
                        return view;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors
                Console.WriteLine("Error: " + ex.Message);
            }
            return null;
        }

        public int GetByEmailPassword(string email, string password)
        {
            try
            {
                // Create a SqlConnection object
                using (SqlConnection connection = new SqlConnection(_ConnectionString))
                {
                    connection.Open();

                    // Create a SqlCommand object for the stored procedure
                    using (SqlCommand command = new SqlCommand("[dbo].[Login]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@password", password);


                        int result = (int)command.ExecuteScalar();
                        connection.Close();
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors
                Console.WriteLine("Error: " + ex.Message);
            }
            return 0;
        }

        public bool CheckUserNameExists(string Username)
        {
            try
            {
                // Create a SqlConnection object
                using (SqlConnection connection = new SqlConnection(_ConnectionString))
                {
                    connection.Open();

                    // Create a SqlCommand object for the stored procedure
                    using (SqlCommand command = new SqlCommand("[dbo].[CheckUserNameExists]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@username", Username);

                        int result = (int)command.ExecuteScalar();
                        connection.Close();
                        return result >= 1?true:false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors
                Console.WriteLine("Error: " + ex.Message);
            }
            return true;
        }

        public bool CheckEmailExists(string Email)
        {
            try
            {
                // Create a SqlConnection object
                using (SqlConnection connection = new SqlConnection(_ConnectionString))
                {
                    connection.Open();

                    // Create a SqlCommand object for the stored procedure
                    using (SqlCommand command = new SqlCommand("[dbo].[CheckEmailExists]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@email", Email);

                        int result = (int)command.ExecuteScalar();
                        connection.Close();
                        return result >= 1 ? true : false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors
                Console.WriteLine("Error: " + ex.Message);
            }
            return true;
        }


        public int Insert(User data)
        {
            throw new NotImplementedException();
        }

        public bool Update(User user,int id)
        {
            int i = -1;
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UpdateUser";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@RegistrationDate", user.RegistrationDate);
                    command.Parameters.AddWithValue("@IsActive", user.IsActive);
                    connection.Close();
                    i = command.ExecuteNonQuery();
                }
            }
            return i == 1;
        }


        public int Register(User userdata, UserProfile userprofileData)
        {
            int lastInsertID = 0;
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "[dbo].[Registration]";
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the User table
                    command.Parameters.AddWithValue("@username", userdata.Username);
                    command.Parameters.AddWithValue("@email", userdata.Email);
                    command.Parameters.AddWithValue("@password", userdata.Password);

                    // Add parameters for the UserProfile table
                    command.Parameters.AddWithValue("@fullName", userprofileData.FullName);
                    command.Parameters.AddWithValue("@bio", userprofileData.Bio);
                    command.Parameters.AddWithValue("@profilePicture", userprofileData.ProfilePicture);
                    command.Parameters.AddWithValue("@dob", userprofileData.Dob);
                    command.Parameters.AddWithValue("@website", userprofileData.Website);
                    command.Parameters.AddWithValue("@contact", userprofileData.Contact);
                    command.Parameters.AddWithValue("@address", userprofileData.Address);
                    command.Parameters.AddWithValue("@profession", userprofileData.Profession);
                    command.Parameters.AddWithValue("@city", userprofileData.City);
                    command.Parameters.AddWithValue("@jobType", userprofileData.JobType);

                    // Execute the command and retrieve the last inserted ID
                    lastInsertID = (int)command.ExecuteScalar();
                }
                connection.Close();
            }
            return lastInsertID;
        }


        public string GetUserNameAndFullNamefromEmail(string email)
        {
            string UserNameFullName = null;
            try
            {
                // Create a SqlConnection object
                using (SqlConnection connection = new SqlConnection(_ConnectionString))
                {
                    connection.Open();

                    // Create a SqlCommand object for the stored procedure
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"select top 1 FullName+'('+username+')' as name from users inner join UserProfiles on users.ID = UserProfiles.UserID where email = @email";
                        command.Parameters.AddWithValue("@email", email);

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                            UserNameFullName = reader["name"].ToString();

                        reader.Close();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors
                Console.WriteLine("Error: " + ex.Message);
            }

            return UserNameFullName;
        }


        public List<OtherUserView> GetTopSixUsers()
        {
            try
            {
                List<OtherUserView> listView = null;
                // Create a SqlConnection object
                using (SqlConnection connection = new SqlConnection(_ConnectionString))
                {
                    connection.Open();

                    // Create a SqlCommand object for the stored procedure
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = @"GetTop6Users";

                        SqlDataReader reader = command.ExecuteReader();
                        listView = new List<OtherUserView>();
                        while (reader.Read())
                        {
                            OtherUserView view = new OtherUserView()
                            {
                                FullName = reader["FullName"].ToString(),
                                UserName = reader["UserName"].ToString(),
                                ProfilePhoto = reader["ProfilePicture"].ToString(),
                                Profession = reader["Profession"].ToString(),
                                City = reader["City"].ToString()
                            };
                            listView.Add(view);
                        }
                        reader.Close();
                        connection.Close();
                    }
                }
                return listView;
            }
            catch (Exception ex)
            {
                // Handle any errors
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }

    }
}
