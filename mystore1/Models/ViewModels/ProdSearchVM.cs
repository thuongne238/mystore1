﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mystore1.Models;
using mystore1.Models.ViewModels;

namespace mystore1.Models.ViewModels
{
    public class ProdSearchVM
    {
        public string SearchTerm { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string SortOrder { get; set; }
        //public int PageNumber { get; set; }
        //public int PageSize { get; set; } = 10;



        public List<Product> Products { get; set; }
    }
}