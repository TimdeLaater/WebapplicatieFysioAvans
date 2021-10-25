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
        public int Id { get; set; }
        public string IssueDiscription { get; set; }

        public string DiaCodeAndDiscription { set; get; }
        public PersonModel IntakeDoneBy { get; set; }
        public PersonModel IntakeSupervision { get; set; }
        public PersonModel Therapist { get; set; }
        [BindProperty, DataType(DataType.Date)]
        public string RegistrationDate { get; set; }
        [BindProperty, DataType(DataType.Date)]
        public string EndDate { get; set; }
        public  List<CommentModel>Comments { get; set; }
        public TreatmentPlanModel TreatmentPlan { get; set; }
        public List<TreatmentModel> Treatments { get; set; }


    }
}
