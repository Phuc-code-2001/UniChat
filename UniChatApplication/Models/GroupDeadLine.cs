
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniChatApplication.Models
{
    [Table("group_dealine")]
    public class GroupDeadLine
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("GroupChat")]
        public int GroupId { get; set; }

        public GroupChat GroupChat { get; set; }

        [MaxLength(500)]
        [Required]
        public string Content { get; set; }

        [Column("expiration_time")]
        public DateTime ExpirationTime { get; set; }
    }
}