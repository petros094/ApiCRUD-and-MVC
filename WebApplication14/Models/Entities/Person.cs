using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication14.Models
{
    public class Person
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Personid { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName  { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [MaxLength(30)]
        [EmailAddress]
        [Index(IsUnique =true)]
        public string Email { get; set; }
    }
}