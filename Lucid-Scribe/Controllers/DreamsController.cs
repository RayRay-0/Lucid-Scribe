
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lucid_Scribe.Services.DTOs;
using Lucid_Scribe.Services.Abstractions;

namespace Lucid_Scribe.Controllers
{
    public class DreamsController : Controller
    {
        private readonly IDreamService _dreamService;

        public DreamsController(IDreamService dreamService)
        {
            _dreamService = dreamService;
        }

        // GET: Dreams
        public async Task<IActionResult> Index()
        {
            return View(await _dreamService.GetAsync());
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

            return View(dream);
        }

        // GET: Dreams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dreams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DreamDTO dream)
        {
            if (ModelState.IsValid)
            {
                await _dreamService.AddAsync(dream);
                return RedirectToAction(nameof(Index));
            }
            return View(dream);
        }

        // GET: Emotions/Edit/5
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
            return View(dream);
        }

        // POST: Dreams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DreamDTO dream)
        {
            if (id != dream.Id)
            {
                return NotFound();
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

            return View(dream);
        }

        // POST: Dreams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _dreamService.DeleteByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> DreamExists(int id)
        {
            return (await _dreamService.GetByIdAsync(id)) != null;
        }
    }
}
