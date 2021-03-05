using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "The field should not be empty")]
        [Display(Name = "Title")]
        public string SongTitle { get; set; }
        [Required(ErrorMessage = "The field should not be empty")]
        [Display(Name = "Length")]
        public string SongLength { get; set; }

        public virtual ICollection<AlbumSong> AlbumSongs { get; set; }
        public virtual ICollection<PlaylistSong> PlaylistSongs { get; set; }
    }
}
