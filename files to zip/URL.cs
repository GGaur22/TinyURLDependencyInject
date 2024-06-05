using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyURL;

namespace TinyURLConversion
{
    public class URL
    {
        private string _longURL;
        private Dictionary<string, int> _shortURL;

        public string LongURL => _longURL;
        public Dictionary<string, int> ShortURL => _shortURL;

        public URL(string lURL, string sURL )
        {
            _longURL = lURL;
            if (_shortURL == null)
            {
                _shortURL = new Dictionary<string, int>();
            }
            _shortURL.Add( sURL, 0 );
        }


        public string? getShortURLs()
        {
            string? shortURLs = null;
            foreach (string key in _shortURL.Keys)
            {
                shortURLs = shortURLs != null  ?  shortURLs + ", " + key : key;
      
            }
       
            return shortURLs;
        }

        public bool SaveShortURL(string URL)
        {

            _shortURL.Add(URL, 0);
            return true;
        }

        public bool DeleteShortURL(string delURL)
        {
            return _shortURL.Remove(delURL);

        }

    }
}

