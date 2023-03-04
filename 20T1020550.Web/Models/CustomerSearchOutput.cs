using _20T1020550.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _20T1020550.Web.Models
{
    /// <summary>
    /// Kết quả tìm kiếm kh dưới dạng phâ trang
    /// </summary>
    public class CustomerSearchOutput : PaginationSearchOutput
    {
        public List<Customer> Data { get; set; }
    }
}