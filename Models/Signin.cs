using System.ComponentModel.DataAnnotations;

namespace BankAccount.Models
{
    public class Signin
    {
        [Required]
        [EmailAddress]
        public string SigninEmail {get;set;}
        [Required]
        [DataType(DataType.Password)]
        public string SigninPassword {get;set;}

    }
}