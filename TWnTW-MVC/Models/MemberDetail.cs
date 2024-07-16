using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TWnTW_MVC.Models
{
    [Collection("MemberDetail")]
    public class MemberDetail
    {
        public ObjectId MemberDetailId { get; set; }

        [Required(ErrorMessage = "Work space Id là bắt buộc")]
        [Display(Name = "Work space id")]        
        public ObjectId WSId { get; set; }

        [Required(ErrorMessage = "Mã người dùng là bắt buộc")]
        [Display(Name = "Mã người dùng")]        
        public ObjectId UserId { get; set; }

        [Required(ErrorMessage = "Trạng thái là bắt buộc")]
        [Display(Name = "Trạng thái")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Vai trò là bắt buộc")]
        [Display(Name = "Vai trò")]
        public string Role { get; set; }

    }
}
