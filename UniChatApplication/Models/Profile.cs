using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniChatApplication.Models
{
    
    abstract public class Profile
    {

        public static string defaultAvatar = "/media/profiles/default.png";

        public virtual int Id { get; set; }
        
        public virtual string FullName { get; set; }

        public virtual string Avatar { get; set; }

        public virtual string Email { get; set; }

        public virtual string Phone { get; set; }

        public  virtual bool Gender { get; set; }

        public virtual int AccountID { get; set; }
        public virtual Account Account { get; set; } 

    }
}
