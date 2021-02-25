using System;
using System.Collections.Generic;

#nullable disable

namespace MusicBandsWebApp
{
    public partial class Musician
    {
        public Musician()
        {
            BandMusicians = new HashSet<BandMusician>();
        }

        public int MusicianId { get; set; }
        public string Name { get; set; }
        public int? Year { get; set; }
        public string Role { get; set; }

        public virtual ICollection<BandMusician> BandMusicians { get; set; }
    }
}
