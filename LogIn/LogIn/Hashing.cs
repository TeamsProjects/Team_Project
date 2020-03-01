using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Security.Cryptography;
namespace LogIn
{
    class Hashing
    {
        static private string text_to_hashing = "";
        static private BigInteger n = BigInteger.Parse("9516311845790656153499716760847001433441357");
        static private BigInteger e = 65537;
        static private BigInteger d = BigInteger.Parse("5617843187844953170308463622230283376298685");
        
         

        
        static public BigInteger execution(string txt)
        {
            Hashing.text_to_hashing = txt;
            byte[] plaintxt = ASCIIEncoding.ASCII.GetBytes(Hashing.text_to_hashing);
            BigInteger pt = new BigInteger(plaintxt);
            if (pt > Hashing.n)
            {
                throw new Exception();
            }
            BigInteger ct = BigInteger.ModPow(pt, Hashing.e, Hashing.n);
            Console.WriteLine("Encoded: " + ct);

            BigInteger dc = BigInteger.ModPow(ct, d, n);
            Console.WriteLine("Dcoded: " + dc);

            string decoded = ASCIIEncoding.ASCII.GetString(dc.ToByteArray());
            Console.WriteLine("ASCII: " + decoded);

            return ct;
        }
    }
}
