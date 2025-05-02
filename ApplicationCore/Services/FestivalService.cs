using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using ApplicationCore.Domain;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Services
{
    public class FestivalService : Service<Festival>, IFestivalService
    {
        public FestivalService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
