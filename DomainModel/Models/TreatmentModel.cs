using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class TreatmentModel
    {
        public int Id { get; set; }
        public int VektisType { get; set; }
        [Required, MaxLength(255)]
        public string Description { get; set; }
        // true is treatment, false is training.
        public bool TreatmentOrTrainingRoom { get; set; }
        [Required]
        public string Complications { get; set; }
        public PersonModel TreatmentBy { get; set; }
        [Required]
        public DateTime TreatmentTime { get; set; }
        public DateTime TreatmentEnd { get; set; }
    }
}
