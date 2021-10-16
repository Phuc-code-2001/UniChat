using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniChatApplication.Models
{
    [Table("teacher_profile")]
    public class TeacherProfile : Profile
    {

        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Avatar { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public bool Gender { get; set; }

        public DateTime Birthday { get; set; }

        [Column("teacher_code")]
        public string TeacherCode { get; set; }

        [Column("account_id")]
        [ForeignKey("Account")]
        public  override int AccountID { get; set; }
        public override Account Account { get; set; }


        [NotMapped]
        public string GenderText {
            get {
                if (this.Gender) return "Male";
                if (!this.Gender) return "Female";
                return "Unknown";
            }
        }

        [InverseProperty("TeacherProfile")]
        public List<RoomChat> RoomChats { get; set; }

    }
}
