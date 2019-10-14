using BLOG.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.PL.Interfaces
{
    public interface IUI
    {
       #region ADD
       bool AddPost(String title, String shortDescription, String description, String dateCreate, Category choisenCategory, IList<Tag> choisenTags);

       bool AddBlackList(int userId);
       bool AddNewUser(String login, String password, String email, int meta);
       bool AddNewTag(String name, String description);
       bool AddNewCategory(String title, String description);
       bool AddNewComment(int postId, int userId, String description, String dateCreate);
        int AddMetaAboutUser(string info, string dateBirth, int age);
        #endregion

        #region GET
        IList<Post> getAllPosts();
        Post getPostById(int postId);

        IList<Post> getPostsByTag(String tagName);

         IList<Post> getPostsByText(String text);

         IList<Category> getAllCategories();

         IList<Tag> getAllTags();

         IList<User> GetAllUsers();

         IList<User> GetBlackList();

         User GetUserById(int Id);

         MetaAboutUser GetMetaAboutUser(int metaId);

         IList<PostComment> GetAllCommentsOfUser(int userId);

         IList<PostComment> GetAllCommentsOfPost(int postId);

         IList<User> GetUsersOfPost(int postId);

         IList<Tag> GetPostTags(int postId);

         Category GetPostCategory(int postId);

        Post GetChoisenPost(int postId);

        User GetUserOfComment(int commentId);

        #endregion

        #region REMOVE
         void DeletePost(int deleteId);

         void DeleteUser(int userId);

         void RemoveBlackList(int userId);

         void DeleteComment(int commentId);

         void DeleteCommentFromPost(int commentId, int postId);

         void DeleteTag(int tagId);

         void DeleteCategory(int categoryId);

         void DeleteCategoryFromPost(int postId);

         void DeleteTagFromPost(int postId, int tagId);

        #endregion

        #region CHANGE
         bool ChangePost(int postId, String title, String shortDescription, String description, String dateCreate, String dateModified, Category choisenCategory, IList<Tag> choisenTags);

         void ChangeComment(int commentId, string newDescription);

         bool ChangeUser(int userId, string newLogin, string newPassword, string newEmail, int newMetaId);

         void ChangeTag(int tagId, string newName, string newDescription);

         void ChangeCategory(int categoryId, string newTitle, string newDescription);
         void ChangeMeta(int id, string info, string dateBirth, int age);

        #endregion

        bool CheckBlackList(int userId);
    }
}
