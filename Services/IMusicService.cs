using ZeneApp.Models;

namespace ZeneApp.Services
{
    public interface IMusicService
    {
        void AddMusic(Music music);
        IEnumerable<Music> GetAllMusic();
        Music GetMusicById(int id);
        void UpdateMusic(Music music);
        void DeleteMusic(int id);
    }
}