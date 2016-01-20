using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fan.Chinese.MVC.Models
{
    public class Vocabulary
    {
        [ScaffoldColumn(false)]
        public int VocabularyId { get; set; }

        public string Chinese { get; set; }

        public string Pinyin { get; set; }

        public string English { get; set; }

        public string Example { get; set; }

        [Display(Name="Example Pinyin")]
        public string ExamplePinyin { get; set; }

        public ICollection<TopicVocabulary> TopicVocabularies { get; set; } 
    }
}
