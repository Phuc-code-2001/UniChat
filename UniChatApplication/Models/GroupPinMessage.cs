
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniChatApplication.Models
{
    [Table("group_marked_message")]
    public class GroupPinMessage
    {

        [Key]
        public int Id { get; set; }

        [Column("group_message_id")]
        [ForeignKey("GroupMessage")]
        public int GroupMessageId { get; set; }
        
        public GroupMessage GroupMessage { get; set; }

        [Column("time_marked")]
        public DateTime Time { get; set; }
        
    }
}