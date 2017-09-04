using System.Collections.Generic;
using AutoMapper;
using dtu.blognet.Application.Web.Models.AccountViewModels;
using dtu.blognet.Application.Web.Models.BlogViewModels;
using dtu.blognet.Application.Web.Models.PostViewModels;
using dtu.blognet.Core.Entities;

namespace dtu.blognet.Application.Web.Services.AutomapperProfiles
{
    public class ViewModelProfile : Profile
    {

        public ViewModelProfile()
        {
            CreateMap<Blog, BlogCreateViewModel>();
            CreateMap<Blog, BlogViewModel>()
                .ForMember(model => model.Description, opt => opt.MapFrom(blog => blog.Description.Replace("\r\n", "\\n")))
                .ForMember(model => model.Tags, opt => opt.MapFrom(blog => blog.Tags));

            CreateMap<IEnumerable<Blog>, BlogIndexViewModel>()
                .ForMember(model => model.Blogs, opt => opt.MapFrom(blogs => blogs));
            CreateMap<Post, PostViewModel>()
                .ForMember(model => model.Content, opt => opt.MapFrom(post => post.Content.Replace("\r\n", "\\n")));
            CreateMap<Account, AccountViewModel>();
        }
        
    }
}