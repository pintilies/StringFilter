using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input list:");

            var listAsString = Console.ReadLine();

            List<string> list = listAsString.Split(',').Select(o => o.Trim()).ToList();

            Console.WriteLine("Result:");

            Console.WriteLine(string.Join(", ", list.FilterBySubStrCombination(6)));

            Console.ReadKey();
        }
    }
}
