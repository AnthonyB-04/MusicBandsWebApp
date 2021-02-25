using System;
using System.Collections.Generic;

#nullable disable

namespace MusicBandsWebApp
{
    public partial class PlaylistSong
    {
        public int SongId { get; set; }
        public int PlaylistId { get; set; }
        public int SongInPlaylist { get; set; }

        public virtual Playlist Playlist { get; set; }
        public virtual Song Song { get; set; }
    }
}
