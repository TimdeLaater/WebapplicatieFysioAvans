using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DomainServices
{
    public interface ITherapistRepo : IRepo<TherapistModel>
    {
        public List<SelectListItem> GetTherapists();
    }
}
