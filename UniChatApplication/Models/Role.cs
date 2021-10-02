using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UniChatApplication.Models
{
    [Table("role")]
    public class Role
    {
        public Role(){}

        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [InverseProperty("Role")]
        public List<Account> Accounts { get; set; }

    }
}
