using System.ComponentModel.DataAnnotations;
using System;
namespace BankAccount.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId {get;set;}
        //Foreign Key vv
        public int UserId {get;set;}
        //NAVIGATIONAL PROPERTY vv
        public User AccountHolder {get;set;}
        [Required]
        [Display(Name="Deposit/Withdraw")]
        public double Amount {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;


    }
}