﻿using PetShopSolution.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopSolution.ViewModels.Catalog.Posts
{
    public class PostCreateRequest
    {
        public Guid UserId { get; set; }
       
        public string Tittle { get; set; }
       
        public string Content { get; set; }
        public Status Status { set; get; }

        public string ImageURL { get; set; }
    }
}
