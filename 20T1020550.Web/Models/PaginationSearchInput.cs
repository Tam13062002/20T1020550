using _20T1020550.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _20T1020550.Web.Models
{
    /// <summary>
    /// Biểu diễn dữ liệu đầu vào tìm kiếm, phân trang chung
    /// </summary>
    public class PaginationSearchInput
    {
        /// <summary>
        /// Trang cần hiển thị
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// Số dòng cần hiển thị trên mỗi trang
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CategoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int SupplierID { get; set; }
        /// <summary>
        /// Gía trị cần tìm
        /// </summary>
        public string SearchValue { get; set; }

        public class ProductSearchInput : PaginationSearchInput
        {
            public List<Product> Data { get; set; }
            
            public int CategoryID { get; set; } = 0;
            public int SupplierID { get; set; } = 0;

        }
    }
}