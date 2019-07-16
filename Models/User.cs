using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccount.Models
{
    public class User
    {
        [Key]
        public int UserId{get;set;}
        [Required]
        [Display(Name="First Name")]
        public string FirstName {get;set;}
        [Required]
        [Display(Name="Last Name")]
        public string LastName {get;set;}
        [Required]
        [EmailAddress]
        public string Email {get;set;}
        [Required]
        [DataType(DataType.Password)]
        public string Password {get;set;}
        [Required]
        [DataType(DataType.Password)]
        //NOTMAPPED = MYSQL WILL SKIP AND NOT PUT INTO DB
        [NotMapped]
        [Compare("Password")]
        [Display(Name="Confirm Password")]
        public string ComparePassword {get;set;}
        //MY LIST OF TRANSACTIONS
        public List<Transaction> Transactions {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}