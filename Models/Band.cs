using System;
using System.Collections.Generic;

#nullable disable

namespace MusicBandsWebApp
{
    public partial class Band
    {
        public Band()
        {
            Albums = new HashSet<Album>();
            BandMusicians = new HashSet<BandMusician>();
        }

        public int BandId { get; set; }
        public string BandName { get; set; }
        public string Info { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<BandMusician> BandMusicians { get; set; }
    }
}
