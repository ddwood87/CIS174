using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ClassWebApp.Data;
namespace ClassWebApp.Areas.Admin.Models
{
    public class User
    {        
        private string _userName;
        private string _password;
        private int _accessLevel;

        [Key]
        [Required]
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        [Required]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        [Required]
        [Range(1, 10)]
        public int AccessLevel
        {
            get { return _accessLevel; }
            set { _accessLevel = value; }
        }

        public static User GetUser(string userName)
        {
            User u;
            if (Exists(userName))
            {
                using (ClassContext context = new ClassContext())
                {
                    u = context.Users.First(s => s.UserName == userName);
                }
                return u;
            }
            return null;
        }
        public static List<User> GetAllUsersList()
        {
            List<User> list;
            using (ClassContext context = new ClassContext())
            {
                list = context.Users.ToList();
            }
            return list;
        }
        internal void SaveUser()
        {
            using (ClassContext context = new ClassContext())
            {
                if (!context.Users.Any(u => u.UserName.Equals(_userName)))
                {
                    context.Users.Add(this);
                }
                else { context.Users.Update(this); }
                context.SaveChanges();
            }
        }
        internal static void DeleteStudent(string userName)
        {
            using (ClassContext context = new ClassContext())
            {
                User u = GetUser(userName);
                context.Users.Remove(u);
                context.SaveChanges();
            }
        }
        internal static bool Exists(string userName)
        {
            using (ClassContext context = new ClassContext())
            {
                return context.Users.Any(u => u.UserName.Equals(userName));
            }
        }
    }
}
