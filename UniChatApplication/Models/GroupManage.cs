

using System.ComponentModel.DataAnnotations.Schema;
using UniChatApplication.Data;

namespace UniChatApplication.Models
{
    [Table("group_manage")]
    public class GroupManage
    {

        public int Id { get; set; } = 0;

        [Column("student_id")]
        [ForeignKey("StudentProfile")]
        public int StudentId { get; set; }

        public StudentProfile StudentProfile { get; set; }

        [Column("group_id")]
        [ForeignKey("GroupChat")]
        public int GroupId { get; set; }

        public GroupChat GroupChat { get; set; }

        [Column("role")]
        public bool Role { get; set; } = false;

        [NotMapped]
        public string RoleText {
            get {
                if (Role) return "Leader";
                else return "Member";
            }
        }


    }
    
}