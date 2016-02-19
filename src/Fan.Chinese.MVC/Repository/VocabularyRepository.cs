using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fan.Chinese.MVC.Models;
using Microsoft.Data.Entity;

namespace Fan.Chinese.MVC.Repository
{
    public class VocabularyRepository : IVocabularyRepository
    {
        private readonly ApplicationDbContext _context;
        public VocabularyRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Vocabulary> GetAllVocabulariesWithTopics()
        {
            return _context.Vocabulary
                .Include(v => v.TopicVocabularies)
                .ThenInclude(v => v.Topic).
                ToList().OrderBy(x => x.Pinyin);
        }

        public IEnumerable<Vocabulary> GetAllVocuVocabularies()
        {
            return _context.Vocabulary.ToList();
        }

        public Vocabulary GetVocabulary(int id)
        {
            return _context.Vocabulary.First(v => v.VocabularyId == id);
        }

        public void AddVocabulary(Vocabulary vocabulary)
        {
            _context.Vocabulary.Add(vocabulary);
            _context.SaveChanges();

        }

        public void UpdateVocabulary(Vocabulary vocabulary)
        {
            _context.Vocabulary.Update(vocabulary);
            _context.SaveChanges();
        }

        public void DeleteVocabulary(int id)
        {
            var vocabulary = _context.Vocabulary.First(v => v.VocabularyId == id);
            _context.Vocabulary.Remove(vocabulary);
            _context.SaveChanges();
        }
    }
}
