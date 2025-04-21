using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music.Exceptions;
using Music.Intefaces;
using Music.Models;
using static Music.Enum.EnumGenre;

namespace Music.Services
{
       public class PlaylistService
    {
        private static List<Playlist> Playlists { get; } = [];
        public void Create(Playlist playlist)
        {
            if(playlist is null)
            {
                throw new NotFoundException("Playlist tapilmadi");
            }
            playlist.Id = Playlists.Count + 1;
            Playlists.Add(playlist);
            Console.WriteLine("Playlist elave edildi");
        }
        public void AddSong(int playlistId, Song song)
        {
            if(song is null)
            {
                throw new NotFoundException("Mahni tapilmadi");
            }
            foreach(var playlist in Playlists)
            {
                if (playlist.Id == playlistId)
                {
                    playlist.Songs.Add(song);
                    Console.WriteLine("Mahni elave edildi");
                    return;
                }
            }
            throw new NotFoundException("Playlist tapilmadi");
        }
        public List<Playlist> GetAllPlaylists()
        {
            if (Playlists.Count == 0)
            {
                throw new NotFoundException("Playlist tapilmadi");
            }
            return Playlists;
        }
        public void DeleteSong(int playlistId, int songId)
        {
            foreach (var playlist in Playlists)
            {
                if (playlist.Id == playlistId)
                {
                    var song = playlist.Songs.FirstOrDefault(s => s.Id == songId);
                    if (song != null)
                    {
                        playlist.Songs.Remove(song);
                        Console.WriteLine("Mahni silindi");
                        return;
                    }
                }
            }
            throw new NotFoundException("Mahni tapilmadi");
        }
        public void DeletePlaylist(int playlistId)
        {
            foreach (var playlist in Playlists)
            {
                if (playlist.Id == playlistId)
                {
                    Playlists.Remove(playlist);
                    Console.WriteLine("Playlist silindi");
                    return;
                }
            }
            throw new NotFoundException("Playlist tapilmadi");
        }
        public List<Playlist> GetPlaylists()
        {
            if (Playlists.Count == 0)
            {
                throw new NotFoundException("Playlist tapilmadi");
            }
            return Playlists;
        }
        public Playlist GetPlaylistById(int id)
        {
            foreach (var playlist in Playlists)
            {
                if (playlist.Id == id)
                {
                    return playlist;
                }
            }
            throw new NotFoundException("Playlist tapilmadi");
        }
        public void Update(Playlist playlist)
        {
            foreach (var p in Playlists)
            {
                if (p.Id == playlist.Id)
                {
                    p.PlaylistName = playlist.PlaylistName;
                    Console.WriteLine("Playlist yenilendi");
                    return;
                }
            }
            throw new NotFoundException("Playlist tapilmadi");
        }
        public List<Song> FilterSongs(int playlistId, string? artist = null, string? songName = null, string? genre = null)
        {
            var playlist = GetPlaylistById(playlistId);
            var filteredSongs = playlist.Songs.AsQueryable();
            if (!string.IsNullOrEmpty(artist))
            {
                filteredSongs = filteredSongs.Where(s => s.ArtistNames.Contains(artist));
            }
            if (!string.IsNullOrEmpty(songName))
            {
                filteredSongs = filteredSongs.Where(s => s.SongName.Contains(songName));
            }
            if (!string.IsNullOrEmpty(genre))
            {
                filteredSongs = filteredSongs.Where(s => s.Genre.ToString().Equals(genre, StringComparison.OrdinalIgnoreCase));
            }
            return filteredSongs.ToList();
        }

        internal object GetById(int pid)
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<object> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
