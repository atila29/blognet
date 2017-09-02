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
            CreateMap<Blog, BlogViewModel>();
            CreateMap<IEnumerable<Blog>, BlogIndexViewModel>()
                .ForMember(model => model.Blogs, opt => opt.MapFrom(blogs => blogs));
            CreateMap<Post, PostViewModel>();
            CreateMap<Account, AccountViewModel>();
        }
        
    }
}