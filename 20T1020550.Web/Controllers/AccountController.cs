using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using _20T1020550.BusinessLayers;
using _20T1020550.DomainModels;

namespace _20T1020550.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// Trang đăng nhập vào hệ thống
        /// </summary>
        /// <returns></returns>
        
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string userName = "", string password = "")
        {
            

            ViewBag.UserName = userName;
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                
                ModelState.AddModelError("", "Vui lòng nhập đủ thông tin");
                return View();
            }

            var userAccount = UserAccountService.Authorize(AccountTypes.Employee, userName, password);

            if(userAccount == null)
            {
                ModelState.AddModelError("", "Đăng nhập thất bại");
                return View();
            }

            string cookieValue = Newtonsoft.Json.JsonConvert.SerializeObject(userAccount);
            FormsAuthentication.SetAuthCookie(cookieValue, false);
            return RedirectToAction("Index", "Home");
                
          
        }

        public ActionResult ChangePassword(string userName = "", string oldPassword = "", string newPassword = "", string rePassword = "")
        {

            if (string.IsNullOrWhiteSpace(oldPassword))
                ModelState.AddModelError("oldPassword", " Không được để trống");
            if (string.IsNullOrWhiteSpace(newPassword))
                ModelState.AddModelError("newPassword", " Không được để trống");

            if (string.IsNullOrWhiteSpace(rePassword))
                ModelState.AddModelError("rePassword", " Không được để trống");

            
            if (!rePassword.Equals(newPassword))
            {
                ModelState.AddModelError("", "Mật khẩu mới không trùng khớp");
                return View();
            }
            if (!ModelState.IsValid)
            {
                var userAccount = UserAccountService.ChangePassword(AccountTypes.Employee, userName, oldPassword, newPassword);
                ViewBag.Title =  "Đổi mật khẩu thành công";
                return View();
            }
            return View("Index");

        }
        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}