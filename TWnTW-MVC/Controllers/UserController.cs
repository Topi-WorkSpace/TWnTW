using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using TWnTW_MVC.Models;
using TWnTW_MVC.Services.IServices;

namespace TWnTW_MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //Trả view đăng ký
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid && user != null)
            {
                if (_userService.GetUserByEmail(user.UserEmail) != null && _userService.GetUserByUserName(user.Username) != null)
                {
                    if (_userService.AddNewUser(user))
                    {
                        TempData["ThongBaoThanhCong"] = "Đăng ký thành công";
                        return View("Login");
                    }
                    TempData["ThongBaoThatBai"] = "Đăng ký thất bại";
                    return View(user);
                }
                TempData["ThongBaoThatBai"] = "Tài khoản đã tồn tại";
                return View(user);
            }
            return View(user);
        }

        //Trả view đăng nhập
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLogin user)
        {
            User userCheck = new User();
            if (user.Email != null)
            {
                userCheck = _userService.GetUserByEmail(user.Email);
            }
            userCheck = _userService.GetUserByUserName(user.Username);
            if (userCheck != null)
            {
                if (BCrypt.Net.BCrypt.Verify(user.Password, userCheck.Password))
                {
                    TempData["ThongBaoThanhCong"] = "Đăng nhập thành công";
                    //Lưu thông tin user vào session
                    HttpContext.Session.SetString("UserId", userCheck.UserId.ToString());
                    HttpContext.Session.SetString("Username", userCheck.Username);
                    return RedirectToAction("Index", "Home");
                }
            }
            TempData["ThongBaoKhongThanhCong"] = "Đăng nhập thất bại";
            return View(user);
        }

        //trả view Change password
        [HttpGet("{id}")]
        public IActionResult ChangePassword(string id)
        {
           return View(_userService.GetUserById(id));
        }

        [HttpPost]
        public IActionResult ChangePassword(string oldPass, string newPass)
        {
            string userID = HttpContext.Session.GetString("UserId");
            User userCheck = _userService.GetUserById(userID);
            if(BCrypt.Net.BCrypt.Verify(oldPass, userCheck.Password)) //nếu pass hợp lệ
            {
                User userUpdate = new User{
                    UserId = ObjectId.Parse(userID),
                    Password = newPass,
                    UserEmail = userCheck.UserEmail
                };
                if(_userService.UpdateUser(userUpdate) == true)
                {
                    TempData["ThongBaoThanhCong"] = "Đổi mật khẩu thành công";
                    return RedirectToAction("Index", "Home");
                }
                
            }
            return View();
        }

        //Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        //trả view forgot password
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        //Xác thực email
        [HttpPost]
        public IActionResult UserAuth(string email)
        {
            User user = _userService.GetUserByEmail(email);
            if(user != null)
            {
                //Gửi Mã xác nhận
                HttpContext.Session.SetString("ChangePassEmail", email); //lưu email vào session
                HttpContext.Session.SetString("ConfirmCode", _userService.RandomString()); //lưu mã xác nhận vào session
                _userService.SendEmail(user.UserEmail, "Đây là mã xác nhận của bạn: ", HttpContext.Session.GetString("ConfirmCode"));
                return RedirectToAction("InsertConfirmCode");
            }
            return View();
        }



        //trả view
        [HttpGet]
        public IActionResult InsertConfirmCode()
        {
            return View();
        }


        //nhập mã xác nhận
        [HttpPost]
        public IActionResult InsertConfirmCode(string code)
        {
            if (code == HttpContext.Session.GetString("ConfirmCode"))
            {
                return RedirectToAction("CreateNewPassword");
            }
            TempData["ThongBaoThatBai"] = "Mã xác nhận không đúng";
            return View();
        }



        //trả view
        [HttpGet]
        public IActionResult CreateNewPassword()
        {
            return View();
        }


        //Tạo mật khẩu mới
        [HttpPost]
        public IActionResult CreateNewPassword(string newPass)
        {
            User user = _userService.GetUserByEmail(HttpContext.Session.GetString("ChangePassEmail"));
            User userUpdate = new User
            {
                UserEmail = user.UserEmail,
                UserId = user.UserId,
                Password = newPass
            };
            if (_userService.UpdateUser(userUpdate) == true)
            {
                TempData["ThongBaoThanhCong"] = "Đổi mật khẩu thành công";
                return RedirectToAction("Login");
            }
            TempData["ThongBaoKhongThanhCong"] = "Đổi mật khẩu thất bại";
            return View();
        }
    }
}
