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
    public class ServiceChanson : Service<Chanson>, IServiceChanson
    {
        public ServiceChanson(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
