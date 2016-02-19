using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Fan.Chinese.MVC.Models;
using Fan.Chinese.MVC.NullReferences;
using Fan.Chinese.MVC.Repository;
using Microsoft.Extensions.Logging;

namespace Fan.Chinese.MVC.Controllers
{
    public class VocabulariesController : Controller
    {
        private readonly IVocabularyRepository _repository;
        private readonly ILogger _logger;

        public VocabulariesController(IVocabularyRepository repository, ILoggerFactory loggerFactory)
        {
            _repository = repository;
            _logger = loggerFactory.CreateLogger<VocabulariesController>();
        }

        // GET: Vocabularies
        public IActionResult Index()
        {
            var vocabularies = _repository.GetAllVocabulariesWithTopics();
            return View(vocabularies);
        }

        // GET: Vocabularies/Details/5
        public IActionResult Details(int id)
        {
            Vocabulary vocabulary;
            try
            {
                vocabulary = _repository.GetVocabulary(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                var message = new VocabularyNotFoundMessage(id);
                return RedirectToAction("ErrorPage", "Home", new { message = message.ToDisplayMessage() });
            }
            return View(vocabulary);
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
                _repository.AddVocabulary(vocabulary);
                return RedirectToAction("Index");
            }
            return View(vocabulary);
        }

        // GET: Vocabularies/Edit/5
        public IActionResult Edit(int id)
        {  
            Vocabulary vocabulary;
            try
            {
                vocabulary = _repository.GetVocabulary(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                var message = new VocabularyNotFoundMessage(id);
                return RedirectToAction("ErrorPage", "Home", new { message = message.ToDisplayMessage() });
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
                _repository.UpdateVocabulary(vocabulary);
                return RedirectToAction("Index");
            }
            return View(vocabulary);
        }

        // GET: Vocabularies/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            Vocabulary vocabulary;
            try
            {
                vocabulary = _repository.GetVocabulary(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                var message = new VocabularyNotFoundMessage(id);
                return RedirectToAction("ErrorPage", "Home", new { message = message.ToDisplayMessage() });
            }
            return View(vocabulary);
        }

        // POST: Vocabularies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.DeleteVocabulary(id);
            return RedirectToAction("Index");
        }
    }
}
