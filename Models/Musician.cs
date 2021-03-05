using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MusicBandsWebApp
{
    public partial class Musician
    {
        public Musician()
        {
            BandMusicians = new HashSet<BandMusician>();
        }

        public int MusicianId { get; set; }
        [Required(ErrorMessage = "The field should not be empty")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Year")]
        public int? Year { get; set; }
        [Required(ErrorMessage = "The field should not be empty")]
        [Display(Name = "Role")]
        public string Role { get; set; }

        public virtual ICollection<BandMusician> BandMusicians { get; set; }
    }
}
