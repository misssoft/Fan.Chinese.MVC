using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fan.Chinese.MVC.Models
{
    public class Topic
    {
        [ScaffoldColumn(false)]
        public int TopicId { get; set; }

        [Required]
        [Display(Name = "Topic Name")]
        public string TopicName { get; set; }


        [Display(Name = "Topic Category")]
        public string TopicCategory { get; set; }

        [Display(Name = "Topic Vocabulary")]
        public virtual ICollection<TopicVocabulary> TopicVocabularies { get; set; }

    }
}
