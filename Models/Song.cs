using System;
using System.Collections.Generic;

#nullable disable

namespace MusicBandsWebApp
{
    public partial class Song
    {
        public Song()
        {
            AlbumSongs = new HashSet<AlbumSong>();
            PlaylistSongs = new HashSet<PlaylistSong>();
        }

        public int SongId { get; set; }
        public string SongTitle { get; set; }
        public string SongLength { get; set; }

        public virtual ICollection<AlbumSong> AlbumSongs { get; set; }
        public virtual ICollection<PlaylistSong> PlaylistSongs { get; set; }
    }
}
