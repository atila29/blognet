using System;
using AutoMapper;
using dtu.blognet.Core.Command.InputModels.BlogInputModels;
using dtu.blognet.Core.Command.MappingInterfaces;
using dtu.blognet.Core.Entities;
using dtu.blognet.Services.Mapping.Profiles;

namespace dtu.blognet.Services.Mapping.Mappings
{
    public class BlogInputModel2Blog : IMappingInterface<BlogInputModel, Blog>
    {
        private readonly IMapper _mapper;

        public BlogInputModel2Blog(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Blog Convert(BlogInputModel sourceObject) => _mapper.Map<BlogInputModel, Blog>(sourceObject);
    }
}