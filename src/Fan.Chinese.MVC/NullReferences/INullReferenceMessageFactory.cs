using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan.Chinese.MVC.NullReferences
{
    public interface INullReferenceMessageFactory
    {
        INullReferenceMessage CreateNullReferenceMessage();
        INullReferenceMessage CreateNoTopicMessage(int topicId);
    }
}
