
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lucid_Scribe.Services.DTOs;
using Lucid_Scribe.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Lucid_Scribe.Data.Entities;
using System.IO;

namespace Lucid_Scribe.Controllers
{
    [Authorize]
    public class DreamsController : Controller
    {
        private readonly IDreamService _dreamService;
        private readonly IEmotionService _emotionService;
        private readonly UserManager<AppUser> _userManager;

        public DreamsController(IDreamService dreamService, IEmotionService emotionService, UserManager<AppUser> userManager)
        {
            _dreamService = dreamService;
            _emotionService = emotionService;
            _userManager = userManager;
        }

        // GET: Dreams
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("ADMIN"))
            {
                return View(await _dreamService.GetAsync());
            }
            else
            {
                return View(await _dreamService.GetByUserAsync((await _userManager.GetUserAsync(User)).Id));
            }
        }

        // GET: Dreams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dream = await _dreamService.GetByIdAsync(id.Value);
            if (dream == null)
            {
                return NotFound();
            }

            var currentUserId = (await _userManager.GetUserAsync(User)).Id;
            if(dream.UserId != currentUserId && !User.IsInRole("ADMIN"))
            {
                return Unauthorized();
            }

            return View(dream);
        }

        // GET: Dreams/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Emotions = await _emotionService.GetAsync();
            DreamCreateDTO model = new DreamCreateDTO();
            model.UserId = (await _userManager.GetUserAsync(User)).Id;
            return View(model);
        }

        // POST: Dreams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DreamCreateDTO dream)
        {                
            if (ModelState.IsValid)
            {
                await _dreamService.AddAsync(dream);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Emotions = await _emotionService.GetAsync();

            return View(dream);
        }

        // GET: Dreams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dream = await _dreamService.GetByIdAsync(id.Value);
            if (dream == null)
            {
                return NotFound();
            }

            var currentUserId = (await _userManager.GetUserAsync(User)).Id;
            if (dream.UserId != currentUserId && !User.IsInRole("ADMIN"))
            {
                return Unauthorized();
            }

            ViewBag.Emotions = await _emotionService.GetAsync();
            var model = new DreamEditDTO(dream);
            model.EmotionsIds = dream.Emotions.Select(item => item.Id).ToList();
            return View(model);
        }

        // POST: Dreams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DreamEditDTO dream)
        {
            if (id != dream.Id)
            {
                return NotFound();
            }

            if (dream == null)
            {
                return NotFound();
            }

            var currentUserId = (await _userManager.GetUserAsync(User)).Id;
            if (dream.UserId != currentUserId && !User.IsInRole("ADMIN"))
            {
                return Unauthorized();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _dreamService.UpdateAsync(dream);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await DreamExists(dream.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dream);
        }

        // GET: Dreams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dream = await _dreamService.GetByIdAsync(id.Value);
            if (dream == null)
            {
                return NotFound();
            }

            var currentUserId = (await _userManager.GetUserAsync(User)).Id;
            if (dream.UserId != currentUserId && !User.IsInRole("ADMIN"))
            {
                return Unauthorized();
            }

            return View(dream);
        }

        // POST: Dreams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dream = await _dreamService.GetByIdAsync(id);
            if (dream == null)
            {
                return NotFound();
            }

            var currentUserId = (await _userManager.GetUserAsync(User)).Id;
            if (dream.UserId != currentUserId && !User.IsInRole("ADMIN"))
            {
                return Unauthorized();
            }

            await _dreamService.DeleteByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> DreamExists(int id)
        {
            return (await _dreamService.GetByIdAsync(id)) != null;
        }
    }
}
