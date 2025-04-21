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
    public class PlaylistService : IPlaylist
    {
        private List<Playlist> _playlists = new();
        private int _idCounter = 1;

        public void Create(Playlist playlist)
        {
            playlist.Id = _idCounter++;
            _playlists.Add(playlist);
        }

        public List<Playlist> GetAll()
        {
            return _playlists;
        }

        public Playlist GetById(int id)
        {
            var playlist = _playlists.FirstOrDefault(p => p.Id == id);
            if (playlist == null)
                throw new NotFoundException("Playlist tapılmadı");
            return playlist;
        }

        public void Update(Playlist playlist)
        {
            var existing = GetById(playlist.Id);
            existing.PlaylistName = playlist.PlaylistName;
            existing.Songs = playlist.Songs;
        }

        public void Delete(int id)
        {
            var playlist = GetById(id);
            _playlists.Remove(playlist);
        }

        // Filter sadə dildə yazılıb
        public List<Song> FilterSongs(int playlistId, string? artist = null, string? songName = null, string? genre = null)
        {
            var playlist = GetById(playlistId);
            var result = playlist.Songs;

            if (!string.IsNullOrEmpty(artist))
            {
                result = result
                    .Where(s => s.ArtistNames.Any(a => a.ToLower().Contains(artist.ToLower())))
                    .ToList();
            }

            if (!string.IsNullOrEmpty(songName))
            {
                result = result
                    .Where(s => s.SongName.ToLower().Contains(songName.ToLower()))
                    .ToList();
            }

            if (!string.IsNullOrEmpty(genre))
            {
                result = result
                    .Where(s => s.Genre.ToString().ToLower() == genre.ToLower())
                    .ToList();
            }

            return result;
        }
    }
}
