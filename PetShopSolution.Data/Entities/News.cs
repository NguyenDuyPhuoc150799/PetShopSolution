using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopSolution.Data.Entities
{
    public class News
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Tittle { get; set; }
        public string Content { get; set; }
        public string ImageURL { get; set; }
    }
}
