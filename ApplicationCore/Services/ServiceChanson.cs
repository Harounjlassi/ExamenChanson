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

        public IList<Chanson> GetFiveChanson(Artiste ar)
        {
            return GetMany(c => c.ArtisteFk == ar.ArtisteId).OrderByDescending(c => c.VuesYoutube)
                .Where(c => c.DateSortie.Year + 2 >= DateTime.Now.Year).Take(5).ToList();
            
        }

        public void GetMusicalStyle(StyleMusic st)
        {
            var req = GetMany(c => c.StyleMusic == st).Select(c => c.Artiste).SelectMany(a => a.concerts);
            foreach (var item in req)
                Console.WriteLine("Date: " + item.DateConcert + "Ville: " + item.Festival.Ville+ "  Cachet: " + item.Cachet);
        }

        public void GetMusicalStyledebug(StyleMusic st)
        {
            var req = GetMany(c => c.StyleMusic == st);
            foreach (var item in req)
                Console.WriteLine("ch StyleMusic : " + item.StyleMusic + "Cachet: " + item.VuesYoutube );
        }
    }
}
