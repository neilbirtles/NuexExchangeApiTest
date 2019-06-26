using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeApiTest
{

    public enum RestMethods
    {
        GET = 0,
        POST = 1,
        PUT = 2,
        DELETE = 3,
        HEAD = 4,
        OPTIONS = 5,
        PATCH = 6,
        MERGE = 7
    }

    public class HelperMethods
    {

        /// <summary>
        /// Attempts to download a JSON string from the given URL with the given headers and deserialize it to the specified class
        /// </summary>
        /// <typeparam name="T">Class to deserialize to</typeparam>
        /// <param name="url">URL to download JSON from</param>
        /// <returns>Instance of the class populated wth deserialized data</returns>
        public static T DownloadSerializedJSONData<T>(string url, string resource, Dictionary<string, string> headers, RestMethods method) where T : new()
        {
            var client = new RestClient(url);

            var request = new RestRequest(resource, (Method)method)
            {
                OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; }
            };

            //request.
            foreach (var item in headers)
            {
                request.AddHeader(item.Key, item.Value);
            }

            //client.ClearHandlers();

            IRestResponse<T> response = client.Execute<T>(request);
            return response.Data;
        }

        public static string GenerateHMAC256Hash(string key, string message)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            Byte[] code = encoder.GetBytes(key);
            HMACSHA256 hmSha256 = new HMACSHA256(code);

            Byte[] hashMe = encoder.GetBytes(message);
            Byte[] hmBytes = hmSha256.ComputeHash(hashMe);

            StringBuilder hex = new StringBuilder(hmBytes.Length * 2);
            foreach (byte b in hmBytes)
            {
                hex.AppendFormat("{0:x2}", b);
            }

            return hex.ToString();
        }

        public static long UnixTimeNowInTicks()
        {
            return (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalMilliseconds;
        }
    }
}

