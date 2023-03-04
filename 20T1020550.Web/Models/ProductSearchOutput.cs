using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _20T1020550.DomainModels;

namespace _20T1020550.Web.Models
{
    public class ProductSearchOutput : PaginationSearchOutput
    {
        public List<Product> Data { get; set; }
        
        public int CategoryID { get; set; } = 0;
        public int SupplierID { get; set; } = 0;

    }
}