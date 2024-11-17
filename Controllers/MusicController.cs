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

        [HttpGet]
        public IActionResult Explore()
        {
            var musicList = _musicService.GetAllMusic();
            return View(musicList);
        }

        [HttpGet]
        public IActionResult ChangeMusic()
        {
            var musicList = _musicService.GetAllMusic().ToList();
            return View(musicList);  // Passes the full list for the dropdown
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditOrDeleteMusic(int id, string action)
        {
            var music = _musicService.GetMusicById(id);
            if (music == null) return NotFound();

            if (action == "Edit")
            {
                return View("EditMusic", music);  // Render edit form
            }
            else if (action == "Delete")
            {
                _musicService.DeleteMusic(id);
                return RedirectToAction("ChangeMusic");  // Refresh after deletion
            }
            return RedirectToAction("ChangeMusic");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateMusic(Music music)
        {
            if (ModelState.IsValid)
            {
                _musicService.UpdateMusic(music);
                return RedirectToAction("ChangeMusic");
            }
            return View("EditMusic", music);
        }

        [HttpPost]
        public IActionResult DeleteMusic(int id)
        {
            _musicService.DeleteMusic(id);
            return RedirectToAction("Explore");
        }
    }
}
