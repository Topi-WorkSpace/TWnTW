using MongoDB.Bson;
using TWnTW_MVC.Models;

namespace TWnTW_MVC.Services.IServices
{
    public interface IUserService
    {
        bool AddNewUser(User user);
        User GetUserById(string id);
        User GetUserByEmail(string email);
        User GetUserByUserName(string username);
        bool UpdateUser(User user);
        void SendEmail(string email, string subject, string message);
        string RandomString();
    }
}
