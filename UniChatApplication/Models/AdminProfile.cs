using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UniChatApplication.Models
{
    [Table("admin_profile")]
    public class AdminProfile
    {
        public AdminProfile()
        {

        }

        [Key]
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Gender { get; set; }

        [ForeignKey("AdminAccount")]
        public int Account_id { get; set; }
        public Account AdminAccount { get; set; }

    }
}
