using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniChatApplication.Models
{
    [Table("group_message")]
    public class GroupMessage
    {
        [Key]
        public int Id { get; set; }
        
        [Column("account_id")]
        [ForeignKey("Account")]
        public int AccountId { get; set; }

        public Account Account { get; set; }

        [Column("group_id")]
        [ForeignKey("GroupChat")]
        public int GroupId { get; set; }

        public GroupChat GroupChat { get; set; }

        [MaxLength(500)]
        public string Content { get; set; }

        [Column("time_message")]
        public DateTime TimeMessage { get; set; }
        
        [InverseProperty("GroupMessage")]
        public ICollection<GroupPinMessage> AllPinMessage { get; set; }
    }
}