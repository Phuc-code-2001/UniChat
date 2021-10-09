using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniChatApplication.Models
{
    [Table("admin_profile")]
    public class AdminProfile : Profile
    {

        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Avatar { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int Gender { get; set; }

        [Column("account_id")]
        [ForeignKey("Account")]
        public override int AccountID { get; set; }
        public override Account Account { get; set; }

        [NotMapped]
        public string GenderText {
            get {
                if (this.Gender == 1) return "Male";
                if (this.Gender == 0) return "Female";
                return "Unknown";
            }
        }

    }
}
