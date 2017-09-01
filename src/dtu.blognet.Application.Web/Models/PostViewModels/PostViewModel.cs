using System.ComponentModel.DataAnnotations;

namespace dtu.blognet.Application.Web.Models.PostViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        [Display(Name = "Title")]
        public string Title { get; set; }
        public string Content { get; set; }
    }
}