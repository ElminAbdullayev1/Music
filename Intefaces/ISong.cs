using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music.Models;

namespace Music.Intefaces
{
    public interface ISong
    {
        void Create(Song song);
        List<Song> GetAll();
        Song GetById(int id);
        void Update(Song song);
        void Delete(int id);
    }
}
