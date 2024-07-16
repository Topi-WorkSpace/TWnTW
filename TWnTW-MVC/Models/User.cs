using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TWnTW_MVC.Models
{
    [Collection("User")]
    public class User
    {
        public ObjectId UserId { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email là bắt buộc")]
        public string UserEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tài khoản là bắt buộc")]
        [Display(Name = "Tài khoản")]
        public string Username { get; set; } = string.Empty;

    }
}
