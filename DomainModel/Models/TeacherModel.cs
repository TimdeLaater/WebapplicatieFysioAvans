using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace DomainModel.Models
{
    public class TeacherModel : PersonModel
    {
        [Required(ErrorMessage = "Voer u Personeelsnummer in")]
        public int PersonnelNr { get; set; }
    }
}
