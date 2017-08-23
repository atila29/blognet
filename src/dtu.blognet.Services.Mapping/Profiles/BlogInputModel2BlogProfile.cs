using AutoMapper;
using dtu.blognet.Core.Command.InputModels.BlogInputModels;
using dtu.blognet.Core.Entities;

namespace dtu.blognet.Services.Mapping.Profiles
{
    public class BlogInputModel2BlogProfile : Profile
    {
        public BlogInputModel2BlogProfile()
        {
            CreateMap<BlogInputModel, Blog>();
        }
    }
}