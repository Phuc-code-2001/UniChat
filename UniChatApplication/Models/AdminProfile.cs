using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniChatApplication.Models
{
    [Table("admin_profile")]
    public class AdminProfile : Profile
    {

        public AdminProfile(){
            this.Avatar = Profile.defaultAvatar;
        }

        [Key]
        public override int Id { get; set; }
        
        public override string FullName { get; set; }

        public override string Avatar { get; set; }

        public override string Email { get; set; }

        public override string Phone { get; set; }

        public override bool Gender { get; set; }

        [Column("account_id")]
        [ForeignKey("Account")]
        public override int AccountID { get; set; }
        public override Account Account { get; set; }

        [NotMapped]
        public string GenderText {
            get {
                if (this.Gender) return "Male";
                if (!this.Gender) return "Female";
                return "Unknown";
            }
        }

    }
}
