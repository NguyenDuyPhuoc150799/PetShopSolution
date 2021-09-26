using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopSolution.ViewModels.Catalog.Comments
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTime CreatedTime { get; set; }
        public Guid UserId { get; set; }
        public string Tittle { get; set; }
        public string Content { get; set; }
        public int Star { get; set; }
        public string Reply { get; set; }
    }
}
