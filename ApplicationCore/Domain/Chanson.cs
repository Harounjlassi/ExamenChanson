using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain
{
    public class Chanson
    {
        public int ChansonId { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateSortie { get; set; }
        public int Duree { get; set; }
        public StyleMusic StyleMusic { get; set; }

       // [Range(3,12)]
        [MinLength(3)]
        [MaxLength(10)]
        public string Titre { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "le nombre doit être positif")]

        public int VuesYoutube { get; set; }
        public int ArtisteFk { get; set; }
        [ForeignKey("ArtisteFk")]

        public virtual Artiste Artiste { get; set; }

    }
}
