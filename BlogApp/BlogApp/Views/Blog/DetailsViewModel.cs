using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApp.Views.Blog
{
    public class DetailsViewModel
    {
        public Post Post { get; set; }
        public Comment Comment { get; set; }
    }
}