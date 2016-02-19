using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace Fan.Chinese.MVC.NullReferences
{
    public interface INullReferenceMessage
    {
        string ToDisplayMessage();
    }
}
