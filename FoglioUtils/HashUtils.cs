using FoglioUtils.Extensions;
using System.IO;
using System.Security.Cryptography;

namespace FoglioUtils
{
    public static class HashUtils
    {
        public static string GenerateFileHash(string fileName)
        {
            if (!File.Exists(fileName)) return "";
            byte[] fileBuffer;
            try
            {
                fileBuffer = File.ReadAllBytes(fileName);
            }
            catch
            {
                //Log.F($"Failed to check hash on file {fileName}");
                return "";
            }
            return SHA256.Create().ComputeHash(fileBuffer).ToStringEx();

        }

        public static string GenerateHash(string input)
        {
            return SHA256.Create().ComputeHash(input.ToByteArray()).ToStringEx();
        }

    }
}
