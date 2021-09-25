using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopSolution.ViewModels.Catalog.Comments
{
    public class CommentCreateRequest
    {
        public int ProductId { get; set; }
       // public string CreatedTime { get; set; }
        public Guid UserId { get; set; }
        public string Tittle { get; set; }
        public string Content { get; set; }
        public string Reply { get; set; } = "";
        public int Star { get; set; } = 0;
    }
}
