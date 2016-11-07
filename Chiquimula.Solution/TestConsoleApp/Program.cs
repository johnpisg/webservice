using Chiquimula.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var frase = "Ch1qu1muL4@pp1c4T!0n";

            var pass = "Admin@1234";
            Console.WriteLine("Encriptando " +  pass);
            var enc = Crypto.Encrypt(pass, frase);
            Console.WriteLine(enc);
            Console.WriteLine("Encriptando otra vez..");
            var enc2 = Crypto.Encrypt(pass, frase);
            Console.WriteLine(enc2);

            Console.WriteLine("Desencriptando..");
            Console.WriteLine(Crypto.Decrypt(enc, frase));
            Console.WriteLine("Desencriptando 2..");
            Console.WriteLine(Crypto.Decrypt(enc2, frase));

            Console.ReadLine();
        }
    }
}
