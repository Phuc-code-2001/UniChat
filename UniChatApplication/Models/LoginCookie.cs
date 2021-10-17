using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniChatApplication.Models
{
    // get set data from table "login_cookie"
    [Table("login_cookie")]
    public class LoginCookie
    {
        [Key]
        public int Id { get; set; }

        [Column("login_key")]
        public string Key { get; set; }

        [Column("account_id")]
        public int AccountID { get; set; }

        [Column("expiration_time")]
        public DateTime ExpirationTime { get; set; }

    }
}
