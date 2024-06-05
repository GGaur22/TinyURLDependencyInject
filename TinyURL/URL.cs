using System.Text;
using TinyURL;

namespace TinyURLConversion
{
    public class URL
    {
        private string _longURL;
        private List<IShortURL> _surlList = new List<IShortURL>();

        public string longURL { get => _longURL; set => _longURL = value; }
        public List<IShortURL> surList { get => _surlList; set => _surlList = value; }

        public URL(string lURL, IShortURL sURL, string tinyURL)
        {
            _longURL = lURL;
     
            sURL.counter = 0;
            sURL.shortURL = tinyURL;

            _surlList.Add(sURL);
        }


        public string? getShortURLs()
        {
            StringBuilder shortURLStringBuilder = new StringBuilder();
            foreach (IShortURL x in _surlList)
            {

                shortURLStringBuilder = shortURLStringBuilder.Append(x.shortURL + ",");

            }

            return shortURLStringBuilder.ToString().Trim(",".ToCharArray());
        }

        public bool SaveShortURL(string URL, IShortURL? sURL)
        {
            IShortURL shortURL = new ShortURL();
            shortURL.shortURL = URL; shortURL.counter = 0;
            _surlList.Add(shortURL);
            return true;
        }

        public bool DeleteShortURL(IShortURL? sURL)
        {
            return _surlList.Remove(sURL);

        }

    }
}

