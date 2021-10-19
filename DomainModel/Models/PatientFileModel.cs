using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;

namespace DomainModel.Models
{
    public class PatientFileModel
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public PatientModel Patient { get; set; }

        public int Age { get; set; }
        //TODO: moet uitgerekend worden
        public string IssueDiscription { get; set; }

        public string DiaCodeAndDiscription { set; get; }
        public PersonModel IntakeDoneBy { get; set; }
        public PersonModel? IntakeSupervision { get; set; }
        public TherapistModel therapist { get; set; }
        [BindProperty, DataType(DataType.Date)]
        public string RegistrationDate { get; set; }
        [BindProperty, DataType(DataType.Date)]
        public string? EndDate { get; set; }
        public string? Comments { get; set; }
        // Treatment plan
        public TreatmentPlanModel TreatmentPlan { get; set; }
        public List<TreatmentModel> Treatments { get; set; }


    }
}
