using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dtu.blognet.Application.Web.Controllers
{
    public class PostController : Controller
    {
        public PostController()
        {
            
        }

        public async Task<IActionResult> CreateBlog()
        {
            return Ok();
        }
    }
}