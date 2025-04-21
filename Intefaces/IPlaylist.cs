using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music.Models;

namespace Music.Intefaces
{
    public interface IPlaylist
    {
        void Create(Playlist playlist);
        List<Playlist> GetAll();
        Playlist GetById(int id);
        void Update(Playlist playlist);
        void Delete(int id);
        List<Song> FilterSongs(int playlistId, string? artist = null, string? songName = null, string? genre = null);
    }
}
