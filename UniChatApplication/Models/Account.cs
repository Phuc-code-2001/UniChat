using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniChatApplication.Models
{
    // get set data from table "account"
    [Table("account")]
    public class Account
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        public string Password { get; set; }

        [Column("role_id")]
        public int RoleID { get; set; }

        [NotMapped]
        public string RoleName {
            get {
                if (RoleID == 1) return "Student";
                if (RoleID == 2) return "Teacher";
                if (RoleID == 3) return "Admin";
                return "Unknown";
            }
        }

    }
}
