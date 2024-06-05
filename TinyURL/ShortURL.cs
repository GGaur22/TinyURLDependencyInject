using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyURL
{
    internal class ShortURL : IShortURL
    {
        private string _shortURL;
        private int _counter;
        private int _counter2;

        public string shortURL { get { return _shortURL; } set { _shortURL = value; } }
        public int counter { get { return _counter; } set { _counter = value; } }
        public int counter2 { get { return _counter2; } set { _counter2 = value; } }


    }
}
