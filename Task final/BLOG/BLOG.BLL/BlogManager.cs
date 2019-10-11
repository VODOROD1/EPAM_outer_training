using BLOG.BLL.Interfaces;
using BLOG.DAL.Interfaces;
using BLOG.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.BLL
{
    public class BlogManager : IManager
    {
        private readonly IStorable storage;
        public BlogManager(IStorable storage)
        {
            this.storage = storage;
        }
        #region ADD
        public bool AddPost(String title, String shortDescription, String description, String dateCreate, Category choisenCategory, IList<Tag> choisenTags)
        {
            DateTime date1;
            DateTime date2;
            if (dateCreate == "")
            {
                date1 = DateTime.Now;
            }
            else { date1 = DateTime.ParseExact(dateCreate, "dd.MM.yyyy HH:mm:ss", null); }
            
            date2 = DateTime.Now;
            Post newPost = new Post {Title = title, ShortDescription = shortDescription , Description = description, DataCreate = date1, DataModified = date2, CategoryId = choisenCategory.Id };
            //Далее в DAL НУЖНО ПОЛУЧИТЬ ID
            int postId = storage.AddPost(newPost);
            AddTagsForPost(postId, choisenTags);
            return true;
        }
        ///
        public void AddTagsForPost(int postId, IList<Tag> choisenTags)
        {
            //проверка на присутствие тега в посте
            bool b = true;
            IList<PostTag> postTags = getPostsTags();
            foreach (Tag tag in choisenTags) {
                b = true;
                foreach (PostTag postTag in postTags) {
                    if (postTag.PostId == postId && postTag.TagId == tag.Id)
                    {
                        b = false;
                    }
                }
                if (b)
                {
                    storage.AddTagForPost(new PostTag { PostId = postId, TagId = tag.Id });
                }
                else { }
            }
        }
        public bool AddBlackList(int userId)
        {
            if (CheckBlackList(userId))
            {
                storage.AddBlackList(userId);
                return true;
            }
            else { return false; }
        }
        public bool AddNewUser(String login, String password, String email, int meta)
        {
            if (CheckUser(login, email))
            {
                storage.AddNewUser(new User { Login = login, Password = password, Email = email, DataRegistration = DateTime.Now, MetaId = meta});
                return true;
            }
            else { return false; }
            
        }
        public int AddMetaAboutUser(string info, string dateBirth, int age)
        {
            
            return storage.AddMetaAboutUser(new MetaAboutUser { Info=info, DateBirth = DateTime.ParseExact(dateBirth, "dd.MM.yyyy", null), Age = age});;
        }
        public bool AddNewTag(String name, String description)
        {
            if (CheckNewTag(name))
            {
                storage.AddNewTag(new Tag { Name = name, Description = description });
                return true;
            }
            else { return false; }
        }
        public bool AddNewCategory(String title, String description)
        {
            if (CheckNewCategory(title))
            {
                storage.AddNewCategory(new Category { Title = title, Description = description });
                return true;
            }
            else { return false; }
        }
        public bool AddNewComment(int postId, int userId, String description, String dateCreate)
        {
            storage.AddNewComment(new PostComment { PostId = postId, UserID = userId, Description = description, DataCreate = DateTime.Now });
            return true;
        }
        #endregion

        #region GET
        public IList<Post> getAllPosts()
        {

            return storage.getAllPosts();
        }
        public Post getPostById(int postId)
        {

            return storage.getPostById(postId);
        }
        public IList<Post> getPostsByTag(String tagName)
        {
            return storage.getPostsByTag(tagName);
        }
        public IList<PostTag> getPostsTags()
        {
            return storage.getPostsTags();
        }
        public IList<Post> getPostsByText(String text)
        {
            IList<Post> match = new List<Post>();
            foreach (Post post in getAllPosts())
            {
                if (post.Description.Contains(text))
                {
                    match.Add(post);
                }
            }
            return match;
        }
        public IList<Category> getAllCategories()
        {
            return storage.getAllCategories();
        }
        public IList<Tag> getAllTags()
        {
            return storage.getAllTags();
        }
        public IList<User> GetAllUsers()
        {
            return storage.GetAllUsers();
        }
        public IList<User> GetBlackList()
        {
            return storage.GetBlackList();
        }
        public User GetUserById(int Id)
        {
            return storage.GetUserById(Id);
        }
        public MetaAboutUser GetMetaAboutUser(int metaId)
        {
            return storage.GetMetaAboutUser(metaId);
        }
        public IList<PostComment> GetAllCommentsOfUser(int userId)
        {
            return storage.GetAllCommentsOfUser(userId);
        }
        public IList<PostComment> GetAllCommentsOfPost(int postId)
        {
            return storage.GetAllCommentsOfPost(postId);
        }
        public IList<User> GetUsersOfPost(int postId)
        {
            return storage.GetUsersOfPost(postId);
        }
        public IList<Tag> GetPostTags(int postId)
        {
            return storage.GetPostTags(postId);
        }
        public Category GetPostCategory(int postId)
        {
            return storage.GetPostCategory(postId);
        }
        public Post GetChoisenPost(int postId)
        {
            return storage.GetChoisenPost(postId);
        }
        public User GetUserOfComment(int commentId)
        {
            return storage.GetUserOfComment(commentId);
        }
        #endregion

        #region REMOVE
        public void DeletePost(int deleteId)
        {
            storage.DeletePost(deleteId);
        }
        public void DeleteUser(int userId)
        {
            storage.DeleteUser(userId);
        }
        public void RemoveBlackList(int userId)
        {
            if(!CheckBlackList(userId))
            {
                storage.deleteUserFromBlackList(userId);
            }
        }
        public void DeleteComment(int commentId)
        {
            storage.DeleteComment(commentId);
        }
        public void DeleteCommentFromPost(int commentId, int postId)
        {
            storage.DeleteCommentFromPost(commentId, postId);
        }
        public void DeleteTag(int tagId)
        {
            storage.DeleteTag(tagId);
        }
        public void DeleteCategory(int categoryId)
        {
            storage.DeleteCategory(categoryId);
        }
        public void DeleteCategoryFromPost(int postId)
        {
            storage.DeleteCategoryFromPost(postId);
        }
        public void DeleteTagFromPost(int postId, int tagId)
        {
            storage.DeleteTagFromPost(postId, tagId);
        }
        #endregion

        #region CHANGE
        public bool ChangePost(int postId, String title, String shortDescription, String description, String dateCreate, String dateModified, Category choisenCategory, IList<Tag> choisenTags)
        {
            AddTagsForPost(postId, choisenTags);
            DateTime date1 = DateTime.ParseExact(dateCreate, "dd.MM.yyyy HH:mm:ss", null);
            DateTime date2 = DateTime.Now;
            Post newPost = new Post { Title = title, ShortDescription = shortDescription, Description = description, DataCreate = date1, DataModified = date2, CategoryId = choisenCategory.Id };
            storage.ChangePost(newPost);

            return true;
        }
        public void ChangeComment(int commentId, string newDescription)
        {
            storage.ChangeComment(new PostComment { Id = commentId, Description = newDescription, DataModified = DateTime.Now });
        }
        public bool ChangeUser(int userId, string newLogin, string newPassword, string newEmail, int newMetaId)
        {
            if (CheckUser(newLogin, newEmail))
            {
                int metaId = GetUserById(userId).MetaId;
                storage.ChangeUser(new User {Id = userId, Login = newLogin, Password = newPassword, Email = newEmail, DataRegistration = DateTime.Now, MetaId = newMetaId });
                return true;
            }
            else { return false; }
        }
        public void ChangeTag(int tagId, string newName, string newDescription)
        {
            IList<Tag> tags = getAllTags();
            bool b = true;
            foreach (Tag tag in tags)
            {
                if (tag.Id != tagId && tag.Name == newName)
                {
                    b = false;
                }
            }
            if (b)
            {
                storage.ChangeTag(new Tag {Id = tagId, Name = newName, Description = newDescription });
            }
        }
        public void ChangeCategory(int categoryId, string newTitle, string newDescription)
        {
            IList<Category> categories = getAllCategories();
            bool b = true;
            foreach (Category category in categories)
            {
                if (category.Id != categoryId && category.Title == newTitle)
                {
                    b = false;
                }
            }
            if (b)
            {
                storage.ChangeCategory(new Category { Id = categoryId, Title = newTitle, Description = newDescription });
            }
        }
        public void ChangeMeta(int id, string info, string dateBirth, int age)
        {
            storage.ChangeMeta(new MetaAboutUser { Id = id, Info = info, DateBirth = DateTime.ParseExact(dateBirth, "dd.MM.yyyy", null), Age = age });
        }
        #endregion

        #region CHECK
        public bool CheckUser(String login, String email)
        {
            bool b = true;
            foreach (User user in GetAllUsers())
            {
                if (user.Login == login && user.Email == email)
                {
                    b = false;
                }
            }
            if (b)
            {
                return true;
            }
            else { return false; }
        }
        public bool CheckNewTag(String name)
        {
            bool b = true;
            foreach (Tag tag in getAllTags())
            {
                if (tag.Name == name)
                {
                    b = false;
                }
            }
            if (b)
            {
                return true;
            }
            else { return false; }
        }
        public bool CheckNewCategory(String title)
        {
            bool b = true;
            foreach (Category cat in getAllCategories())
            {
                if (cat.Title == title)
                {
                    b = false;
                }
            }
            if (b)
            {
                return true;
            }
            else { return false; }
        }
        public bool CheckBlackList(int userId)
        {
            bool b = true;
            foreach (User user in GetBlackList()) {
                if (user.Id == userId)
                {
                    b = false;
                }
            }
            if (b)
            {
                return true;
            }
            else { return false; }
        }
        #endregion
    }
}
