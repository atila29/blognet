using System.Collections;
using System.Collections.Generic;
using dtu.blognet.Application.Web.Models.PostViewModels;

namespace dtu.blognet.Application.Web.Models.BlogViewModels
{
    public class BlogCreateViewModel
    {
        public string Title { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsOwner { get; set; }
        public ICollection<PostViewModel> Posts { get; set; }
        public string Tags { get; set; }
    }
}