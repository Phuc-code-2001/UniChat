

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniChatApplication.Models
{
    [Table("room_deadline")]
    public class RoomDeadLine
    {
        [Key]
        public int Id { get; set; }

        [Column("room_id")]
        [ForeignKey("RoomChat")]
        public int RoomId { get; set; }
        public RoomChat RoomChat { get; set; }

        [MaxLength(500)]
        public string Content { get; set; }

        [Column("expiration_time")]
        public DateTime ExpirationTime { get; set; }

    }

}