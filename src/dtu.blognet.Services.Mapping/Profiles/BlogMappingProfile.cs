using AutoMapper;
using dtu.blognet.Core.Command.Commands.BlogCommands;
using dtu.blognet.Core.Entities;

namespace dtu.blognet.Services.Mapping.Profiles
{
    public class BlogMappingProfile : Profile
    {
        public BlogMappingProfile()
        {
            CreateMap<AddBlogAsyncCommand, Blog>()
                .ForMember(blog => blog.Tags, opt => opt.Ignore());
        }
    }
}