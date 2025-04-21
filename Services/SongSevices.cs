using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music.Exceptions;
using Music.Intefaces;
using Music.Models;

namespace Music.Services
{
    public class SongService : ISong
    {
        private readonly List<Song> _songs = new();
        private int _idCounter = 1;

        public void Create(Song song)
        {
            song.Id = _idCounter++;
            _songs.Add(song);
        }

        public List<Song> GetAll() => _songs;

        public Song GetById(int id) =>
            _songs.FirstOrDefault(s => s.Id == id) ?? throw new NotFoundException("Song tapilmadi");

        public void Update(Song song)
        {
            var existing = GetById(song.Id);
            existing.SongName = song.SongName;
            existing.ArtistNames = song.ArtistNames;
            existing.Genre = song.Genre;
            existing.Duration = song.Duration;
        }

        public void Delete(int id)
        {
            var song = GetById(id);
            _songs.Remove(song);
        }
    }
}
