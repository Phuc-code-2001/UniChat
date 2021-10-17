using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniChatApplication.Models {

    [Table("room_message")]
    public class RoomMessage {
        
        [Key]
        public int Id { get; set; }

        [Column("account_id")]
        [ForeignKey("Account")]
        public int AccountID { get; set; }

        public Account Account { get; set; }

        [Column("room_id")]
        [ForeignKey("RoomChat")]
        public int RoomID { get; set; }

        public RoomChat RoomChat { get; set; }

        public string Content { get; set; }

        [Column("time_message")]
        public DateTime TimeMessage { get; set; }

    }

}