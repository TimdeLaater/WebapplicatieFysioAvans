using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace DomainModel.Models
{
    public class TherapistModel: TeacherModel
    {
        [Required(ErrorMessage = "Voer u BIG-nummer in")]
        [MaxLength(11)]
        public int BigNr { get; set; } 
        [Required(ErrorMessage = "Voer u telefoonnummer in")]
        [BindProperty, DataType(DataType.PhoneNumber)]
        public int PhoneNr { get; set; }
    }
}
