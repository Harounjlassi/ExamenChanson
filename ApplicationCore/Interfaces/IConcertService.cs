using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Interfaces;
using ApplicationCore.Domain;

namespace ApplicationCore.Interfaces
{
    public interface IConcertService: IService<Concert>
    {
        double plusHautCachet(Festival fs);

        IList<Concert> GetConcertListByMusicalStyle(StyleMusic st);
    }
}
