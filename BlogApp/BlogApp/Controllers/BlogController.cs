using BlogApp.Models;
using BlogApp.Views.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogApp.Controllers
{
    public class BlogController : Controller
    {
        private BlogRepository _repo = new BlogRepository();


        // GET: Blog
        public ActionResult Index()
        {
            var posts = _repo.ListPosts();
            return View(posts);
        }

        // GET: Blog/Details/5
        public ActionResult Details(int id)
        {
            var post = _repo.GetPost(id);
            var vm = new DetailsViewModel
            {
                Post = post
            };
            return View(vm);
        }

        [HttpPost]
        public ActionResult Details(int id, DetailsViewModel vm)
        {
            var post = _repo.GetPost(id);
            if (ModelState.IsValid) {
                post.Comments.Add(vm.Comment);
                _repo.SaveChanges();
                return RedirectToAction("Details");
            }
            vm.Post = post;
            return View(vm);
        }


        // GET: Blog/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blog/Create
        [HttpPost]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                post.AuthorName = this.User.Identity.Name;
                _repo.CreatePost(post);
                return RedirectToAction("Index");
            }
            return View();
        }





        // GET: Blog/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Blog/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Blog/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
