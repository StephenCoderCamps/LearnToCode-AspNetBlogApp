using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BlogApp.Models
{
    public class BlogRepository
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        public IList<Post> ListPosts()
        {
            //var posts = new List<Post>();
            //for (var i = 0; i < 10; i++)
            //{
            //    posts.Add(new Post
            //    {
            //        Id=i,
            //        Title="Title for " + i,
            //        Summary = "Summary for " + i,
            //        Content = "Content for " + i,
            //        DateCreated = DateTime.Now
            //    });
            //}
            var posts = (from p in _db.Posts select p).ToList();
            return posts;
        }

        public void CreatePost(Post post)
        {
            post.DateCreated = DateTime.Now;
            _db.Posts.Add(post);
            _db.SaveChanges();
        }

        public Post GetPost(int id)
        {
            var post = (from p in _db.Posts.Include( p => p.Comments) 
                        where p.Id == id select p).FirstOrDefault();
            return post;
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

    }
}