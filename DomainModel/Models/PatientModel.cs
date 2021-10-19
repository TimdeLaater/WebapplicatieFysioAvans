using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
namespace DomainModel.Models
{
    public class PatientModel : PersonModel, IValidatableObject

    {
        private DateTime minumAge = DateTime.Now.AddYears(-16);
        [Required(ErrorMessage = "Voer u telefoonnummer in")]
        [BindProperty, DataType(DataType.PhoneNumber)]
        public int PhoneNr { get; set; }
        [Required(ErrorMessage = "Voer u geboortedatum in")]
        [BindProperty, DataType(DataType.Date)]
        public string Date { get; set; }
        [Required(ErrorMessage = "Voer u Patientennummer in")]

        public int PatientNr { get; set; }
        [Required(ErrorMessage = "Voer u geslacht in")]

        public string Gender { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            DateTime current = Convert.ToDateTime(Date);
            if (current > minumAge)
            {
                yield return new ValidationResult("De patient is jonger dan 16 jaar en mag niet geregistreed worden", new[] { nameof(Date) });
            }
        }
    }
              
    
}
