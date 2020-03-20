using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex r = new Regex(@"^[+]{0,1}(\d+)$");
            Console.WriteLine(r.IsMatch("64"));
            Console.Read();
        }
    }
}
