using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniChatApplication.Models
{
    [Table("contact")]
    public class Contact
    {
        [Key]
        [Display(Name = "contactId")]
        [Required(ErrorMessage = "Contact Id cannot  be blank")]
        public int contactId { get; set; }

        [Display(Name = "contactTitle")]
        [Required(ErrorMessage = "Contact Title cannot  be blank")]
        public string contactTitle { get; set; }

        [Display(Name = "contactMes")]
        [Required(ErrorMessage = "Contact Mes cannot  be blank")]
        public string contactMes { get; set; }

        [Display(Name = "contactProgress")]
        [Required(ErrorMessage = "Contact Progress cannot  be blank")]
        public bool contactProgress { get; set; }

        [Display(Name = "contactCustomerPhone")]
        [Required(ErrorMessage = "Contact Customer Phone cannot  be blank")]
        public string contactCustomerPhone { get; set; }

        [Display(Name = "contactCustomerEmail")]
        [Required(ErrorMessage = "Contact Customer Email cannot  be blank")]
        public string contactCustomerEmail { get; set; }
    }
}
