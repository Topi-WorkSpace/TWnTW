using MongoDB.Bson;
using TWnTW_MVC.Models;

namespace TWnTW_MVC.Services.IServices
{
    public interface IWorkSpaceService
    {
        public List<WorkSpace> GetAllWorkSpaces(ObjectId userId);
        public List<WorkSpace> SearchWorkSpaces(string SearchTerm);
        public WorkSpace AddWorkSpace(WorkSpace workSpace);
        public WorkSpace UpdateWorkSpace(ObjectId workSpaceId,WorkSpace workSpace);
        public WorkSpace DeleteWorkSpace(ObjectId workSpaceId);
    }
}
