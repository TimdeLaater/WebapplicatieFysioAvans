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
    class SQLPatientRepo : IRepo<PatientModel>
        
    {
        FysioDBContext _dbContext = new();
        public SQLPatientRepo(FysioDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(PatientModel entity)
        {
            throw new NotImplementedException();
        }

        public List<PatientModel> Get()
        {
            throw new NotImplementedException();
        }

        public PatientModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public PatientModel Get(PatientModel entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(PatientModel entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
