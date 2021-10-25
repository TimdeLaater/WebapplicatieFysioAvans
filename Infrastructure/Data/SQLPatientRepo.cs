using DomainModel.Models;
using DomainServices;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
   public class SQLPatientRepo : IPatientRepo
        
    {
        FysioDBContext _dbContext = new();

        public SQLPatientRepo(FysioDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public SQLPatientRepo()
        {

        }
        public void Create(PatientModel entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

        public List<PatientModel> Get()
        {
            return _dbContext.Patient
                .Include(patient => patient.PatientDossier)
                    .ThenInclude(patient => patient.Treatments)
                        .ThenInclude(treatment => treatment.TreatmentBy)
                .Include(patient => patient.PatientDossier.Comments)
                                .Include(patient => patient.PatientDossier.Therapist)
                                                .Include(patient => patient.PatientDossier.IntakeDoneBy)
                     .Include(patient => patient.PatientDossier.IntakeSupervision)
                    .Include(patient => patient.PatientDossier.TreatmentPlan)
                      .ToList();

        }

        public PatientModel Get(string Email)
        {
            var patient = _dbContext.Patient.Where(x => x.Email == Email)
        .Include(patient => patient.PatientDossier)
                    .ThenInclude(patient => patient.Treatments)
                        .ThenInclude(treatment => treatment.TreatmentBy)
                .Include(patient => patient.PatientDossier.Comments)
                      .Include(patient => patient.PatientDossier.Therapist)
                      .Include(patient => patient.PatientDossier.IntakeDoneBy)
                     .Include(patient => patient.PatientDossier.IntakeSupervision)
                    .Include(patient => patient.PatientDossier.TreatmentPlan)
                    .First();
            return patient;

        }
       

        public PatientModel Get(PatientModel entity)
        {
            return _dbContext.Patient.Find(entity.Email);
        }

      

        public void Update(PatientModel entity, string email)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }

        public void Remove(string email)
        {
            _dbContext.Remove(_dbContext.Patient.Find(email));
            _dbContext.SaveChanges();
        }

        public void UpdatePatientDossier(PatientModel entity, string email)
        {
            PatientModel patient = Get(email);
            patient.PatientDossier = entity.PatientDossier;
            _dbContext.Update(patient);
            _dbContext.SaveChanges();
        }
    }
}
