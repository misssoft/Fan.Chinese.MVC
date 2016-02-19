using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Fan.Chinese.MVC.Models;
using Fan.Chinese.MVC.NullReferences;
using Fan.Chinese.MVC.Repository;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Extensions.Logging;

namespace Fan.Chinese.MVC.Controllers
{
    public class TopicsController : Controller
    {
        private readonly ITopicRepository _repository;
        private readonly ILogger _logger;

        public TopicsController(ITopicRepository repository, ILoggerFactory loggerFactory)
        {
            _repository = repository;
            _logger = loggerFactory.CreateLogger<TopicsController>();
        }

        // GET: Topics
        public IActionResult Index()
        {
            var topics = _repository.GetAllTopicsWithVocabularies();
            return View(topics);
        }

        // GET: Topics/Details/5
        public IActionResult Details(int id)
        {
            var message = new TopicNotFoundMessage(id);
            Topic topic;
            try
            {
                topic = _repository.GetTopic(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return RedirectToAction("ErrorPage", "Home", new { message = message.ToDisplayMessage() });
            }
            return View(topic);
        }

        // GET: Topics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Topics/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Topic topic)
        {
            if (ModelState.IsValid)
            {
                _repository.AddTopic(topic);
                return RedirectToAction("Index");
            }
            return View(topic);
        }

        // GET: Topics/Edit/5
        public IActionResult Edit(int id)
        {
            var message = new TopicNotFoundMessage(id);
            Topic topic;
            try
            {
                topic = _repository.GetTopic(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return RedirectToAction("ErrorPage", "Home", new { message = message.ToDisplayMessage() });
            }
            return View(topic);
        }

        // POST: Topics/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Topic topic)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateTopic(topic);
                return RedirectToAction("Index");
            }
            return View(topic);
        }

        // GET: Topics/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            var message = new TopicNotFoundMessage(id);
            Topic topic;
            try
            {
                topic = _repository.GetTopic(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return RedirectToAction("ErrorPage", "Home", new { message = message.ToDisplayMessage() });
            }
            return View(topic);

            return View(topic);
        }

        // POST: Topics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.DeleteTopic(id);
            return RedirectToAction("Index");
        }
    }
}
