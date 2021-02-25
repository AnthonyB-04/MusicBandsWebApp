using System;
using System.Collections.Generic;

#nullable disable

namespace MusicBandsWebApp
{
    public partial class BandMusician
    {
        public int BandId { get; set; }
        public int MusicianId { get; set; }

        public virtual Band Band { get; set; }
        public virtual Musician Musician { get; set; }
    }
}
