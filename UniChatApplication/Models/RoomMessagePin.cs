

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniChatApplication.Models
{
    [Table("room_marked_message")]
    public class RoomMessagePin
    {
        [Key]
        public int Id { get; set; }

        [Column("room_message_id")]
        public int RoomMessageId { get; set; }
        [ForeignKey("RoomMessageId")]
        public RoomMessage RoomMessage { get; set; }

        [Column("time_marked")]
        public DateTime Time { get; set; }

    }

}