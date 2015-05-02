using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogApp.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Blog title is required!!!!")]
        [MaxLength(20, ErrorMessage="Blog title is too long!!!")]
        public string Title { get; set; }

        [Required]
        public string Summary { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public string AuthorName { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}