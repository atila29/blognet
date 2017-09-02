using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using dtu.blognet.Application.Web.Models.CommentViewModels;

namespace dtu.blognet.Application.Web.Models.PostViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        [Display(Name = "Title")]
        public string Title { get; set; }
        public string Content { get; set; }
        public ICollection<CommentViewModel> Comments { get; set; }
    }
}