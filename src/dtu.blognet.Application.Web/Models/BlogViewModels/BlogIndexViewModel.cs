using System.Collections.Generic;

namespace dtu.blognet.Application.Web.Models.BlogViewModels
{
    public class BlogIndexViewModel
    {
        public ICollection<BlogViewModel> Blogs { get; set; }
        
    }
}