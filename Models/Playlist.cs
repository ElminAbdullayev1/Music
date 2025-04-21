using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public string PlaylistName { get; set; }
        public List<Song> Songs { get; set; } = new List<Song>();
    }
}
