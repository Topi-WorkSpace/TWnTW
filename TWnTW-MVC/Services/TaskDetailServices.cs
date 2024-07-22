using MongoDB.Bson;
using TWnTW_MVC.Data;
using TWnTW_MVC.Models;
using TWnTW_MVC.Services.IServices;
using ZstdSharp.Unsafe;

namespace TWnTW_MVC.Services
{
    public class TaskDetailServices : ITaskDetailServices
    {
        private readonly MongoDbContext _db;
        public TaskDetailServices(MongoDbContext db)
        {
            _db = db;
        }
        public TaskDetail AddTaskDetail(TaskDetail taskDetail)
        {
            if (taskDetail == null)
            {
                return null;
            }
            _db.TaskDetails.Add(taskDetail);
            _db.ChangeTracker.DetectChanges();
            _db.SaveChanges();
            return taskDetail;
        }

        public TaskDetail DeleteTaskDetail(ObjectId taskDetailId)
        {
            var task = _db.TaskDetails.FirstOrDefault(task => task.TaskDetailId == taskDetailId);
            if (task == null)
            {
                return null;
            }
            _db.TaskDetails.Remove(task);
            _db.ChangeTracker.DetectChanges();
            _db.SaveChanges();
            return task;
        }

        public List<TaskDetail> GetAllTaskDetail()
        {

            return _db.TaskDetails.ToList();
        }
        public TaskDetail UpdateTaskDetail(ObjectId taskDetailId, TaskDetail taskDetail)
        {
            var td = _db.TaskDetails.FirstOrDefault(td => td.TaskDetailId == taskDetailId);
            if (td == null)
            {
                return null;
            }
            td.Descride = taskDetail.Descride;
            td.Status = taskDetail.Status;
            td.CreateDate = taskDetail.CreateDate;
            td.EndDate = taskDetail.EndDate;

            _db.TaskDetails.Update(td);
            _db.ChangeTracker.DetectChanges();
            _db.SaveChanges();
            return td;
        }
    }
}
