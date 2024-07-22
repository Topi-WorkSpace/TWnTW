using MongoDB.Bson;
using TWnTW_MVC.Models;

namespace TWnTW_MVC.Services.IServices
{
    public interface ITaskDetailServices
    {
        public List<TaskDetail> GetAllTaskDetail();
        public TaskDetail AddTaskDetail(TaskDetail taskDetail);
        public TaskDetail UpdateTaskDetail(ObjectId taskDetailId, TaskDetail taskDetail);
        public TaskDetail DeleteTaskDetail(ObjectId taskDetailId);


    }
}
