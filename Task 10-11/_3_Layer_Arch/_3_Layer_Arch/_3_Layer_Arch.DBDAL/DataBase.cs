using _3_Layer_Arch.DAL.Interfaces;
using _3_Layer_Arch.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace _3_Layer_Arch.DBDAL
{
    public class DataBase : IStorable
    {
        string _connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=users_awardsDB;Integrated Security=True";
        #region ADD
        public void AddUser(User user) // "sp_InsertUser"
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_InsertUser";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@name";
                parameter1.SqlDbType = SqlDbType.NVarChar;
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = user.Name;
                command.Parameters.Add(parameter1);

                SqlParameter parameter2 = new SqlParameter();
                parameter2.ParameterName = "@date";
                parameter2.SqlDbType = SqlDbType.Date;
                parameter2.Direction = ParameterDirection.Input;
                parameter2.Value = user.BirthDay;
                command.Parameters.Add(parameter2);

                SqlParameter parameter3 = new SqlParameter();
                parameter3.ParameterName = "@age";
                parameter3.SqlDbType = SqlDbType.Int;
                parameter3.Direction = ParameterDirection.Input;
                parameter3.Value = user.Age;
                command.Parameters.Add(parameter3);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void AddNewAward(Award award) // "sp_InsertNewAward"
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_InsertNewAward";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@title";
                parameter1.SqlDbType = SqlDbType.NVarChar;
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = award.Title;
                command.Parameters.Add(parameter1);

                //SqlParameter parameter2 = new SqlParameter();
                //parameter2.ParameterName = "@image";
                //parameter2.SqlDbType = SqlDbType.VarBinary;
                //parameter2.Direction = ParameterDirection.Input;
                //parameter2.Value = null;
                //command.Parameters.Add(parameter2);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void AddAwardForUser(User user, Award award) // "sp_InsertAwardForUser"
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_InsertAwardForUser";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@userId";
                parameter1.SqlDbType = SqlDbType.Int;
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = user.Id;
                command.Parameters.Add(parameter1);

                SqlParameter parameter2 = new SqlParameter();
                parameter2.ParameterName = "@awardId";
                parameter2.SqlDbType = SqlDbType.Int;
                parameter2.Direction = ParameterDirection.Input;
                parameter2.Value = award.Id;
                command.Parameters.Add(parameter2);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        #endregion
        #region EDIT
        public void EditAward(string id, Award award) //"sp_UpdateAward"
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_UpdateAward";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@title";
                parameter1.SqlDbType = SqlDbType.NVarChar;
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = award.Title;
                command.Parameters.Add(parameter1);

                SqlParameter parameter2 = new SqlParameter();
                parameter2.ParameterName = "@id";
                parameter2.SqlDbType = SqlDbType.Int;
                parameter2.Direction = ParameterDirection.Input;
                parameter2.Value = int.Parse(id);
                command.Parameters.Add(parameter2);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void EditUser(string id, User user) //"sp_UpdateUser"
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_UpdateUser";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@name";
                parameter1.SqlDbType = SqlDbType.NVarChar;
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = user.Name;
                command.Parameters.Add(parameter1);

                SqlParameter parameter2 = new SqlParameter();
                parameter2.ParameterName = "@date";
                parameter2.SqlDbType = SqlDbType.Date;
                parameter2.Direction = ParameterDirection.Input;
                parameter2.Value = user.BirthDay;
                command.Parameters.Add(parameter2);

                SqlParameter parameter3 = new SqlParameter();
                parameter3.ParameterName = "@age";
                parameter3.SqlDbType = SqlDbType.Int;
                parameter3.Direction = ParameterDirection.Input;
                parameter3.Value = user.Age;
                command.Parameters.Add(parameter3);

                SqlParameter parameter4 = new SqlParameter();
                parameter4.ParameterName = "@id";
                parameter4.SqlDbType = SqlDbType.Int;
                parameter4.Direction = ParameterDirection.Input;
                parameter4.Value = int.Parse(id);
                command.Parameters.Add(parameter4);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        #endregion
        #region GET
        public IList<User> GetAllUsers() //"sp_GetAllUsers"
        {
            IList<User> users = new List<User>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT [Id]"
                    + ",[Name]"
                    + ",[Date]"
                    + ",[Age]"
                    + "FROM[users_awardsDB].[dbo].[Users]";

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(new User
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        BirthDay = (DateTime)reader["Date"],
                        //DateTime birthDay = DateTime.ParseExact(date, "dd.MM.yyyy", null);
                        Age = (int)reader["Age"]
                    });
                }
            }
            return users;
        }
        public IList<Award> GetAllAwards() //"sp_GetAllAwards"
        {
            IList<Award> awards = new List<Award>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT [Id]"
                    + ",[Title]"
                    + "FROM[users_awardsDB].[dbo].[Awards]";

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    awards.Add(new Award
                    {
                        Id = (int)reader["Id"],
                        Title = (string)reader["Title"],
                    });
                }
            }
            return awards;
        }

        public IList<AwardsAndUsers> GetAllAwardsUsers() //"sp_GetAllAwardsUsers"
        {
            IList<AwardsAndUsers> usersAndAwards = new List<AwardsAndUsers>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT [UserId]"
                    + ",[AwardId]"
                    + "FROM[users_awardsDB].[dbo].[AwardsAndUsers]";

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    usersAndAwards.Add(new AwardsAndUsers
                    {
                        UserId = (int)reader["UserId"],
                        AwardId = (int)reader["AwardId"]
                    });
                }
            }
            return usersAndAwards;
        }
        #endregion
        #region DELETE
        public void RemoveUser(int id) //"sp_DeleteUser"
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_DeleteUser";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@UserId";
                parameter1.SqlDbType = SqlDbType.Int;
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = id;
                command.Parameters.Add(parameter1);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void DeleteAward(int id) // "sp_DeleteAward"
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_DeleteAward";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@AwardId";
                parameter1.SqlDbType = SqlDbType.Int;
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = id;
                command.Parameters.Add(parameter1);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void DeleteAwardFromUser(string userId, string awardId) //"sp_DeleteAwardFromUser"
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_DeleteAwardFromUser";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@UserId";
                parameter1.SqlDbType = SqlDbType.Int;
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = userId;
                command.Parameters.Add(parameter1);

                SqlParameter parameter2 = new SqlParameter();
                parameter2.ParameterName = "@AwardId";
                parameter2.SqlDbType = SqlDbType.Int;
                parameter2.Direction = ParameterDirection.Input;
                parameter2.Value = awardId;
                command.Parameters.Add(parameter2);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteAwardFromUsers(string awardId) //"sp_DeleteAwardFromUsers"
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_DeleteAwardFromUsers";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@AwardId";
                parameter1.SqlDbType = SqlDbType.Int;
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = awardId;
                command.Parameters.Add(parameter1);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        #endregion
    }
}
