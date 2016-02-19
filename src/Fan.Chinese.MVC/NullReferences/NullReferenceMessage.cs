using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan.Chinese.MVC.NullReferences
{
    public class NullReferenceMessage: INullReferenceMessage
    {
        private static NullReferenceMessage instance;
        private NullReferenceMessage()
        {
        }

        public static NullReferenceMessage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NullReferenceMessage();
                }
                return instance;
            }
        }


        public string ToDisplayMessage()
        {
            return "Item not found.";
        }
    }
}
