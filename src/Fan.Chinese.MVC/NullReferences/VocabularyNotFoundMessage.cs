using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan.Chinese.MVC.NullReferences
{
    public class VocabularyNotFoundMessage: INullReferenceMessage
    {
        private readonly int vocabularyId;

        public VocabularyNotFoundMessage(int id)
        {
            vocabularyId = id;
        }
        public string ToDisplayMessage()
        {
            return $"Vocabulary with Id of {vocabularyId} does not exist";
        }
    }
}
