using Newtonsoft.Json;
using System;
using System.Text;

namespace Utility
{
    public class Base64Helper
    {
        public static string Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        /// <summary>
        /// Will try to decode the string with best effort.
        /// </summary>
        /// <param name="input">base64 or non base64 string</param>
        /// <returns> If it's a base64 it will convert if not it will return the input value.</returns>
        public static string TryDecode(string input)
        {
            try
            {
                return Decode(input);
            }
            catch (Exception)
            {
                return input;
            }
        }

        public static T DeserializeType<T>(string base64EncodedData)
        {
            var instanceJson = Decode(base64EncodedData);

            return JsonConvert.DeserializeObject<T>(instanceJson);
        }
    }
}