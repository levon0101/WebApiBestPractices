using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiBestPractices.Entities.ValidationAttributes;

namespace WebApiBestPractices.Entities.Model
{
    public class Account
    {
        [Column("AccountId")]
        public Guid Id { get; set; }

        [MinYear(2008)]
        [Required(ErrorMessage = "Date created is required")]
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "Account type is required")]
        public string AccountType { get; set; }

        [ForeignKey(nameof(Owner))]
        public Guid OwnerId { get; set; }

        public Owner Owner { get; set; }
    }
}
