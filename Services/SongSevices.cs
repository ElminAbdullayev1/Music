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
       public class SongService
    {
        private static List<Song> Songs { get; } = new List<Song>();
        public void Create(Song song)
        {
            if (song is null)
            {
                throw new NotFoundException("Mahni tapilmadi");
            }
            song.Id = Songs.Count + 1;
            Songs.Add(song);
            Console.WriteLine("Mahni elave edildi");
        }
        public List<Song> GetAll()
        {
            if (Songs.Count == 0)
            {
                throw new NotFoundException("Mahni tapilmadi");
            }
            return Songs;
        }
        public void Delete(int id)
        {
            var song = Songs.FirstOrDefault(s => s.Id == id);
            if (song != null)
            {
                Songs.Remove(song);
                Console.WriteLine("Mahni silindi");
                return;
            }
            throw new NotFoundException("Mahni tapilmadi");
        }

        internal object GetById(int sid)
        {
            throw new NotImplementedException();
        }
    }
}
