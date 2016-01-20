using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fan.Chinese.MVC.Models;
using Microsoft.Data.Entity;

namespace Fan.Chinese.MVC.Repository
{
    public class TopicRepository: ITopicRepository
    {
        private readonly ApplicationDbContext _context;
        public TopicRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Topic> GetAllTopicsWithVocabularies()
        {
            return _context.Topic
               .Include(t => t.TopicVocabularies)
               .ThenInclude(t => t.Vocabulary)
               .ToList().OrderBy(t => t.TopicCategory);
        }

        public IEnumerable<Topic> GetAllTopic()
        {
            return _context.Topic
              .ToList().OrderBy(t => t.TopicCategory);
        }

        public Topic GetTopic(int id)
        {
            var topic = _context.Topic
                .Include(v => v.TopicVocabularies)
                .ThenInclude(t => t.Vocabulary)
                .Single(m => m.TopicId == id);
            return topic;
        }

        public void AddTopic(Topic topic)
        {
            _context.Topic.Add(topic);
            _context.SaveChanges();
        }

        public void UpdateTopic(Topic topic)
        {
            _context.Update(topic);
            _context.SaveChanges();
        }

        public void DeleteTopic(int id)
        {
            var topic =_context.Topic.Single(m => m.TopicId == id);
            _context.Topic.Remove(topic);
            _context.SaveChanges();
        }
    }
}
