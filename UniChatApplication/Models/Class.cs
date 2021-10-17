using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace UniChatApplication.Models
{
    [Table("class")]
    public class Class
    {
        [Key]
        public int Id { get; set; }
        
    
        public string Name { get; set; }

        [InverseProperty("Class")]
        public ICollection<StudentProfile> StudentProfiles { get; set; }

        [InverseProperty("Class")]
        public ICollection<RoomChat> RoomChats { get; set; }

    }
}
