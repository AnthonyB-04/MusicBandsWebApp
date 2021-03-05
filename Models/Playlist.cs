using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "The field should not be empty")]
        [Display(Name = "Title")]
        public string PlaylistTitle { get; set; }

        public virtual ICollection<PlaylistSong> PlaylistSongs { get; set; }
    }
}
