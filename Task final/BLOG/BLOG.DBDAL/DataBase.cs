using BLOG.DAL.Interfaces;
using BLOG.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.DBDAL
{
    public class DataBase : IStorable
    {
        string _connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=personalBlogDB;Integrated Security=True";

        public int AddPost(Post newPost)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_InsertPost";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@Title";
                parameter1.SqlDbType = SqlDbType.NVarChar;
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = newPost.Title;
                command.Parameters.Add(parameter1);

                SqlParameter parameter2 = new SqlParameter();
                parameter2.ParameterName = "@ShortDescription";
                parameter2.SqlDbType = SqlDbType.NVarChar;
                parameter2.Direction = ParameterDirection.Input;
                parameter2.Value = newPost.ShortDescription;
                command.Parameters.Add(parameter2);

                SqlParameter parameter3 = new SqlParameter();
                parameter3.ParameterName = "@Description";
                parameter3.SqlDbType = SqlDbType.NVarChar;
                parameter3.Direction = ParameterDirection.Input;
                parameter3.Value = newPost.Description;
                command.Parameters.Add(parameter3);

                SqlParameter parameter4 = new SqlParameter();
                parameter4.ParameterName = "@DataCreate";
                parameter4.SqlDbType = SqlDbType.DateTime;
                parameter4.Direction = ParameterDirection.Input;
                parameter4.Value = newPost.DataCreate;
                command.Parameters.Add(parameter4);

                SqlParameter parameter5 = new SqlParameter();
                parameter5.ParameterName = "@DataModified";
                parameter5.SqlDbType = SqlDbType.DateTime;
                parameter5.Direction = ParameterDirection.Input;
                parameter5.Value = newPost.DataModified;
                command.Parameters.Add(parameter5);

                SqlParameter parameter6 = new SqlParameter();
                parameter6.ParameterName = "@CategoryId";
                parameter6.SqlDbType = SqlDbType.Int;
                parameter6.Direction = ParameterDirection.Input;
                parameter6.Value = newPost.CategoryId;
                command.Parameters.Add(parameter6);

                connection.Open();
                command.ExecuteNonQuery();

                return (int)command.Parameters["@Id"].Value;
            }
        }

        public void AddTagForPost(PostTag newPostTag)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_AddTagForPost";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@PostId";
                parameter1.SqlDbType = SqlDbType.Int;
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = newPostTag.PostId;
                command.Parameters.Add(parameter1);

                SqlParameter parameter2 = new SqlParameter();
                parameter2.ParameterName = "@TagId";
                parameter2.SqlDbType = SqlDbType.Int;
                parameter2.Direction = ParameterDirection.Input;
                parameter2.Value = newPostTag.TagId;
                command.Parameters.Add(parameter2);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void AddBlackList(int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_AddBlackList";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@UserId";
                parameter1.SqlDbType = SqlDbType.Int;
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = userId;
                command.Parameters.Add(parameter1);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void AddNewUser(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_AddNewUser";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@Login";
                parameter1.SqlDbType = SqlDbType.NVarChar;
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = user.Login;
                command.Parameters.Add(parameter1);

                SqlParameter parameter2 = new SqlParameter();
                parameter2.ParameterName = "@Password";
                parameter2.SqlDbType = SqlDbType.NVarChar;
                parameter2.Direction = ParameterDirection.Input;
                parameter2.Value = user.Password;
                command.Parameters.Add(parameter2);

                SqlParameter parameter3 = new SqlParameter();
                parameter3.ParameterName = "@Email";
                parameter3.SqlDbType = SqlDbType.NVarChar;
                parameter3.Direction = ParameterDirection.Input;
                parameter3.Value = user.Email;
                command.Parameters.Add(parameter3);

                SqlParameter parameter4 = new SqlParameter();
                parameter4.ParameterName = "@DataRegistration";
                parameter4.SqlDbType = SqlDbType.DateTime;
                parameter4.Direction = ParameterDirection.Input;
                parameter4.Value = user.DataRegistration;
                command.Parameters.Add(parameter4);

                SqlParameter parameter5 = new SqlParameter();
                parameter5.ParameterName = "@MetaId";
                parameter5.SqlDbType = SqlDbType.Int;
                parameter5.Direction = ParameterDirection.Input;
                parameter5.Value = user.MetaId;
                command.Parameters.Add(parameter5);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public int AddMetaAboutUser(MetaAboutUser metaAboutUser)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_AddMetaAboutUser";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@Info";
                parameter1.SqlDbType = SqlDbType.NVarChar;
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = metaAboutUser.Info;
                command.Parameters.Add(parameter1);

                SqlParameter parameter2 = new SqlParameter();
                parameter2.ParameterName = "@DateBirth";
                parameter2.SqlDbType = SqlDbType.DateTime;
                parameter2.Direction = ParameterDirection.Input;
                parameter2.Value = metaAboutUser.DateBirth;
                command.Parameters.Add(parameter2);

                SqlParameter parameter3 = new SqlParameter();
                parameter3.ParameterName = "@Age";
                parameter3.SqlDbType = SqlDbType.Int;
                parameter3.Direction = ParameterDirection.Input;
                parameter3.Value = metaAboutUser.Age;
                command.Parameters.Add(parameter3);

                SqlParameter parameter4 = new SqlParameter();
                parameter4.ParameterName = "@Id";
                parameter4.SqlDbType = SqlDbType.Int;
                parameter4.Direction = ParameterDirection.Output;
                parameter4.Value = metaAboutUser.Info;
                command.Parameters.Add(parameter4);

                connection.Open();
                command.ExecuteNonQuery();

                return (int)command.Parameters["@Id"].Value;
            }
        }
        public void AddNewTag(Tag tag)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_AddNewTag";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@Name";
                parameter1.SqlDbType = SqlDbType.NVarChar;
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = tag.Name;
                command.Parameters.Add(parameter1);

                SqlParameter parameter2 = new SqlParameter();
                parameter2.ParameterName = "@Description";
                parameter2.SqlDbType = SqlDbType.NVarChar;
                parameter2.Direction = ParameterDirection.Input;
                parameter2.Value = tag.Description;
                command.Parameters.Add(parameter2);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void AddNewCategory(Category category)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_AddNewCategory";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@Name";
                parameter1.SqlDbType = SqlDbType.NVarChar;
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = category.Title;
                command.Parameters.Add(parameter1);

                SqlParameter parameter2 = new SqlParameter();
                parameter2.ParameterName = "@Description";
                parameter2.SqlDbType = SqlDbType.NVarChar;
                parameter2.Direction = ParameterDirection.Input;
                parameter2.Value = category.Description;
                command.Parameters.Add(parameter2);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void AddNewComment(PostComment comment)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_AddNewComment";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@PostId";
                parameter1.SqlDbType = SqlDbType.Int;
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = comment.PostId;
                command.Parameters.Add(parameter1);

                SqlParameter parameter2 = new SqlParameter();
                parameter2.ParameterName = "@UserId";
                parameter2.SqlDbType = SqlDbType.Int;
                parameter2.Direction = ParameterDirection.Input;
                parameter2.Value = comment.UserID;
                command.Parameters.Add(parameter2);

                SqlParameter parameter3 = new SqlParameter();
                parameter3.ParameterName = "@Description";
                parameter3.SqlDbType = SqlDbType.NVarChar;
                parameter3.Direction = ParameterDirection.Input;
                parameter3.Value = comment.Description;
                command.Parameters.Add(parameter3);

                SqlParameter parameter4 = new SqlParameter();
                parameter4.ParameterName = "@DataCreate";
                parameter4.SqlDbType = SqlDbType.DateTime;
                parameter4.Direction = ParameterDirection.Input;
                parameter4.Value = comment.DataCreate;
                command.Parameters.Add(parameter4);

                SqlParameter parameter5 = new SqlParameter();
                parameter5.ParameterName = "@DataModified";
                parameter5.SqlDbType = SqlDbType.DateTime;
                parameter5.Direction = ParameterDirection.Input;
                parameter5.Value = comment.DataModified;
                command.Parameters.Add(parameter5);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        //#endregion
        //#region GET
        public IList<Post> getAllPosts()
        {
            IList<Post> posts = new List<Post>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_GetAllPosts";
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    posts.Add(new Post
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        ShortDescription = reader.GetString(2),
                        Description = reader.GetString(3),
                        DataCreate = (DateTime)reader.GetDateTime(4),
                        DataModified = (DateTime)reader.GetDateTime(5),
                        CategoryId = reader.GetInt32(6)
                    });
                }
            }
            return posts;
        }
        public Post getPostById(int postId)
        {
            Category post = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_GetPostCategory";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@PostId";
                parameter1.SqlDbType = SqlDbType.Int;
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = postId;
                command.Parameters.Add(parameter1);

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    category = new Category
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Description = reader.GetString(2)
                    };
                }
            }
            return post;
        }
        //public IList<Post> getPostsByTag(String tagName)
        //{

        //}
        //public IList<PostTag> getPostsTags()
        //{

        //}
        public IList<Category> getAllCategories()
        {
            IList<Category> categories = new List<Category>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_GetAllCategories";
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //var DataModified = reader.IsDBNull(5) ? DateTime.ParseExact("00-00-00 0:00", "dd-MM-yy H:mm", null) : DateTime.ParseExact("00-00-0000 0:00", "dd-MM-yyyy H:mm", null);
                    //bool some = reader.IsDBNull(5);
                    //var DataCreate = (DateTime)reader.GetDateTime(4);
                    categories.Add(new Category
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Description = reader.GetString(2)
                    });
                }
            }
            return categories;
        }
        //public IList<Tag> getAllTags()
        //{

        //}
        //public IList<User> GetAllUsers()
        //{

        //}
        //public IList<User> GetBlackList()
        //{
        //}
        //public User GetUserById(int Id)
        //{

        //}
        //public MetaAboutUser GetMetaAboutUser(int metaId)
        //{

        //}
        //public IList<PostComment> GetAllCommentsOfUser(int userId)
        //{

        //}
        //public IList<PostComment> GetAllCommentsOfPost(int postId)
        //{

        //}
        //public IList<User> GetUsersOfPost(int postId)
        //{

        //}
        public IList<Tag> GetPostTags(int postId)
        {
            IList<Tag> tags = new List<Tag>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_GetPostTags";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@PostId";
                parameter1.SqlDbType = SqlDbType.Int;
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = postId;
                command.Parameters.Add(parameter1);

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    tags.Add(new Tag
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.IsDBNull(2) ? "" : reader.GetString(2)
                    });
                }
            }
            return tags;
        }
        public Category GetPostCategory(int postId)
        {
            Category category = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_GetPostCategory";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@PostId";
                parameter1.SqlDbType = SqlDbType.Int;
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = postId;
                command.Parameters.Add(parameter1);

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    category = new Category
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Description = reader.GetString(2)
                    };
                }
            }
            return category;
        }
        public Post GetChoisenPost(int postId)
        {
            Post post = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_GetPostCategory";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@PostId";
                parameter1.SqlDbType = SqlDbType.Int;
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = postId;
                command.Parameters.Add(parameter1);

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    post = new Post
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        ShortDescription = reader.GetString(2),
                        Description = reader.GetString(3),
                        DataCreate = (DateTime)reader.GetDateTime(4),
                        //DataModified = reader.IsDBNull(5) ? DateTime.ParseExact("01-01-0001", "mm.dd.yyyy", null) : (DateTime)reader.GetDateTime(5),//(DateTime)reader.GetDateTime(5),
                        CategoryId = reader.GetInt32(6)
                    };
                }
            }
            return post;
        }
        //public User GetUserOfComment(int commentId)
        //{

        //}
        //#endregion
        //#region DELETE
        //public void deleteUserFromBlackList(int userId)
        //{

        //}
        //public void DeletePost(int deleteId)
        //{

        //}
        //public void DeleteUser(int userId)
        //{

        //}
        //public void DeleteComment(int commentId)
        //{

        //}
        //public void DeleteCommentFromPost(int commentId, int postId)
        //{

        //}
        //public void DeleteTag(int commentId)
        //{

        //}
        //public void DeleteCategory(int commentId)
        //{

        //}
        //public void DeleteCategoryFromPost(int commentId)
        //{

        //}
        //public void DeleteTagFromPost(int commentId)
        //{

        //}
        //#endregion

        //#region Change
        //public void ChangePost(Post newPost)
        //{

        //}
        //public void ChangeComment(PostComment comment)
        //{

        //}
        //public void ChangeUser(User user)
        //{
        //    //Замена по id атрибутов
        //}
        //public void ChangeTag(Tag tag)
        //{

        //}
        //public void ChangeCategory(Category category)
        //{

        //}
        //public void ChangeMeta(MetaAboutUser meta)
        //{

        //}
        //#endregion

        public void ChangeCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void ChangeComment(PostComment comment)
        {
            throw new NotImplementedException();
        }

        public void ChangeMeta(MetaAboutUser meta)
        {
            throw new NotImplementedException();
        }

        public void ChangePost(Post newPost)
        {
            throw new NotImplementedException();
        }

        public void ChangeTag(Tag tag)
        {
            throw new NotImplementedException();
        }

        public void ChangeUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(int commentId)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategoryFromPost(int commentId)
        {
            throw new NotImplementedException();
        }

        public void DeleteComment(int commentId)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommentFromPost(int commentId, int postId)
        {
            throw new NotImplementedException();
        }

        public void DeletePost(int deleteId)
        {
            throw new NotImplementedException();
        }

        public void DeleteTag(int commentId)
        {
            throw new NotImplementedException();
        }

        public void DeleteTagFromPost(int commentId)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public void deleteUserFromBlackList(int userId)
        {
            throw new NotImplementedException();
        }

        public IList<PostComment> GetAllCommentsOfPost(int postId)
        {
            throw new NotImplementedException();
        }

        public IList<PostComment> GetAllCommentsOfUser(int userId)
        {
            throw new NotImplementedException();
        }

        public IList<Tag> getAllTags()
        {
            throw new NotImplementedException();
        }

        public IList<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public IList<User> GetBlackList()
        {
            throw new NotImplementedException();
        }

        public MetaAboutUser GetMetaAboutUser(int metaId)
        {
            throw new NotImplementedException();
        }

        public IList<Post> getPostsByTag(string tagName)
        {
            throw new NotImplementedException();
        }

        public IList<PostTag> getPostsTags()
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int Id)
        {
            throw new NotImplementedException();
        }

        public User GetUserOfComment(int commentId)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetUsersOfPost(int postId)
        {
            throw new NotImplementedException();
        }
    }
}
