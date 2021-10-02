using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace UniChatApplication.Models
{
    [Table("account")]
    public class Account
    {

        private string _password;
        private string _hashedPassword;

        private const int minLengthUsername = 6;
        private const int maxLengthUsername = 50;
        private const int minLengthPassword = 6;
        private const int maxLengthPassword = 32;
        private const int minRoleId = 1;
        private const int maxRoleId = 3;

        private Dictionary<string, string> invalidMessages;

        public Account() {
            invalidMessages = new Dictionary<string, string>();
            invalidMessages["Username"] = string.Empty;
            invalidMessages["Password"] = string.Empty;
            invalidMessages["Role"] = string.Empty;
        }
        [Key]
        public int Id { get; set; }

        [Range(minLengthUsername, maxLengthUsername)]
        public string Username { get; set; }

        //[Range(minLengthPassword, maxLengthPassword)]
        [NotMapped()]
        public string Password {
            get {
                return "";
            }
            set {
                if (value != string.Empty)
                {
                    using (MD5 hasher = MD5.Create())
                    {
                        string hashText = BitConverter.ToString(hasher.ComputeHash(Encoding.UTF8.GetBytes(value))).Replace("-", String.Empty);
                        _hashedPassword = hashText;
                    }
                }
            }
        }


        [Column("password")]
        public string HashPassword
        {
            get
            {
                return _hashedPassword;
            }
            set
            {
                // Set password from database
                _password = new string('*', minLengthPassword);
                _hashedPassword = value;
            }
        }

        [ForeignKey("Role")]
        public int Role_id { get; set; }
        public Role Role { get; set; }

        [InverseProperty("AdminAccount")]
        public AdminProfile Profile { get; set; }

        public bool usernameIsValid() {
            bool lengthValidate = Username.Length >= minLengthUsername && Username.Length <= maxLengthUsername;
            if (!lengthValidate)
            {
                invalidMessages["Username"] = $"Username must be {minLengthUsername} - {maxLengthUsername} characters.";
            }
            return lengthValidate;
        }
        public bool passwordIsValid() {
            bool lengthValidate = _password.Length >= minLengthPassword && _password.Length <= maxLengthPassword;
            if (!lengthValidate)
            {
                invalidMessages["Password"] = $"Password must be {minLengthPassword} - {maxLengthPassword} characters.";
            }
            return lengthValidate;
        }
        public bool roleIsValid()
        {
            bool rangeValidate = Role_id >= minRoleId && Role_id <= maxRoleId;
            if (!rangeValidate)
            {
                invalidMessages["Role"] = $"Role value must be range {minRoleId} - {maxRoleId}.";
            }
            return rangeValidate;
        }
        public bool IsValid() => usernameIsValid() && passwordIsValid() && roleIsValid();

        public Dictionary<string, string> InvalidMessages
        {
            get { return invalidMessages; }
        }

    }
}
