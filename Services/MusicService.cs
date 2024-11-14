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
    }
}