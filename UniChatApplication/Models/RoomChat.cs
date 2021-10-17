using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniChatApplication.Models
{
    // get set data from table "room_chat"
    [Table("room_chat")]
    public class RoomChat
    {
        [Key]
        public int Id { get; set; }
        
        [Column("class_id")]
        [ForeignKey("Class")]
        public int ClassId { get; set; }

        public Class Class { get; set; }

        [Column("subject_id")]
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }

        public Subject Subject { get; set; }

        [Column("teacher_id")]
        [ForeignKey("TeacherProfile")]
        public int TeacherId { get; set; }

        public TeacherProfile TeacherProfile { get; set; }
    }
}
