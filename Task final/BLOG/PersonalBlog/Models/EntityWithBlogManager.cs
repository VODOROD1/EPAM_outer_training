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
            return BlogManager.AddPost(title, shortDescription, description, dateCreate, choisenCategory, choisenTags);
        }
        public bool AddBlackList(int userId)
        {
            //Далее в BLL
            return BlogManager.AddBlackList(userId);
        }
        public int AddMetaAboutUser(string info, string dateBirth, int age)
        {

            return BlogManager.AddMetaAboutUser( info,  dateBirth, age);
        }
        public bool AddNewUser(String login, String password, String email, int meta)
        {
            //Далее в BLL
            return BlogManager.AddNewUser(login, password, email, meta);
        }
        public bool AddNewTag(String name, String description)
        {
            //Далее в BLL
            return BlogManager.AddNewTag(name, description);
        }
        public bool AddNewCategory(String title, String description)
        {
            //Далее в BLL
            return BlogManager.AddNewCategory(title, description);
        }
        public bool AddNewComment(int postId, int userId, String description, String dateCreate)
        {
            //Далее в BLL
            return BlogManager.AddNewComment(postId, userId, description, dateCreate);
        }
        #endregion

        #region GET
        public IList<Post> getAllPosts()
        {
            return BlogManager.getAllPosts();
        }
        public Post getPostById(int postId)
        {
            return BlogManager.getPostById(postId);
        }
        public IList<Post> getPostsByTag(String tagName)
        {
            return BlogManager.getPostsByTag(tagName);
        }
        public IList<Post> getPostsByText(String text)
        {
            return BlogManager.getPostsByText(text);
        }
        public IList<Category> getAllCategories()
        {
            return BlogManager.getAllCategories();
        }
        public IList<Tag> getAllTags()
        {
            return BlogManager.getAllTags();
        }
        public IList<User> GetAllUsers()
        {
            return BlogManager.GetAllUsers();
        }
        public IList<User> GetBlackList()
        {
            return BlogManager.GetBlackList();
        }
        public User GetUserById(int Id)
        {
            return BlogManager.GetUserById(Id);
        }
        public MetaAboutUser GetMetaAboutUser(int metaId)
        {
            return BlogManager.GetMetaAboutUser(metaId);
        }
        public IList<PostComment> GetAllCommentsOfUser(int userId)
        {
            return BlogManager.GetAllCommentsOfUser(userId);
        }
        public IList<PostComment> GetAllCommentsOfPost(int postId)
        {
            return BlogManager.GetAllCommentsOfPost(postId);
        }
        public IList<User> GetUsersOfPost(int postId)
        {
            return BlogManager.GetUsersOfPost(postId);
        }
        public IList<Tag> GetPostTags(int postId)
        {
            return BlogManager.GetPostTags(postId);
        }
        public Category GetPostCategory(int postId)
        {
            return BlogManager.GetPostCategory(postId);
        }
        public Post GetChoisenPost(int postId)
        {
            return BlogManager.GetChoisenPost(postId);
        }
        public User GetUserOfComment(int commentId)
        {
            return BlogManager.GetUserOfComment(commentId);
        }
        #endregion

        #region REMOVE
        public void DeletePost(int deleteId)
        {
            BlogManager.DeletePost(deleteId);
        }
        public void DeleteUser(int userId)
        {
            BlogManager.DeleteUser(userId);
        }
        public void RemoveBlackList(int userId)
        {
            BlogManager.RemoveBlackList(userId);
        }
        public void DeleteComment(int commentId)
        {
            BlogManager.DeleteComment(commentId);
        }
        public void DeleteCommentFromPost(int commentId, int postId)
        {
            BlogManager.DeleteCommentFromPost(commentId, postId);
        }
        public void DeleteTag(int tagId)
        {
            BlogManager.DeleteTag(tagId);
        }
        public void DeleteCategory(int categoryId)
        {
            BlogManager.DeleteCategory(categoryId);
        }
        public void DeleteCategoryFromPost(int postId)
        {
            BlogManager.DeleteCategoryFromPost(postId);
        }
        public void DeleteTagFromPost(int postId, int tagId)
        {
            BlogManager.DeleteTagFromPost(postId, tagId);
        }
        #endregion

        #region CHANGE
        public bool ChangePost(int postId, String title, String shortDescription, String description, String dateCreate, String dateModified, Category choisenCategory, IList<Tag> choisenTags)
        {
            
            return BlogManager.ChangePost( postId,  title,  shortDescription,  description,  dateCreate,  dateModified,  choisenCategory,  choisenTags);
        }
        public void ChangeComment(int commentId, string newDescription)
        {
            BlogManager.ChangeComment(commentId, newDescription);
        }
        public bool ChangeUser(int userId, string newLogin ,string newPassword, string newEmail, int newMetaId)
        {
            
            return BlogManager.ChangeUser( userId, newLogin, newPassword, newEmail, newMetaId);
        }
        public void ChangeTag(int tagId, string newName, string newDescription)
        {
            BlogManager.ChangeTag(tagId, newName, newDescription);
        }
        public void ChangeCategory(int categoryId, string newTitle, string newDescription)
        {
            BlogManager.ChangeCategory(categoryId, newTitle, newDescription);
        }
        public void ChangeMeta(int id, string info, string dateBirth, int age)
        {
            BlogManager.ChangeMeta(id, info, dateBirth, age);
        }
        #endregion
    }
}