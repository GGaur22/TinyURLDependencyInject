using System;
using System.Text;


namespace TinyURL
{
    public static class Helper
    {
        public static string GenerateRandomString(int minLength, int maxLength)
        {
            Random random = new Random();
            int length = random.Next(minLength, maxLength + 1); 

            const string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"; 
            StringBuilder stringBuilder = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(chars.Length); 
                stringBuilder.Append(chars[index]); 
            }

            return stringBuilder.ToString();
        }
    }
}
