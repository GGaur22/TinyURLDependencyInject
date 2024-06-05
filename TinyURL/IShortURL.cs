using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyURL
{
    public interface IShortURL
    {
        string shortURL { get; set; }
        int counter { get; set; }

    }
}
