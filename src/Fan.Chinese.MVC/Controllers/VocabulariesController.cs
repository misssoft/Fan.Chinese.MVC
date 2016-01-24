using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Fan.Chinese.MVC.Models;

namespace Fan.Chinese.MVC.Controllers
{
    public class VocabulariesController : Controller
    {
        private ApplicationDbContext _context;

        public VocabulariesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vocabularies
        public IActionResult Index()
        {
            return View(_context.Vocabulary
                .Include(v => v.TopicVocabularies)
                .ThenInclude(v => v.Topic).
                ToList().OrderBy(x => x.Pinyin));
        }

        // GET: Vocabularies/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Vocabulary vocabulary = null;

            vocabulary = _context.Vocabulary.Single(m => m.VocabularyId == id);
            if (vocabulary != null)
            {
                return View(vocabulary);
            }

            return HttpNotFound();
        }

        // GET: Vocabularies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vocabularies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vocabulary vocabulary)
        {
            if (ModelState.IsValid)
            {
                _context.Vocabulary.Add(vocabulary);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vocabulary);
        }

        // GET: Vocabularies/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Vocabulary vocabulary = _context.Vocabulary.Single(m => m.VocabularyId == id);
            if (vocabulary == null)
            {
                return HttpNotFound();
            }
            return View(vocabulary);
        }

        // POST: Vocabularies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Vocabulary vocabulary)
        {
            if (ModelState.IsValid)
            {
                _context.Update(vocabulary);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vocabulary);
        }

        // GET: Vocabularies/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Vocabulary vocabulary = _context.Vocabulary.Single(m => m.VocabularyId == id);
            if (vocabulary == null)
            {
                return HttpNotFound();
            }

            return View(vocabulary);
        }

        // POST: Vocabularies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Vocabulary vocabulary = _context.Vocabulary.Single(m => m.VocabularyId == id);
            _context.Vocabulary.Remove(vocabulary);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
