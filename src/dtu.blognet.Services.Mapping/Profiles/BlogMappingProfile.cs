using AutoMapper;
using dtu.blognet.Core.Command.InputModels.BlogInputModels;
using dtu.blognet.Core.Entities;

namespace dtu.blognet.Services.Mapping.Profiles
{
    public class BlogMappingProfile : Profile
    {
        public BlogMappingProfile()
        {
            CreateMap<BlogInputModel, Blog>();
        }
    }
}