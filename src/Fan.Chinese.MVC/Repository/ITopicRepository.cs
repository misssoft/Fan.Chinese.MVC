using System.Collections.Generic;
using Fan.Chinese.MVC.Models;

namespace Fan.Chinese.MVC.Repository
{
    public interface ITopicRepository
    {
        IEnumerable<Topic> GetAllTopicsWithVocabularies();

        IEnumerable<Topic> GetAllTopic();

        Topic GetTopic(int id);

        void AddTopic(Topic topic);

        void UpdateTopic(Topic topic);

        void DeleteTopic(int id);

    }
}