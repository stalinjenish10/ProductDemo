using Microsoft.AspNetCore.Mvc;
using ProductDemo.Repository.Interface;
using ProductDemo.ViewModels;

namespace ProductDemo.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginRepository _loginRepository;

        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public IActionResult Index()
        {
            SessionClear();
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel loginData)
        {
            try
            {
                var userDetails = _loginRepository.GetUserDetails(loginData.UserName, loginData.Password);
                if (userDetails != null)
                {
                    HttpContext.Session.SetString("LoginId", userDetails.UserId.ToString());
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ViewBag.ErrorMessage = "Login Error";
                    return View(loginData);
                }
                
            }
            catch (Exception ex)
            {
                return View(ex);
            }

        }

        private void SessionClear()
        {
            HttpContext.Session.Remove("LoginId");
        }
    }
}
