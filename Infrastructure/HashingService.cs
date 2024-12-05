using System;
using System.Data.Common;
using System.Security.Cryptography;
using System.Text;

namespace newyape;

public class HashingService(string values)
{
    public string Values { get; set; } = values;

    public string Hash()
    {
        StringBuilder sb = new();

        byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(Values));
        foreach (byte b in hash)
        {
            sb.Append(b.ToString("x2"));
        }       

        return sb.ToString();
    }
}
