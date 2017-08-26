using AutoMapper;
using dtu.blognet.Core.Command.InputModels.CommentInputModels;
using dtu.blognet.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace dtu.blognet.Services.Mapping.Profiles
{
    public class CommentMappingProfile : Profile
    {
        public CommentMappingProfile()
        {
            CreateMap<CommentInputModel, Comment>();
        }
        
    }
}
