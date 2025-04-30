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
    public class ConcertService :  Service<Concert> ,IConcertService
    {
        public ConcertService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IList<Concert> GetConcertListByMusicalStyle(StyleMusic style)
        {
            return GetMany(p =>
                   p.Artiste.chansons.Any(ch => ch.StyleMusic == style)
               ).ToList();
        }

        public double plusHautCachet(Festival fs)
        {
           /** return GetAll()
    .Where(p => p.FestivalFk == fs.FestivalId && p.DateConcert.Year == DateTime.Now.Year)
    .OrderByDescending(p => p.Cachet)
    .Select(p => p.Cachet).FirstOrDefault();*/

            return GetAll()
    .Where(p => p.FestivalFk == fs.FestivalId && p.DateConcert.Year == DateTime.Now.Year)
    .Max(p => p.Cachet);

        }
    }
}
