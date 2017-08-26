using System;
using System.Collections.Generic;
using System.Text;

namespace dtu.blognet.Core.Command.InputModels.CommentInputModels
{
    class CommentInputModel
    {
        //TODO: Add owner
        public int PostId { get; set; }
        public string Content { get; set; }
    }
}
