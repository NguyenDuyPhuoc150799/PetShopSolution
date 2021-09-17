using PetShopSolution.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopSolution.Data.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int ViewCount { get; set; }
        public string Tittle { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Content { get; set; }
        public Status Status { set; get; }

        public string ImageURL { get; set; }

        public AppUser AppUser { get; set; }

    }
}
