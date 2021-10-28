using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace UniChatApplication.Models
{
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

        [InverseProperty("RoomChat")]
        public ICollection<RoomMessage> Messages { get; set; }

        public ICollection<RoomDeadLine> DeadLines { get; set; }

        [InverseProperty("RoomChat")]
        public ICollection<GroupChat> GroupChats { get; set; }

    }
}
