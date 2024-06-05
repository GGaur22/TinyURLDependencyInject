using System.ComponentModel.Design;
using System.Linq;
using TinyURLConversion;

namespace TinyURL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<URL> urlList = new List<URL>();
            URL? myURL = null;
            Console.WriteLine("Welcome to TinyURL service!");
            while (true) { 
                Console.WriteLine("Please enter 1 for shortening a URL, enter 2 for deleting a TinyURL, enter 3 for checking LongURL for a TinyURL or enter 9 to exit the app");
                string? userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Please enter the LongURL");
                        string? longURL = Console.ReadLine();
                        string? shortURL = null;
                        //code to check if url exists
                        myURL = urlList.FirstOrDefault(item => item.LongURL == longURL);
                        if (myURL != null)
                        {
                                shortURL = myURL.getShortURLs();
                        }
                        if (shortURL != null && shortURL.Length > 0)
                        {
                            Console.WriteLine("Here are the existing TinyURLs for this LongURL \r\n" + shortURL);
                        }
                        else
                        {
                            Console.WriteLine("No TinyURL(s) exist of this URL");
                        }

                        Console.WriteLine("Do you want the system to generate the TinyURL or enter the TinyURL yourself? Enter Y if you want the system to generate the URL. Y/N");
                        string? autoGenURL = Console.ReadLine();
                        string? tinyURL;
                        if (autoGenURL.ToUpper() == "Y")
                        {
                            tinyURL = Helper.GenerateRandomString(4, 8);
                            Console.WriteLine($"system generated TinyURL for {longURL} is {tinyURL}");
                        }
                        else
                        {
                            Console.WriteLine("Please enter the TinyURL");
                            tinyURL = Console.ReadLine();
                        }

                        ////check if the TinyURL already exist 
                        myURL = urlList.FirstOrDefault(l => l.ShortURL.ContainsKey(tinyURL));
                        if (myURL != null)
                            Console.WriteLine("This TinyURL already exists. Please enter a different TinyURL");
                        else
                        {
                            //check if the longurl already exists
                            myURL = urlList.FirstOrDefault(item => item.LongURL == longURL);
                            if (myURL != null)
                                myURL.SaveShortURL(tinyURL);
                            else
                                urlList.Add(new URL(longURL, tinyURL));
                        }
                        break;

                    case "2":
                        //delete TinyURL
                        Console.WriteLine("Enter the tinyURL you want to delete");
                        string? deleteURL = Console.ReadLine();
                        myURL = urlList.FirstOrDefault(l => l.ShortURL.ContainsKey(deleteURL));
                        if (myURL != null)
                        {
                            myURL.DeleteShortURL(deleteURL);
                            Console.WriteLine($"TinyURL {deleteURL} has been deleted");
                        }
                        else
                        {
                            Console.WriteLine($"TinyURL {deleteURL} does not exist");
                        }
                        break;

                    case "3":
                        Console.WriteLine("Enter the tinyURL to find corresponding LongURL");
                        string? tinyURLSearch = Console.ReadLine();
                        myURL = urlList.FirstOrDefault(l => l.ShortURL.ContainsKey(tinyURLSearch));
                        if (myURL != null)
                        {
                            myURL.ShortURL[tinyURLSearch] += 1;
                            Console.WriteLine($"The corresponding LongURL is {myURL.LongURL} and it has been clicked {myURL.ShortURL[tinyURLSearch]} times.");
                        }
                        else
                            Console.WriteLine($"tinyURL {tinyURLSearch} does not exist");
                        break;

                    case "9":
                    Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Please enter a valid selection");
                        break;

                }

            }
        }
    }
}
