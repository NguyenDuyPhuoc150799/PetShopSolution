using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopSolution.ViewModels.Catalog.Newss
{
     public class NewsViewModel
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Tittle { get; set; }
        public string Content { get; set; }
        public string ImageURL { get; set; }
    }
}
