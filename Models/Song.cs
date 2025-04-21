using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Music.Enum.EnumGenre;

namespace Music.Models
{
    public class Song
    {
            public int Id { get; set; }
            public string SongName { get; set; }
            public List<string> ArtistNames { get; set; }
            public GenreEnum Genre { get; set; }
            public int Duration { get; set; } 
    }
}
