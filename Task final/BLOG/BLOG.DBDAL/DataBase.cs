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

        #region ADD
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
        #endregion
        #region GET
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
                        Title = reader.IsDBNull(1) ? "" : reader.GetString(1),
                        ShortDescription = reader.IsDBNull(2) ? "" : reader.GetString(2),
                        Description = reader.IsDBNull(3) ? "" : reader.GetString(3),
                        DataCreate = (DateTime)reader.GetDateTime(4),
                        DataModified = reader.IsDBNull(5) ? new DateTime() : (DateTime)reader.GetDateTime(5),
                        CategoryId = reader.GetInt32(6)
                    });
                }
            }
            return posts;
        }
        public Post getPostById(int postId)
        {
            Post post = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_GetChoisenPost";
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
                        Title = reader.IsDBNull(1) ? "" : reader.GetString(1),
                        ShortDescription = reader.IsDBNull(2) ? "" : reader.GetString(2),
                        Description = reader.IsDBNull(3) ? "" : reader.GetString(3),
                        DataCreate = (DateTime)reader.GetDateTime(4),
                        DataModified = reader.IsDBNull(5) ? new DateTime() : (DateTime)reader.GetDateTime(5),
                        CategoryId = reader.GetInt32(6)
                    };
                }
            }
            return post;
        }
        public IList<Post> getPostsByTag(String tagName)
        {
            IList<Post> posts = new List<Post>();
            IList<Tag> tags = getAllTags();
            int tagId = tags.First(t => t.Name == tagName).Id;
                
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_GetPostsByTag";
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
                        Description = reader.IsDBNull(3) ? "" : reader.GetString(3),
                        DataCreate = (DateTime)reader.GetDateTime(4),
                        DataModified = reader.IsDBNull(5) ? new DateTime() : (DateTime)reader.GetDateTime(5),
                        CategoryId = reader.GetInt32(6)
                    });
                }
            }
            return posts;
        }
        public IList<PostTag> getPostsTags()
        {
            IList<PostTag> entityTable = new List<PostTag>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_GetPostsTags";
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    entityTable.Add(new PostTag
                    {
                        PostId = reader.GetInt32(0),
                        TagId = reader.GetInt32(1),
                    });
                }
            }
            return entityTable;
        }
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
                    categories.Add(new Category
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Description = reader.IsDBNull(2) ? "" : reader.GetString(2)
                    });
                }
            }
            return categories;
        }
        public IList<Tag> getAllTags()
        {
            IList<Tag> tags = new List<Tag>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_GetAllTags";
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {

                    //reader.IsDBNull(2) ? "": reader.GetString(2);
                    

                    tags.Add(new Tag
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.IsDBNull(1) ? "" : reader.GetString(1),
                        Description = reader.IsDBNull(2) ? "" : reader.GetString(2)
                    });
                }
            }
            return tags;
        }
        public IList<User> GetAllUsers()
        {
            IList<User> users = new List<User>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_GetAllUsers";
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(new User
                    {
                        Id = reader.GetInt32(0),
                        Login = reader.GetString(1),
                        Password = reader.GetString(2),
                        Email = reader.GetString(3),
                        DataRegistration = reader.GetDateTime(4),
                        MetaId = reader.IsDBNull(5) ? -1 : reader.GetInt32(5)
                    });
                }
            }
            return users;
        }
        public IList<User> GetBlackList()
        {
            IList<User> users = new List<User>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_GetUsersOfBlackList";
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(new User
                    {
                        Id = reader.GetInt32(0),
                        Login = reader.GetString(1),
                        Password = reader.GetString(2),
                        Email = reader.GetString(3),
                        DataRegistration = reader.GetDateTime(4),
                        MetaId = reader.IsDBNull(5) ? -1 : reader.GetInt32(5)
                    });
                }
            }
            return users;
        }

        public User GetUserById(int Id)
        {
            User user = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_GetUserById";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@Id";
                parameter1.SqlDbType = SqlDbType.Int;
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = Id;
                command.Parameters.Add(parameter1);

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    user = new User
                    {
                        Id = reader.GetInt32(0),
                        Login = reader.GetString(1),
                        Password = reader.GetString(2),
                        Email = reader.GetString(3),
                        DataRegistration = (DateTime)reader.GetDateTime(4),
                        MetaId = reader.IsDBNull(6) ? -1 : reader.GetInt32(6)
                    };
                }
            }
            return user;
        }
        public MetaAboutUser GetMetaAboutUser(int metaId)
        {
            MetaAboutUser meta = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_GetMetaByMetaId";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@MetaId";
                parameter1.SqlDbType = SqlDbType.Int;
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = metaId;
                command.Parameters.Add(parameter1);

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    meta = new MetaAboutUser
                    {
                        Id = reader.GetInt32(0),
                        Info = reader.GetString(1),
                        DateBirth = (DateTime)reader.GetDateTime(4),
                        Age = reader.GetInt32(6)
                    };
                }
            }
            return meta;
        }
        public IList<PostComment> GetAllCommentsOfUser(int userId)
        {
            IList<PostComment> comments = new List<PostComment>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_GetAllCommentsOfUserById";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@UserId";
                parameter1.SqlDbType = SqlDbType.Int;
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = userId;
                command.Parameters.Add(parameter1);

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    comments.Add(new PostComment
                    {
                        Id = reader.GetInt32(0),
                        PostId = reader.GetInt32(1),
                        UserID = reader.GetInt32(2),
                        Description = reader.IsDBNull(3) ? "" : reader.GetString(3),
                        DataCreate = (DateTime)reader.GetDateTime(4),
                        DataModified = reader.IsDBNull(5) ? new DateTime() : (DateTime)reader.GetDateTime(5),
                    });
                }
            }
            return comments;
        }
        public IList<PostComment> GetAllCommentsOfPost(int postId)
        {
            IList<PostComment> comments = new List<PostComment>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_GetAllCommentsOfPostById";
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
                    comments.Add(new PostComment
                    {
                        Id = reader.GetInt32(0),
                        PostId = reader.GetInt32(1),
                        UserID = reader.GetInt32(2),
                        Description = reader.IsDBNull(3) ? "" : reader.GetString(3),
                        DataCreate = (DateTime)reader.GetDateTime(4),
                        DataModified = reader.IsDBNull(5) ? new DateTime() : (DateTime)reader.GetDateTime(5),
                    });
                }
            }
            return comments;
        }
        public IList<User> GetUsersOfPost(int postId)
        {
            IList<PostComment> posts = GetAllCommentsOfPost(postId);
            IList<User> users = new List<User>();
            IList<int> usersId = new List<int>();
            foreach (PostComment post in posts)
            {
                if (post.PostId == postId)
                {
                    usersId.Add(post.UserID);
                }
            }
            foreach (int id in usersId)
            {
                users.Add(GetUserById(id));
            }
            return users;
        }
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
                        Description = reader.IsDBNull(2) ? "" : reader.GetString(2)
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
                command.CommandText = "sp_GetPostById";
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
                        DataModified = reader.IsDBNull(5) ? new DateTime() : (DateTime)reader.GetDateTime(5),
                        CategoryId = reader.GetInt32(6)
                    };
                }
            }
            return post;
        }
        public User GetUserOfComment(int commentId)
        {
            User user = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_GetUserOfCommentByCommentId";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@CommentId";
                parameter1.SqlDbType = SqlDbType.Int;
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = commentId;
                command.Parameters.Add(parameter1);

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                  user =  new User
                    {
                        Id = reader.GetInt32(0),
                        Login = reader.GetString(1),
                        Password = reader.GetString(2),
                        Email = reader.GetString(3),
                        DataRegistration = (DateTime)reader.GetDateTime(4),
                        MetaId = reader.IsDBNull(5) ? -1 : reader.GetInt32(5)
                    };
                }
            }
            return user;
        }
        #endregion
        #region DELETE
        public void deleteUserFromBlackList(int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_DeleteUserFromBlackList";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@UserId";
                parameter1.SqlDbType = SqlDbType.Int;
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = userId;
                command.Parameters.Add(parameter1);

                connection.Open();
                var reader = command.ExecuteNonQuery();
            }
        }

        public void DeletePost(int postId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_DeletePostById";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@PostId";
                parameter1.SqlDbType = SqlDbType.Int;
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = postId;
                command.Parameters.Add(parameter1);

                connection.Open();
                var reader = command.ExecuteNonQuery();
            }
        }
        public void DeleteUser(int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_DeleteUserById";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@UserId";
                parameter1.SqlDbType = SqlDbType.Int;
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = userId;
                command.Parameters.Add(parameter1);

                connection.Open();
                var reader = command.ExecuteNonQuery();
            }
        }
        public void DeleteComment(int commentId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_DeleteCommentById";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@CommentId";
                parameter1.SqlDbType = SqlDbType.Int;
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = commentId;
                command.Parameters.Add(parameter1);

                connection.Open();
                var reader = command.ExecuteNonQuery();
            }
        }
        public void DeleteCommentFromPost(int commentId, int postId)
        {
            DeleteComment(commentId);
        }
        public void DeleteTag(int tagId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_DeleteTagById";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@TagId";
                parameter1.SqlDbType = SqlDbType.Int;
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = tagId;
                command.Parameters.Add(parameter1);

                connection.Open();
                var reader = command.ExecuteNonQuery();
            }
        }
        public void DeleteCategory(int categoryId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_DeleteCategory";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@CategoryId";
                parameter1.SqlDbType = SqlDbType.Int;
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = categoryId;
                command.Parameters.Add(parameter1);

                connection.Open();
                var reader = command.ExecuteNonQuery();
            }
        }
        public void DeleteCategoryFromPost(int postId)
        {//удаляем категорию из поста по его же ID
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_DeleteCategoryFromPost";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@PostId";
                parameter1.SqlDbType = SqlDbType.Int;
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = postId;
                command.Parameters.Add(parameter1);

                connection.Open();
                var reader = command.ExecuteNonQuery();
            }
        }
        public void DeleteTagFromPost(int postId, int tagId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_DeleteTagFromPost";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@PostId";
                parameter1.SqlDbType = SqlDbType.Int;
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = postId;
                command.Parameters.Add(parameter1);

                SqlParameter parameter2 = new SqlParameter();
                parameter2.ParameterName = "@TagId";
                parameter2.SqlDbType = SqlDbType.Int;
                parameter2.Direction = ParameterDirection.Input;
                parameter2.Value = tagId;
                command.Parameters.Add(parameter2);

                connection.Open();
                var reader = command.ExecuteNonQuery();
            }
        }

        #endregion
        #region Change
        public void ChangePost(Post newPost)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_UpdatePost";
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

                SqlParameter parameter7 = new SqlParameter();
                parameter7.ParameterName = "@Id";
                parameter7.SqlDbType = SqlDbType.Int;
                parameter7.Direction = ParameterDirection.Input;
                parameter7.Value = newPost.Id;
                command.Parameters.Add(parameter7);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void ChangeComment(PostComment comment)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_UpdateComment";
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

                SqlParameter parameter6 = new SqlParameter();
                parameter6.ParameterName = "@Id";
                parameter6.SqlDbType = SqlDbType.Int;
                parameter6.Direction = ParameterDirection.Input;
                parameter6.Value = comment.Id;
                command.Parameters.Add(parameter6);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void ChangeUser(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_UpdateUser";
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

                SqlParameter parameter6 = new SqlParameter();
                parameter6.ParameterName = "@Id";
                parameter6.SqlDbType = SqlDbType.Int;
                parameter6.Direction = ParameterDirection.Input;
                parameter6.Value = user.Id;
                command.Parameters.Add(parameter6);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void ChangeTag(Tag tag)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_UpdateTag";
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

                SqlParameter parameter3 = new SqlParameter();
                parameter3.ParameterName = "@Id";
                parameter3.SqlDbType = SqlDbType.Int;
                parameter3.Direction = ParameterDirection.Input;
                parameter3.Value = tag.Id;
                command.Parameters.Add(parameter3);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void ChangeCategory(Category category)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_UpdateCategory";
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

                SqlParameter parameter3 = new SqlParameter();
                parameter3.ParameterName = "@Id";
                parameter3.SqlDbType = SqlDbType.Int;
                parameter3.Direction = ParameterDirection.Input;
                parameter3.Value = category.Id;
                command.Parameters.Add(parameter3);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void ChangeMeta(MetaAboutUser meta)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "sp_UpdateMeta";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@Info";
                parameter1.SqlDbType = SqlDbType.NVarChar;
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = meta.Info;
                command.Parameters.Add(parameter1);

                SqlParameter parameter2 = new SqlParameter();
                parameter2.ParameterName = "@DateBirth";
                parameter2.SqlDbType = SqlDbType.DateTime;
                parameter2.Direction = ParameterDirection.Input;
                parameter2.Value = meta.DateBirth;
                command.Parameters.Add(parameter2);

                SqlParameter parameter3 = new SqlParameter();
                parameter3.ParameterName = "@Age";
                parameter3.SqlDbType = SqlDbType.Int;
                parameter3.Direction = ParameterDirection.Input;
                parameter3.Value = meta.Age;
                command.Parameters.Add(parameter3);

                SqlParameter parameter4 = new SqlParameter();
                parameter4.ParameterName = "@Id";
                parameter4.SqlDbType = SqlDbType.Int;
                parameter4.Direction = ParameterDirection.Input;
                parameter4.Value = meta.Info;
                command.Parameters.Add(parameter4);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        #endregion
    }
}
