using System;
using System.Collections.Generic;
using System.Text;

namespace dtu.blognet.Core.Command.InputModels.CommentInputModels
{
    public class CommentInputModel
    {
        public int CreaterId { get; set; }
        public int PostId { get; set; }
        public string Content { get; set; }
    }
}
