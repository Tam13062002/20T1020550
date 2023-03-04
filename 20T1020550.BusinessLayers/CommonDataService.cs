using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _20T1020550.DataLayers;
using _20T1020550.DomainModels;

namespace _20T1020550.BusinessLayers
{
    /// <summary>
    /// 
    /// </summary>
    public class CommonDataService
    {
        private static ICountryDAL countryBD;
        private static ICommonDAL<Supplier> supplierDB;
        private static ICommonDAL<Shipper> shipperDB;
        private static ICommonDAL<Customer> customerDB;
        private static ICommonDAL<Employee> employeeDB;
        private static ICommonDAL<Category> categoryDB;
        static CommonDataService()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

            countryBD = new DataLayers.SQLServer.CountryDAL(connectionString);
            supplierDB = new DataLayers.SQLServer.SupplierDAL(connectionString);
            shipperDB = new DataLayers.SQLServer.ShipperDAL(connectionString);
            customerDB = new DataLayers.SQLServer.CustomerDAL(connectionString);
            employeeDB = new DataLayers.SQLServer.EmployeeDAL(connectionString);
            categoryDB = new DataLayers.SQLServer.CategoryDAL(connectionString);
        }
        #region các nghiệp vụ lq đến qốc gia
        /// <summary>
        /// Lấy danh sách cacs quốc gia
        /// </summary>
        /// <returns></returns>
        public static List<Country> ListOfCountries()
        {
            return countryBD.List().ToList();
        }
        #endregion

        #region các nghiệp vụ lq đến nhà cung cấp
        /// <summary>
        /// Tìm kiếm, lấy danh sách các nhà cung cấp dưới dạng phân trangg
        /// </summary>
        /// <param name="page">Trang cần xem</param>
        /// <param name="pagesize">Số dòng trên mỗi trang</param>
        /// <param name="searchValue">Gía trị tìm kiếm</param>
        /// <param name="rowCount"> Output: Tổng số dòng tìm được</param>
        /// <returns></returns>
        public static List<Supplier> ListOfSuppliers(int page, int pagesize, string searchValue, out int rowCount)
        {
            rowCount = supplierDB.Count(searchValue);
            return supplierDB.List(page, pagesize, searchValue).ToList();
        }

        /// <summary>
        /// Tìm kiếm, lấy danh sách các nhà cung cấp dưới dạng không phân trangg
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Supplier> ListOfSuppliers(string searchValue)
        {
            return supplierDB.List(1, 0, searchValue).ToList();

        }
        /// <summary>
        /// Bổ sung nhà cung cấp
        /// </summary>
        /// <param name="data"></param>
        /// <returns>mã của nhà cung cấp</returns>
        public static int AddSupplier(Supplier data)
        {
            return supplierDB.Add(data);

        }
        /// <summary>
        /// Cập nhật nhà cung cấp
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateSupplier(Supplier data)
        {
            return supplierDB.Update(data);

        }
        /// <summary>
        /// Xóa nhà cung cấp
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public static bool DeleteSupplier(int supplierID)
        {
            return supplierDB.Delete(supplierID);

        }
        /// <summary>
        /// Lấy thông tin của 1 nhà cc
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public static Supplier GetSupplier(int supplierID)
        {
            return supplierDB.Get(supplierID);

        }
        /// <summary>
        /// Kiểm tra xem 1 ncc hiện có dữ liệu lq không?
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public static bool InUsedSupplier(int supplierID)
        {
            return supplierDB.InUsed(supplierID);

        }
        #endregion

        #region các nghiệp vụ lq đến khách hàng
        /// <summary>
        /// Tìm kiếm, lấy danh sách các nhà cung cấp dưới dạng phân trangg
        /// </summary>
        /// <param name="page">Trang cần xem</param>
        /// <param name="pagesize">Số dòng trên mỗi trang</param>
        /// <param name="searchValue">Gía trị tìm kiếm</param>
        /// <param name="rowCount"> Output: Tổng số dòng tìm được</param>
        /// <returns></returns>
        public static List<Customer> ListOfCustomers(int page, int pagesize, string searchValue, out int rowCount)
        {
            rowCount = customerDB.Count(searchValue);
            return customerDB.List(page, pagesize, searchValue).ToList();
        }

        /// <summary>
        /// Tìm kiếm, lấy danh sách các nhà cung cấp dưới dạng không phân trangg
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Customer> ListOfCustomers(string searchValue)
        {
            return customerDB.List(1, 0, searchValue).ToList();

        }
        /// <summary>
        /// Bổ sung nhà cung cấp
        /// </summary>
        /// <param name="data"></param>
        /// <returns>mã của nhà cung cấp</returns>
        public static int AddCustomer(Customer data)
        {
            return customerDB.Add(data);

        }
        /// <summary>
        /// Cập nhật nhà cung cấp
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateCustomer(Customer data)
        {
            return customerDB.Update(data);

        }
        /// <summary>
        /// Xóa nhà cung cấp
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public static bool DeleteCustomer(int customerID)
        {
            return customerDB.Delete(customerID);

        }
        /// <summary>
        /// Lấy thông tin của 1 nhà cc
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public static Customer GetCustomer(int customerID)
        {
            return customerDB.Get(customerID);

        }
        /// <summary>
        /// Kiểm tra xem 1 ncc hiện có dữ liệu lq không?
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public static bool InUsedCustomer(int customerID)
        {
            return customerDB.InUsed(customerID);

        }
        #endregion

        #region các nghiệp vụ lq đến nv giao hang
        /// <summary>
        /// Tìm kiếm, lấy danh sách các nhà cung cấp dưới dạng phân trangg
        /// </summary>
        /// <param name="page">Trang cần xem</param>
        /// <param name="pagesize">Số dòng trên mỗi trang</param>
        /// <param name="searchValue">Gía trị tìm kiếm</param>
        /// <param name="rowCount"> Output: Tổng số dòng tìm được</param>
        /// <returns></returns>
        public static List<Shipper> ListOfShippers(int page, int pagesize, string searchValue, out int rowCount)
        {
            rowCount = shipperDB.Count(searchValue);
            return shipperDB.List(page, pagesize, searchValue).ToList();
        }

        /// <summary>
        /// Tìm kiếm, lấy danh sách các nhà cung cấp dưới dạng không phân trangg
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Shipper> ListOfShippers(string searchValue)
        {
            return shipperDB.List(1, 0, searchValue).ToList();

        }
        /// <summary>
        /// Bổ sung nhà cung cấp
        /// </summary>
        /// <param name="data"></param>
        /// <returns>mã của nhà cung cấp</returns>
        public static int AddShipper(Shipper data)
        {
            return shipperDB.Add(data);

        }
        /// <summary>
        /// Cập nhật nhà cung cấp
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateShipper(Shipper data)
        {
            return shipperDB.Update(data);

        }
        /// <summary>
        /// Xóa nhà cung cấp
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public static bool DeleteShipper(int shipperID)
        {
            return shipperDB.Delete(shipperID);

        }
        /// <summary>
        /// Lấy thông tin của 1 nhà cc
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public static Shipper GetShipper(int shipperID)
        {
            return shipperDB.Get(shipperID);

        }
        /// <summary>
        /// Kiểm tra xem 1 ncc hiện có dữ liệu lq không?
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public static bool InUsedShipper(int shipperID)
        {
            return shipperDB.InUsed(shipperID);

        }
        #endregion

        #region các nghiệp vụ lq đến nhân viên
        /// <summary>
        /// Tìm kiếm, lấy danh sách các nhà cung cấp dưới dạng phân trangg
        /// </summary>
        /// <param name="page">Trang cần xem</param>
        /// <param name="pagesize">Số dòng trên mỗi trang</param>
        /// <param name="searchValue">Gía trị tìm kiếm</param>
        /// <param name="rowCount"> Output: Tổng số dòng tìm được</param>
        /// <returns></returns>
        public static List<Employee> ListOfEmployees(int page, int pagesize, string searchValue, out int rowCount)
        {
            rowCount = employeeDB.Count(searchValue);
            return employeeDB.List(page, pagesize, searchValue).ToList();
        }

        /// <summary>
        /// Tìm kiếm, lấy danh sách các nhà cung cấp dưới dạng không phân trangg
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Employee> ListOfEmployees(string searchValue)
        {
            return employeeDB.List(1, 0, searchValue).ToList();

        }
        /// <summary>
        /// Bổ sung nhà cung cấp
        /// </summary>
        /// <param name="data"></param>
        /// <returns>mã của nhà cung cấp</returns>
        public static int AddEmployee(Employee data)
        {
            return employeeDB.Add(data);

        }
        /// <summary>
        /// Cập nhật nhà cung cấp
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateEmployee(Employee data)
        {
            return employeeDB.Update(data);

        }
        /// <summary>
        /// Xóa nhà cung cấp
        /// </summary>
        /// <param name="EmployyeID"></param>
        /// <returns></returns>
        public static bool DeleteEmployee(int employeeID)
        {
            return employeeDB.Delete(employeeID);

        }
        /// <summary>
        /// Lấy thông tin của 1 nhà cc
        /// </summary>
        /// <param name="EmployyeID"></param>
        /// <returns></returns>
        public static Employee GetEmployee(int employeeID)
        {
            return employeeDB.Get(employeeID);

        }
        /// <summary>
        /// Kiểm tra xem 1 ncc hiện có dữ liệu lq không?
        /// </summary>
        /// <param name="EmployyeID"></param>
        /// <returns></returns>
        public static bool InUsedEmployee(int employeeID)
        {
            return employeeDB.InUsed(employeeID);

        }
        #endregion

        #region các nghiệp vụ lq đến loại hàng
        /// <summary>
        /// Tìm kiếm, lấy danh sách các nhà cung cấp dưới dạng phân trangg
        /// </summary>
        /// <param name="page">Trang cần xem</param>
        /// <param name="pagesize">Số dòng trên mỗi trang</param>
        /// <param name="searchValue">Gía trị tìm kiếm</param>
        /// <param name="rowCount"> Output: Tổng số dòng tìm được</param>
        /// <returns></returns>
        public static List<Category> ListOfCategories(int page, int pagesize, string searchValue, out int rowCount)
        {
            rowCount = categoryDB.Count(searchValue);
            return categoryDB.List(page, pagesize, searchValue).ToList();
        }

        /// <summary>
        /// Tìm kiếm, lấy danh sách các nhà cung cấp dưới dạng không phân trangg
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Category> ListOfCategories(string searchValue)
        {
            return categoryDB.List(1, 0, searchValue).ToList();

        }
        /// <summary>
        /// Bổ sung nhà cung cấp
        /// </summary>
        /// <param name="data"></param>
        /// <returns>mã của nhà cung cấp</returns>
        public static int AddCategory(Category data)
        {
            return categoryDB.Add(data);

        }
        /// <summary>
        /// Cập nhật nhà cung cấp
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateCategory(Category data)
        {
            return categoryDB.Update(data);

        }
        /// <summary>
        /// Xóa nhà cung cấp
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        public static bool DeleteCategory(int categoryID)
        {
            return categoryDB.Delete(categoryID);

        }
        /// <summary>
        /// Lấy thông tin của 1 nhà cc
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        public static Category GetCategory(int categoryID)
        {
            return categoryDB.Get(categoryID);

        }
        /// <summary>
        /// Kiểm tra xem 1 ncc hiện có dữ liệu lq không?
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        public static bool InUsedCategory(int categoryID)
        {
            return categoryDB.InUsed(categoryID);

        }
        #endregion
    }
}


