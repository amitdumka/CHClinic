using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHClinic.Models.Data
{
    class AuthUser
    {
        public int AuthUserId { get; set; }
       
        [Index(IsUnique = true)]
        [StringLength(20)]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int IsEnabled { get; set; }
    }

    class AuthUserInfo
    {
        public int AuthUserInfoId {get;set;}
        public int UserID { get; set; }
        public DateTime LoggedOn { get; set; }
    }
}