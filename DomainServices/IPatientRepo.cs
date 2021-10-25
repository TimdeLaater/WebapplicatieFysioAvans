using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainServices
{
    public interface IPatientRepo: IRepo<PatientModel>
    {
        
        public PatientModel Get(string email);
        public void Remove(string email);
        public void Update(PatientModel entity, string email);
        public void UpdatePatientDossier(PatientModel entity, string email);
    }
}
