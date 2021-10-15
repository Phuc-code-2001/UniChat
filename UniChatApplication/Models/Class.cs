using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace UniChatApplication.Models
{
    [Table("class")]
    public class Class
    {
        [Key]
        public int Id { get; set; }
        
        
        public string Name { get; set; }

        [InverseProperty("Class")]
        public List<StudentProfile> StudentProfiles { get; set; }

        [InverseProperty("Class")]
        public List<RoomChat> RoomChats { get; set;}

    }
}
