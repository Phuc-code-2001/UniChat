

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniChatApplication.Models
{
    [Table("group_chat")]
    public class GroupChat
    {

        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Column("_index")]
        public int Order { get; set; }

        [Column("room_id")]
        [ForeignKey("RoomChat")]
        public int RoomID { get; set; }

        public RoomChat RoomChat { get; set; }

        public ICollection<GroupMessage> Messages { get; set; }

        public ICollection<GroupDeadLine> DeadLines { get; set; }

    }
}