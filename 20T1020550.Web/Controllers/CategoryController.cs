using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _20T1020550.DomainModels;
using _20T1020550.BusinessLayers;
using _20T1020550.Web.Models;

namespace _20T1020550.Web.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private const int PAGE_SIZE = 5;
        private const string CATEGORY_SEARCH = "SearchCategoryCondition";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: Category
        //public ActionResult Index(int page = 1, int pageSize = 5, string searchValue = "")
        //{
        //    int rowCount = 0;
        //    var data = CommonDataService.ListOfCategories(page, pageSize, searchValue, out rowCount);

        //    int pageCount = rowCount / pageSize;
        //    if (rowCount % pageSize > 0)
        //        pageCount += 1;


        //    ViewBag.Page = page;
        //    ViewBag.PageCount = pageCount;
        //    ViewBag.RowCount = rowCount;
        //    ViewBag.PageSize = pageSize;
        //    ViewBag.SearchValue = searchValue;

        //    return View(data);
        //}
        public ActionResult Index()
        {
            PaginationSearchInput condition = Session[CATEGORY_SEARCH] as PaginationSearchInput;
            if (condition == null)
            {
                condition = new PaginationSearchInput()
                {
                    Page = 1,
                    PageSize = PAGE_SIZE,
                    SearchValue = ""
                };
            }

            return View(condition);
        }

        public ActionResult Search(PaginationSearchInput condition)
        {
            int rowCount = 0;
            var data = CommonDataService.ListOfCategories(condition.Page,
                                                         condition.PageSize,
                                                         condition.SearchValue,
                                                         out rowCount);
            var result = new CategorySearchOutput()
            {
                Page = condition.Page,
                PageSize = condition.PageSize,
                SearchValue = condition.SearchValue,
                RowCount = rowCount,
                Data = data
            };

            Session[CATEGORY_SEARCH] = condition;
            return View(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            var data = new Category()
            {
                CategoryID = 0
            };

            ViewBag.Title = "Bổ sung loại hàng";
            return View("Edit", data);
        }

        [HttpPost]

        [ValidateAntiForgeryToken]
        public ActionResult Save(Category data)
        {
            try
            {
                //Kiểm soát đầu vâof
              
                if (string.IsNullOrWhiteSpace(data.CategoryName))
                    ModelState.AddModelError("CategoryName", "Tên loại hàng không được để trống");
                if (string.IsNullOrWhiteSpace(data.Description))
                    ModelState.AddModelError("Description", "Mô tả không được để trống");

                if (!ModelState.IsValid)
                {
                    ViewBag.Title = data.CategoryID == 0 ? "Bổ sung loại hàng" : "Cập nhật loại hàng";
                    return View("Edit", data);
                }

                if (data.CategoryID == 0)
                {
                    CommonDataService.AddCategory(data);
                }
                else
                {
                    CommonDataService.UpdateCategory(data);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //Ghi lại log lỗi
                return Content("Có lỗi xảy ra. Vui lòng thử lại sau!");
            }


        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int id =0)
        {
            if (id == 0)
                return RedirectToAction("Index");

            var data = CommonDataService.GetCategory(id);
            if (data == null)
                return RedirectToAction("Index");

            ViewBag.Title = "Cập nhật loại hàng";
            return View(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete(int id = 0)
        {
            if (id == 0)
                return RedirectToAction("Index");




            if (Request.HttpMethod == "POST")
            {
                CommonDataService.DeleteCategory(id);
                return RedirectToAction("Index");

            }
            var data = CommonDataService.GetCategory(id);

            if (data == null)
                return RedirectToAction("Index");

            return View(data);
        }
    }
}