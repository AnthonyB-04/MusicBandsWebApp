using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage ="The field should not be empty")]
        [Display(Name = "Artist")]
        public string BandName { get; set; }
        [Display(Name = "Biography")]
        public string Info { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<BandMusician> BandMusicians { get; set; }
    }
}
