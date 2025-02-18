using Newtonsoft.Json;
using System;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;

namespace EXAPI
{
    public class Translator
    {
        // Generates an HMACSHA256 hash using the given secret key and the current timestamp
        public static string GenerateHMACSHA256(string secretKey)
        {
            Encoding encoding = Encoding.GetEncoding("latin1");
            byte[] keyBytes = encoding.GetBytes(secretKey);

            // Generate current timestamp in milliseconds
            long currentTimestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            byte[] messageBytes = encoding.GetBytes(currentTimestamp.ToString());

            using (var hmac = new HMACSHA256(keyBytes))
            {
                byte[] hashBytes = hmac.ComputeHash(messageBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        // Decompresses response data that could either be GZip compressed or plain JSON
        public static string DecompressResponse(byte[] res)
        {
            try
            {
                using (var memoryStream = new MemoryStream(res))
                using (var gzipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                using (var streamReader = new StreamReader(gzipStream, Encoding.UTF8))
                {
                    return streamReader.ReadToEnd();
                }
            }
            catch (InvalidDataException)
            {
                // If it's not GZip compressed, assume plain JSON
                return Encoding.UTF8.GetString(res);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during decompression: " + ex.Message);
                return null;
            }
        }

    }
}
