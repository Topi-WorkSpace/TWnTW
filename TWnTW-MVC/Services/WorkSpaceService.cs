using MongoDB.Bson;
using TWnTW_MVC.Data;
using TWnTW_MVC.Models;
using TWnTW_MVC.Services.IServices;

namespace TWnTW_MVC.Services
{
    public class WorkSpaceService : IWorkSpaceService
    {
        private readonly MongoDbContext _context;
        public WorkSpaceService(MongoDbContext context)
        {
            _context = context;
        }
        public WorkSpace AddWorkSpace(WorkSpace workSpace)
        {
            if (workSpace == null)
            {
                return null;
            }

            _context.WorkSpaces.Add(workSpace);
            _context.ChangeTracker.DetectChanges();
            _context.SaveChanges();

            return workSpace;
        }

        public WorkSpace DeleteWorkSpace(ObjectId workSpaceId)
        {
            var wp = _context.WorkSpaces.FirstOrDefault(wp => wp.WSId == workSpaceId);

            if (wp == null)
            {
                return null;
            }

            _context.WorkSpaces.Remove(wp);
            _context.ChangeTracker.DetectChanges();
            _context.SaveChanges();

            return wp;
        }

        public List<WorkSpace> GetAllWorkSpaces(ObjectId userId)
        {
            throw new NotImplementedException();
        }

        public List<WorkSpace> SearchWorkSpaces(string SearchTerm)
        {
            throw new NotImplementedException();
        }

        public WorkSpace UpdateWorkSpace(ObjectId workSpaceId, WorkSpace workSpace)
        {
            var wp = _context.WorkSpaces.FirstOrDefault(wp => wp.WSId == workSpaceId);

            if (wp == null)
            {
                return null;
            }

            wp.WSName = workSpace.WSName;
            wp.Description = workSpace.Description;
            wp.Status = workSpace.Status;

            _context.WorkSpaces.Update(wp);
            _context.ChangeTracker.DetectChanges();
            _context.SaveChanges();

            return wp;
        }
    }
}
