using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _20T1020550.DomainModels;
using _20T1020550.BusinessLayers;
using System.Web.Mvc;

namespace _20T1020550.Web
{
    /// <summary>
    /// Cung cấp tiện ích lq đến SelectList
    /// </summary>
    public static class SelectListHelper
    {
        public static List<SelectListItem> Countries()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() 
            { 
               Value="",
               Text="-- Chọn quốc gia --"
            
            });
            foreach (var item in CommonDataService.ListOfCountries())
            {
                list.Add(new SelectListItem()
                {
                    Value = item.CountryName,
                    Text = item.CountryName
                });
            }   
            return list;
        }

        public static List<SelectListItem> Categories()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem()
            {
                Value = "",
                Text = "-- Loại hàng --"

            });
            foreach (var item in CommonDataService.ListOfCategories(""))
            {
                list.Add(new SelectListItem()
                {
                    Value = Convert.ToString(item.CategoryID),
                    Text = item.CategoryName
                });
            }
            return list;
        }

        public static List<SelectListItem> Suppliers()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem()
            {
                Value = "",
                Text = "-- Nhà cung cấp --"

            });
            foreach (var item in CommonDataService.ListOfSuppliers(""))
            {
                list.Add(new SelectListItem()
                {
                    Value = Convert.ToString(item.SupplierID),
                    Text = item.SupplierName
                });
            }
            return list;
        }
    }
}