using System;
using System.Collections.Generic;

#nullable disable

namespace MusicBandsWebApp
{
    public partial class Album
    {
        public Album()
        {
            AlbumSongs = new HashSet<AlbumSong>();
        }

        public int AlbumId { get; set; }
        public string AlbumTitle { get; set; }
        public int AlbumYear { get; set; }
        public string AlbumGenre { get; set; }
        public int BandId { get; set; }

        public virtual Band Band { get; set; }
        public virtual ICollection<AlbumSong> AlbumSongs { get; set; }
    }
}
