using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lucid_Scribe.Data;
using Lucid_Scribe.Data.Entities;
using Lucid_Scribe.Services.DTOs;
using Lucid_Scribe.Services.Abstractions;

namespace Lucid_Scribe.Controllers
{
    public class EmotionsController : Controller
    {
        private readonly IEmotionService _emotionService;

        public EmotionsController(IEmotionService emotionService)
        {
            _emotionService = emotionService;
        }

        // GET: Emotions
        public async Task<IActionResult> Index()
        {
            return View(await _emotionService.GetAsync());
        }

        // GET: Emotions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emotion = await _emotionService.GetByIdAsync(id.Value);
            if (emotion == null)
            {
                return NotFound();
            }

            return View(emotion);
        }

        // GET: Emotions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Emotions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmotionDTO emotion)
        {
            if (ModelState.IsValid)
            {
                await _emotionService.AddAsync(emotion);
                return RedirectToAction(nameof(Index));
            }
            return View(emotion);
        }

        // GET: Emotions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emotion = await _emotionService.GetByIdAsync(id.Value);
            if (emotion == null)
            {
                return NotFound();
            }
            return View(emotion);
        }

        // POST: Emotions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmotionDTO emotion)
        {
            if (id != emotion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _emotionService.UpdateAsync(emotion);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await EmotionExists(emotion.Id))
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
            return View(emotion);
        }

        // GET: Emotions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emotion = await _emotionService.GetByIdAsync(id.Value);
            if (emotion == null)
            {
                return NotFound();
            }

            return View(emotion);
        }

        // POST: Emotions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _emotionService.DeleteByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> EmotionExists(int id)
        {
          return (await _emotionService.GetByIdAsync(id)) != null;
        }
    }
}
