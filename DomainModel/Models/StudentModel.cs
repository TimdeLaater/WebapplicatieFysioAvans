using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
namespace DomainModel.Models
{
    public class StudentModel : TeacherModel
    {
        [Required(ErrorMessage = "Voer u Studentnummer in")]
        public int StudentNr { get; set; }
    }
}
