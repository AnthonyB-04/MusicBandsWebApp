using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MusicBandsWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartsController : ControllerBase
    {
        private readonly DBMusicBandsContext _context;

        public ChartsController(DBMusicBandsContext context)
        {
            _context = context;
        }

        [HttpGet("JsonData")]
        public JsonResult JsonData()
        {
            var bands = _context.Bands.Include(a => a.Albums).ToList();

            List<object> albumBand = new List<object>();

            albumBand.Add(new[] { "Artist", "Quantity of Albums" });

            foreach (var b in bands)
            {
                albumBand.Add(new object[] { b.BandName, b.Albums.Count() });
            }

            return new JsonResult(albumBand);
        }
    }
}
