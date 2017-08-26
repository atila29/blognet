using AutoMapper;
using dtu.blognet.Core.Command.InputModels.PostInputModels;
using dtu.blognet.Core.Entities;

namespace dtu.blognet.Services.Mapping.Profiles
{
    public class PostMappingProfile : Profile
    {
        public PostMappingProfile()
        {
            CreateMap<PostInputModel, Post>();
        }
    }
}