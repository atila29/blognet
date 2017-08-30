using System.Collections;
using System.Collections.Generic;
using dtu.blognet.Application.Web.Models.BlogViewModels;

namespace dtu.blognet.Application.Web.Models.AccountViewModels
{
    public class AccountViewModel
    {
        public ICollection<BlogViewModel> OwnedBlogs { get; set; }
        public string UserName { get; set; }
        
        
    }
}