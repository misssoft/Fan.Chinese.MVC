using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan.Chinese.MVC.NullReferences
{
    public class NullReferenceMessageFactory: INullReferenceMessageFactory
    {
        public INullReferenceMessage CreateNullReferenceMessage()
        {
            return NullReferenceMessage.Instance;
        }

        public INullReferenceMessage CreateNoTopicMessage(int topicId)
        {
            return new TopicNotFoundMessage(topicId);
        }
    }
}
