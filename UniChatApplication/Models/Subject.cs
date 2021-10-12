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
        public string SubjectCode { get; set; }
        
        [Required]
        [MinLength(6)]
        [MaxLength(50)]
        public string FullName { get; set; }

    }
}