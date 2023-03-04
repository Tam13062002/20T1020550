using _20T1020550.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _20T1020550.Web.Models
{
    /// <summary>
    /// Kết quả tìm kiếm nhà cc dưới dạng phâ trang
    /// </summary>
    public class SupplierSearchOutput : PaginationSearchOutput
    {
        /// <summary>
        /// Danh sacsh nha cc
        /// </summary>
        public List<Supplier> Data { get; set; }

       
    }
}