using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _20T1020550.Web.Models
{
    /// <summary>
    /// Lớp cơ sở cho các lớp dùng để lưu trữ 
    /// </summary>
    public abstract class PaginationSearchOutput
    {
        /// <summary>
        /// Trang được hiển thị
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// Số dòng cần hiển thị trên mỗi trang
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// Gía trị cần tìm
        /// </summary>
        public string SearchValue { get; set; }
        /// <summary>
        /// số dòng tìm đc
        /// </summary>
        public int RowCount { get; set; }
        /// <summary>
        /// tổng số trang
        /// </summary>
        public int PageCount
        {
            get
            {
                if (PageSize == 0)
                    return 1;
                int p = RowCount / PageSize;
                if (RowCount % PageSize > 0)
                    p += 1;
                return p;
            }
        }

    }
}