using BLOG.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.DAL.Interfaces
{
    public interface IStorable
    {
        int AddPost(Post newPost);
        void AddTagForPost(PostTag newPostTag);
        void AddBlackList(int userId);
        void AddNewUser(User user);
        int AddMetaAboutUser(MetaAboutUser metaAboutUser);
        void AddNewTag(Tag tag);
        void AddNewCategory(Category category);
        void AddNewComment(PostComment comment);

        IList<Post> getAllPosts();
        Post getPostById(int postId);
        IList<Post> getPostsByTag(String tagName);
        IList<PostTag> getPostsTags();
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

        void deleteUserFromBlackList(int userId);
        void DeletePost(int deleteId);
        void DeleteUser(int userId);
        void DeleteComment(int commentId);
        void DeleteCommentFromPost(int commentId, int postId);
        void DeleteTag(int tagId);
        void DeleteCategory(int categoryId);
        void DeleteCategoryFromPost(int postId);
        void DeleteTagFromPost(int postId, int tagId);

        void ChangePost(Post newPost);
        void ChangeComment(PostComment comment);
        void ChangeUser(User user);
        void ChangeTag(Tag tag);
        void ChangeCategory(Category category);
        void ChangeMeta(MetaAboutUser meta);

    }
}
