using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan.Chinese.MVC.Models
{
    public class TopicVocabulary
    {
        public int TopicId { get; set; }
        public Topic Topic { get; set; }

        public int VocabularyId { get; set; }
        public Vocabulary Vocabulary { get; set; }
    }
}
