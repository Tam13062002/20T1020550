using _20T1020550.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _20T1020550.Web.Models
{
    public class CategorySearchOutput : PaginationSearchOutput
    {
        /// <summary>
        /// Danh sacsh nha cc
        /// </summary>
        public List<Category> Data { get; set; }


    }
}