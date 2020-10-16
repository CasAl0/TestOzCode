using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOzCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Enumerable.Range(0, 100);

            var result = from n in numbers
                let isEven = n % 2 == 0
                let isOdd = !isEven
                let isMultipleOfFive = n % 5 == 0
                where isOdd && isMultipleOfFive
                select n
                into multipleOfFiveAndOdd
                where multipleOfFiveAndOdd % 15 == 0
                select multipleOfFiveAndOdd;
             

            var result2 = numbers.Select(n => new { n, isEven = n % 2 == 0 })
                .Select(@t => new { @t, isOdd = !@t.isEven })
                .Select(@t => new { @t, isMultipleOfFive = @t.@t.n % 5 == 0 })
                .Where(@t => @t.@t.isOdd && @t.isMultipleOfFive)
                .Select(@t => @t.@t.@t.n)
                .Where(multipleOfFiveAndOdd => multipleOfFiveAndOdd % 15 == 0);

        }
    }
}
