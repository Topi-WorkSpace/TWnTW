using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TWnTW_MVC.Models
{
    [Collection("Workspace")]
    public class WorkSpace
    {

        public ObjectId WSId { get; set; }

        [Required(ErrorMessage = "Tên của workspace là bắt buộc")]
        [Display(Name = "Tên work space")]
        public string WSName { get; set; } = string.Empty;

        [Display(Name = "Mô tả")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Trạng thái của workspace là bắt buộc")]
        [Display(Name = "Trạng thái")]
        public string Status { get; set; } = string.Empty;

    }
}
