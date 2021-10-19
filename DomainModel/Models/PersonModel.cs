using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace DomainModel.Models
{
    public abstract class PersonModel
    {
        [Required(ErrorMessage = "Voer u naam in")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Voer u Email in")]
        [BindProperty, DataType(DataType.EmailAddress)]
        [Key]
        public string Email { get; set; }
        
    }
}
