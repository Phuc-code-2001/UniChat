using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniChatApplication.Models
{
    
    abstract public class Profile
    {

        public static string defaultAvatar = "/media/profiles/default.png";

        public virtual int AccountID { get; set; }
        public virtual Account Account { get; set; } 

    }
}
