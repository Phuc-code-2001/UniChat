using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UniChatApplication.Models
{
    [Table("login_cookie")]
    public class LoginCookie
    {
        [Key]
        public int Id { get; set; }

        public string Key { get; set; }

        public int AccountID { get; set; }

        public DateTime ExpirationTime { get; set; }

    }
}
