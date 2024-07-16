using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TWnTW_MVC.Models
{
    [Collection("TaskDetail")]
    public class TaskDetail
    {
        public ObjectId TaskDetailId { get; set; }

        [Display(Name = "Mô tả")]
        public string Descride { get; set; }

        [Required(ErrorMessage = "Trạng thái của task là bắt buộc")]
        [Display(Name = "Trạng thái")]
        public string Status { get; set; }

        [Display(Name = "Ngày tạo task")]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        [Display(Name = "Ngày tạo task")]
        public DateTime EndDate { get; set; } = DateTime.Now;

    }
}
