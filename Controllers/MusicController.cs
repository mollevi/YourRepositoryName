using Microsoft.AspNetCore.Mvc;
using ZeneApp.Models;
using ZeneApp.Services;

namespace ZeneApp.Controllers
{
    public class MusicController : Controller
    {
        private readonly IMusicService _musicService;

        public MusicController(IMusicService musicService)
        {
            _musicService = musicService;
        }

        [HttpGet]
        public IActionResult NewMusic()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateMusic(Music music)
        {
            if (ModelState.IsValid)
            {
                _musicService.AddMusic(music);
                return RedirectToAction("Explore");
            }
            return View("NewMusic", music);
        }
    }
}
