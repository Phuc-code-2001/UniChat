using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniChatApplication.Models
{
    [Table("account")]
    public class Account
    {

        // Id Property
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        public string Password { get; set; }

        [Column("role_id")]
        public int RoleID { get; set; }

        // Get RoleName
        [NotMapped]
        public string RoleName {
            get {
                if (RoleID == 1) return "Student";
                if (RoleID == 2) return "Teacher";
                if (RoleID == 3) return "Admin";
                return "Unknown";
            }
        }

        
        public StudentProfile StudentProfile { get; set; }

        public TeacherProfile TeacherProfile { get; set; }

        public AdminProfile AdminProfile { get; set; }
        
        [InverseProperty("Account")]
        public ICollection<RoomMessage> RoomMessages { get; set; }

        [InverseProperty("Account")]
        public ICollection<GroupMessage> GroupMessages { get; set; }

    }
}
