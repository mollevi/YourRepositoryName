using Microsoft.AspNetCore.Components.Web;
using ZeneApp.Data;
using ZeneApp.Models;

namespace ZeneApp.Services
{
    public class MusicService : IMusicService
    {
        private readonly ApplicationDbContext _context;

        public MusicService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddMusic(Music music)
        {
            _context.MusicLibrary.Add(music);
            _context.SaveChanges();
        }

        public IEnumerable<Music> GetAllMusic()
        {
            return _context.MusicLibrary
                .OrderByDescending(m => m.Priority)
                .ToList();
        }

        public Music GetMusicById(int id)
        {
            /*Music music = _context.MusicLibrary.Find(id) ?? new Music();
            if(music == null){
                return new Music();
            }*/
            return _context.MusicLibrary.Find(id) ?? new Music();
        }

        public void UpdateMusic(Music music)
        {
            _context.MusicLibrary.Update(music);
            _context.SaveChanges();
        }

        public void DeleteMusic(int id)
        {
            var music = _context.MusicLibrary.Find(id);
            if (music != null)
            {
                _context.MusicLibrary.Remove(music);
                _context.SaveChanges();
            }
        }
    }
}