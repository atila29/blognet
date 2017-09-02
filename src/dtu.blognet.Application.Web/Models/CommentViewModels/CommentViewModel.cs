using System;

namespace dtu.blognet.Application.Web.Models.CommentViewModels
{
  public class CommentViewModel
  {
      public string Content { get; set; }
      public DateTime CreationTime { get; set; }
      public string CreaterUserName { get; set; }
  }
}
