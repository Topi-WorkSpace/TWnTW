using MongoDB.Bson;
using System.Net;
using System.Net.Mail;
using System.Text;
using TWnTW_MVC.Data;
using TWnTW_MVC.Models;
using TWnTW_MVC.Services.IServices;

namespace TWnTW_MVC.Services
{
    public class UserService : IUserService
    {
        private readonly MongoDbContext _context;
        public UserService() { }
        public UserService(MongoDbContext context)
        {
            _context = context;
        }

        //Get user by ID
        public User GetUserById(string id)
        {
            return _context.Users.FirstOrDefault(a => a.UserId == ObjectId.Parse(id));
        }

        //Get user by email
        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(a => a.UserEmail == email);
        }

        //get user by username
        public User GetUserByUserName(string username)
        {
            return _context.Users.FirstOrDefault(a => a.Username == username);
        }

        //Register for user
        public bool AddNewUser(User user)
        {
            //generate new id for user
            user.UserId = ObjectId.GenerateNewId();
            //encrypt password
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            _context.Users.Add(user);
            int check = _context.SaveChanges();
            if (check > 0)
            {
                return true;
            }
            return false;
        }

        //Change password for user
        public bool UpdateUser(User user)
        {
            //encrypt password
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            _context.Users.Update(user);
            int check = _context.SaveChanges();
            if (check > 0)
            {
                return true;
            }
            return false;
        }

        //Send mail
        public async Task SendEmail(string email, string subject, string message)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("kyfan2778@gmail.com", "pweb xfhe hdjx bjrd"),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("kyfan2778@gmail.com"),
                Subject = subject,
                Body = message,
                IsBodyHtml = true,
            };

            mailMessage.To.Add(email);

            await smtpClient.SendMailAsync(mailMessage);
        }

        public string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder sb = new StringBuilder(10);
            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                int index = random.Next(chars.Length);
                sb.Append(chars[index]);
            }
            return sb.ToString();
        }
    }
}
