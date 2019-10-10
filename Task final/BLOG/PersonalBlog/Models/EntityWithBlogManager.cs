using BLOG.BLL.Interfaces;
using BLOG.Common;
using BLOG.Entities;
using BLOG.PL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalBlog.Models
{
    public class EntityWithBlogManager : IUI
    {
        IManager BlogManager;
        public EntityWithBlogManager()
        {
            BlogManager = DependencyResolver.BlogManager;
        }

        #region ADD
        public bool AddPost(String title, String shortDescription, String description, String dateCreate, Category choisenCategory, IList<Tag> choisenTags)
        {
            //BlogManager.AddPost(name, date, strAge);
            return true;
        }
        public void AddBlackList(int userId)
        {
            //Далее в BLL
        }
        public bool AddNewUser(String login, String password, String email)
        {
            //Далее в BLL
            return true;
        }
        public bool AddNewTag(String name, String description)
        {
            //Далее в BLL
            return true;
        }
        public bool AddNewCategory(String title, String description)
        {
            //Далее в BLL
            return true;
        }
        public bool AddNewComment(int postId, int userId, String description, String dateCreate)
        {
            //Далее в BLL
            return true;
        }
        #endregion

        #region GET
        public IList<Post> getAllPosts()
        {
            //Далее в BLL
            return new List<Post>();
        }
        public IList<Category> getAllCategories()
        {
            //Далее в BLL
            return new List<Category>();
        }
        public IList<Tag> getAllTags()
        {
            //Далее в BLL
            return new List<Tag>();
        }
        public IList<User> GetAllUsers()
        {
            //Далее в BLL
            return new List<User>();
        }
        public IList<MetaAboutUser> GetMetaAboutUser(int metaId)
        {
            return new List<MetaAboutUser>();
        }
        public IList<PostComment> GetAllCommentsOfUser(int userId)
        {
            return new List<PostComment>();
        }
        public IList<PostComment> GetAllCommentsOfPost(int postId)
        {
            return new List<PostComment>();
        }
        public IList<User> GetUsersOfPost(int postId)
        {
            return new List<User>();
        }
        public IList<Tag> GetPostTags(int postId)
        {
            //Далее в BLL
            return new List<Tag>();
        }
        public Category GetPostCategory(int postId)
        {
            //Далее в BLL
            return new Category();
        }
        public Post GetChoisenPost(int postId)
        {
            //Далее в BLL
            return new Post();
        }
        public User GetUserOfComment(int commentId)
        {
            //Далее в BLL
            return new User();
        }
        #endregion

        #region REMOVE
        public void DeletePost(int deleteId)
        {
            //Далее в BLL
        }
        public void DeleteUser(int userId)
        {
            //Далее в BLL
        }

        public void RemoveBlackList(int userId)
        {
            //Далее в BLL
        }
        public void DeleteComment(int commentId)
        {
            //Далее в BLL
        }
        #endregion

        #region CHANGE
        public bool ChangePost(String title, String shortDescription, String description, String dateCreate, String dateModified, Category choisenCategory, IList<Tag> choisenTags)
        {
            //BlogManager.AddPost(name, date, strAge);
            return true;
        }
        public void ChangeComment(int commentId, string newDescription)
        {
            //Далее в BLL
        }
        #endregion

        #region CHECK
        public bool CheckNewUser(String login, String Password)
        {
            //Далее в BLL
            return true;
        }
        public bool CheckNewTag(String name)
        {
            //Далее в BLL
            return true;
        }
        public bool CheckNewCategory(String title)
        {
            //Далее в BLL
            return true;
        }
        
        #endregion
    }
}