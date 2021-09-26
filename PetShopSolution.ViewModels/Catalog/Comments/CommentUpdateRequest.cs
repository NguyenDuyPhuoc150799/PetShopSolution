using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopSolution.ViewModels.Catalog.Comments
{
    public class CommentUpdateRequest
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Tittle { get; set; }
        public string Content { get; set; }
    }
}
