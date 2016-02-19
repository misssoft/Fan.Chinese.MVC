using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fan.Chinese.MVC.Models;

namespace Fan.Chinese.MVC.Repository
{
    public interface IVocabularyRepository
    {
        IEnumerable<Vocabulary> GetAllVocabulariesWithTopics();

        IEnumerable<Vocabulary> GetAllVocuVocabularies();

        Vocabulary GetVocabulary(int id);

        void AddVocabulary(Vocabulary vocabulary);

        void UpdateVocabulary(Vocabulary vocabulary);

        void DeleteVocabulary(int id);

    }
}
