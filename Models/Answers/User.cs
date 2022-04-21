using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bankCore.Models.Answers
{
    public class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime LastLoginTime { get; set; }
    }
}