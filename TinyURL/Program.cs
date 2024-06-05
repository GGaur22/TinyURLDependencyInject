using TinyURLConversion;

namespace TinyURL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {

                List<URL> urlList = new List<URL>();
                URL? myURL = null;
                Console.WriteLine("Welcome to TinyURL service!");
                Module1 module1 = new Module1();
                while (true)
                {
                    Console.WriteLine("Please enter 1 for shortening a URL, enter 2 for deleting a TinyURL, enter 3 for checking LongURL for a TinyURL or enter 9 to exit the app");
                    string? userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case "1":
                            Console.WriteLine("Please enter the LongURL");
                            string? longURL = Console.ReadLine();
                            string? shortURL = null;
                            //code to check if url exists
                            myURL = urlList.FirstOrDefault(item => item.longURL == longURL);

                            module1.displayExsitingTinyURLs(myURL, urlList, longURL);

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

                            module1.addTinyURL(myURL, urlList,  tinyURL, longURL);
                            ////check if the TinyURL already exist 
                            
       //                     myURL = urlList.FirstOrDefault(l => l.surList.FirstOrDefault(j => j.ShortURL == tinyURL));

                            myURL = urlList.FirstOrDefault(l => l.surList.Any(m => m.shortURL == tinyURL));

                            break;

                        case "2":
                            //delete TinyURL
                            Console.WriteLine("Enter the tinyURL you want to delete");
                            string? deleteURL = Console.ReadLine();
                            myURL = urlList.FirstOrDefault(l => l.surList.Any(m => m.shortURL == deleteURL));
                            //myURL = urlList.FirstOrDefault(l => l.shortURL.ContainsKey(deleteURL));
                            if (myURL != null)
                            {
                                IShortURL u = myURL.surList.Find(l => l.shortURL == deleteURL);
                                myURL.DeleteShortURL(u);
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
                            //myURL = urlList.FirstOrDefault(l => l.shortURL.ContainsKey(tinyURLSearch));
                            myURL = urlList.FirstOrDefault(l => l.surList.Any(m => m.shortURL == tinyURLSearch));
                            if (myURL != null)
                            {
                                IShortURL u = myURL.surList.Find(l => l.shortURL == tinyURLSearch);
                                int IcOUNTER = u.counter;
                                u.counter++;
                              
                                Console.WriteLine($"The corresponding LongURL is {myURL.longURL} and it has been clicked {u.counter} times.");
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
            catch (Exception e)
            {

                Console.WriteLine($"Exception {e}");
                //throw;
            }
            finally { Console.WriteLine(); }

        }

        class Module1
        {
            public void displayExsitingTinyURLs(URL myURL, List<URL> urlList, string? longURL)
            {
                string? shortURL = "";
                try
                {
                    myURL = urlList.FirstOrDefault(item => item.longURL == longURL);
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
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception {e}");
                    throw;
                }

            }

            public void addTinyURL(URL myURL, List<URL> urlList, string? tinyURL, string? longURL)
            {
                try
                {
                    ////check if the TinyURL already exist 
                    //myURL = urlList.FirstOrDefault(l => l.shortURL.ContainsKey(tinyURL));
                    myURL = urlList.FirstOrDefault(l => l.surList.Any(m => m.shortURL == tinyURL));
                    if (myURL != null)
                    Console.WriteLine("This TinyURL already exists. Please enter a different TinyURL");
                else
                {
                        //check if the longurl already exists
                        IShortURL sURL = new ShortURL();
                        myURL = urlList.FirstOrDefault(item => item.longURL == longURL);
                        if (myURL != null)
                            myURL.SaveShortURL(tinyURL, sURL);
                        else
                        {
                            
                            urlList.Add(new URL(longURL, sURL, tinyURL));
                        }

                }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception {e}");
                    throw;
                }
            }
        }

    }   
}

