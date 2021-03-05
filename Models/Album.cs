using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "The field should not be empty")]
        [Display(Name = "Title")]
        public string AlbumTitle { get; set; }
        [Required(ErrorMessage = "The field should not be empty")]
        [Display(Name = "Year")]
        public int AlbumYear { get; set; }
        [Required(ErrorMessage = "The field should not be empty")]
        [Display(Name = "Genre")]
        public string AlbumGenre { get; set; }
        public int BandId { get; set; }

        public virtual Band Band { get; set; }
        public virtual ICollection<AlbumSong> AlbumSongs { get; set; }
    }
}
