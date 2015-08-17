using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Nancy.Authentication.Forms;
using Nancy.Security;
using Nancy;
namespace WiFiSpeakerWebConfig
{
    public class UserDatabase : IUserMapper
    {
        private readonly static List<UserDbObj> users = new List<UserDbObj>();

        static UserDatabase()
        {
            users.Add(new UserDbObj("admin", "password", new Guid("55E1E49E-B7E8-4EEA-8459-7A906AC4D4C0")));
            users.Add(new UserDbObj("user", "password", new Guid("56E1E49E-B7E8-4EEA-8459-7A906AC4D4C0")));
        }

        public IUserIdentity GetUserFromIdentifier(Guid identifier, NancyContext context)
        {
            var userRecord = users.Where(u => u.Guid == identifier).FirstOrDefault();
            if (userRecord != null)
            {
                return new UserIdentity
                       {
                           UserName = userRecord.Name
                       };
            }
            return null;
        }

        public static Guid? ValidateUser(string username, string password)
        {
            var userRecord = users.Where(u => u.Name == username && u.Password == password).FirstOrDefault();

            if (userRecord == null)
            {
                return null;
            }

            return userRecord.Guid;
        }
    }
    class UserDbObj
    {
        public string Name { get; private set; }
        public string Password { get; private set; }
        public Guid Guid { get; private set; }

        public UserDbObj(string name, string pass, Guid guid)
        {
            this.Name = name;
            this.Password = pass;
            this.Guid = guid;
        }
    }
}
