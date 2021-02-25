using System;
using System.Collections.Generic;

#nullable disable

namespace MusicBandsWebApp
{
    public partial class Playlist
    {
        public Playlist()
        {
            PlaylistSongs = new HashSet<PlaylistSong>();
        }

        public int PlaylistId { get; set; }
        public string PlaylistTitle { get; set; }

        public virtual ICollection<PlaylistSong> PlaylistSongs { get; set; }
    }
}
