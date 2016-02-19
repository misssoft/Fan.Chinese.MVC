using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan.Chinese.MVC.NullReferences
{
    public class TopicNotFoundMessage: INullReferenceMessage
    {
        private readonly int topicId;
        public TopicNotFoundMessage(int id)
        {
            this.topicId = id;
        }
        public string ToDisplayMessage()
        {
            return $"Topic with Id of {topicId} does not exist";
        }
    }
}
