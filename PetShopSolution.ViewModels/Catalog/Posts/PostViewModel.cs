using PetShopSolution.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopSolution.ViewModels.Catalog.Posts
{
   public class PostViewModel
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Tittle { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; }
        public DateTime CreatedTime { get; set; }
       
        public string ImageURL { get; set; }
        public string UserName { get; set; }
    }
}
