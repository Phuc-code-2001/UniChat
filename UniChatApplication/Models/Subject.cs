using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniChatApplication.Models
{
    [Table("subject")]
    public class Subject
    {
        [Key]
        public int Id { get; set; }

        [Column("code")]
        [Required]
        [MaxLength(10)]
        public string SubjectCode { get; set; }
        
        [Required]
        [MaxLength(255)]
        public string FullName { get; set; }

        [InverseProperty("Subject")]
        public List<RoomChat> RoomChats { get; set; }

    }
}