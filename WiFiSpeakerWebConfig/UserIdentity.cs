﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy.Security;

namespace WiFiSpeakerWebConfig
{
    public class UserIdentity : IUserIdentity
    {
        public IEnumerable<string> Claims
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }
    }
}