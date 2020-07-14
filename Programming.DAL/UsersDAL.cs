using System;
using System.Collections.Generic;
using System.Linq;

namespace Programming.DAL
{
    public class UsersDAL : BaseDAL
    {
        public IEnumerable<Users> GetAllUsers()
        {
            return db.Users;
        }
        public Users GetUserByApiKey(string apiKey)
        {
            return db.Users.FirstOrDefault(x => x.UserKey.ToString() == apiKey);
        }

        public Users GetUserByName(string name)
        {
            return db.Users.SingleOrDefault(x => x.Name == name); 
        }

        public bool CheckUserByName(Users _user)
        {
            var checkUserName = db.Users.Any(q => q.Name == _user.Name);
            if (checkUserName)
            {
                return true;
            }
            return false;
            
        }

        public Users CreateUser (Users _user)
        {
            var checkUserName = db.Users.Any(q => q.Name == _user.Name);
            var crypto = new SimpleCrypto.PBKDF2();
            var encrypedPassword = crypto.Compute(_user.Password);
            Users user = new Users();
            var checkAdmin = db.Users.Any(q => q.UserId >= 1);
            if (_user.UserId == 0 && checkAdmin == true)
            {
                user.Name = _user.Name;
                user.Password = encrypedPassword;
                user.Salt = crypto.Salt;
                user.Role = "U";
                user.UserKey = Guid.NewGuid();
                db.Users.Add(user);
                db.SaveChanges();
            }
            else if (_user.UserId == 0 && checkAdmin == false)
            {
                user.Name = _user.Name;
                user.Password = encrypedPassword;
                user.Salt = crypto.Salt;
                user.Role = "A";
                user.UserKey = Guid.NewGuid();
                db.Users.Add(user);
                db.SaveChanges();
            }
            return _user;     
        }

        public string LoginCheck(Users userModel)
        {
            var crypto = new SimpleCrypto.PBKDF2();
            var user = db.Users.FirstOrDefault(x => x.Name == userModel.Name);

            if (user != null)
            {
                if (user.Password != null)
                {
                    if (user.Password == crypto.Compute(userModel.Password, user.Salt))
                    {                       
                        return user.UserKey.ToString();
                    }
                }
            }          
            return "false";
        }
    }
}
