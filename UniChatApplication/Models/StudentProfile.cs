using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniChatApplication.Models
{
    [Table("student_profile")]
    public class StudentProfile : Profile
    {

        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Avatar { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int Gender { get; set; }

        public string Major { get; set; }

        public DateTime Birthday { get; set; }

        [Column("student_code")]
        public string StudentCode { get; set; }

        [Column("account_id")]
        [ForeignKey("Account")]
        public override int AccountID { get; set; }
        public override Account Account { get; set; }

        [Column("class_id")]
        [ForeignKey("Class")]
        public int? ClassID { get; set; }

        public Class Class { get; set; }

        public string getClassName() => this.Class?.Name;

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
