using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Nancy.Authentication.Forms;
using Nancy.Security;
using Nancy;
using System.Security.Cryptography;
namespace WiFiSpeakerWebConfig
{
	public class UserDatabase : IUserMapper
	{
		private readonly static List<Tuple<string, string, Guid>> users = new List<Tuple<string, string, Guid>>();
		static UserDatabase()
		{
			users.Add(new Tuple<string, string, Guid>("admin",
				GetPasswordHash("password"),
				new Guid("55E1E49E-B7E8-4EEA-8459-7A906AC4D4C0")));
			users.Add(new Tuple<string, string, Guid>("user",
				GetPasswordHash("password"),
				new Guid("56E1E49E-B7E8-4EEA-8459-7A906AC4D4C0")));
		}
		public UserDatabase()
		{
		}

		public IUserIdentity GetUserFromIdentifier(Guid identifier, NancyContext context)
		{
			var userRecord = users.Where(u => u.Item3 == identifier).FirstOrDefault();

			return userRecord == null
					   ? null
					   : new UserIdentity { UserName = userRecord.Item1 };
		}

		private static string GetPasswordHash(string input)
		{
			using (var hashFunc = SHA512.Create())
			{
				var data = Encoding.Unicode.GetBytes(input);
				var hash = hashFunc.ComputeHash(data);
				return Encoding.Unicode.GetString(hash);
			}
		}
		public static Guid? ValidateUser(string username, string password)
		{
			string hash = GetPasswordHash(password);
			var userRecord = users.Where(u => u.Item1 == username && u.Item2 == hash).FirstOrDefault();
			if (userRecord == null)
			{
				return null;
			}
			return userRecord.Item3;
		}
	}
}
