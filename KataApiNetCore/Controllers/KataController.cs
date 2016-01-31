using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using KataApiAspNet5.Katas;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace KataApiAspNet5.Controllers
{
    [Route("api/[controller]")]
    public class KataController : Controller
    {
        public class StringListKataAnswer
        {
            public IEnumerable<string> data { get; set; }
        }

        public class IntListKataAnswer
        {
            public IEnumerable<int> data { get; set; }
        }

        public class UintListKataAnswer
        {
            public IEnumerable<uint> data { get; set; }
        }

        public class WmataDestination
        {
            public string Station { get; set; }
            public decimal Latitude { get; set; }
            public decimal Longitude { get; set; }
        }

        [Route("wmataDestination")]
        [HttpPost]
        public string FindWmataDestination([FromBody] StationEntranceQuery stationEntraceQuery)
        {
            var metroInfo = new MetroInfo();
            return metroInfo.WmataStationInfo(stationEntraceQuery);
        }

        [Route("toRoman")]
        [HttpPost]
        public StringListKataAnswer ToRoman([FromBody]int[] values)
        {
            //The response is missing a value for: ['MMMLI']

            return new StringListKataAnswer { data = RomanNumeralService.ConvertNumbers(values) };
        }

        [Route("fizzBuzz")]
        [HttpPost]
        public StringListKataAnswer PostFizzBuzz([FromBody]int[] input)
        {
            return FizzBuzz(input);
        }

        private StringListKataAnswer FizzBuzz(int[] input)
        {
            var number = input;
            var output = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] % 3 == 0 && input[i] % 2 == 0)
                    output.Add("FizzBuzz");
                else if (input[i] % 3 == 0)
                    output.Add("Buzz");
                else if (input[i] % 2 == 0)
                    output.Add("Fizz");
                else
                    output.Add(input[i].ToString());
            }

            return new StringListKataAnswer { data = output };
        }

        [Route("fibonacci")]
        [HttpPost]
        public UintListKataAnswer PostFibonacci([FromBody] int[] numbers)
        {
            return new UintListKataAnswer { data = Fibonaccis(numbers) };
        }

        public static List<uint> Fibonaccis(int[] numbers)
        {
            var results = new List<uint>();
            for (int i = 0; i < numbers.Length; i++)
            {
                results.Add(GetNthFibonacci_Ite(numbers[i]));
            }
            return results;
        }

        private static uint GetNthFibonacci_Ite(int n)
        {
            uint a = 0;
            uint b = 1;
            uint c = 1;

            for (uint i = 0; i < n; i++)
            {
                c = b + a;
                a = b;
                b = c;
            }
            return c;
        }

        [HttpPost]
        public IntListKataAnswer PostSumOfSquares([FromBody] int[] numbers)
        {
            return new IntListKataAnswer { data = SumOfSquares(numbers) };
        }

        private static List<int> SumOfSquares(int[] numbers)
        {
            var results = new List<int>();
            foreach (int number in numbers)
            {
                string numString = number.ToString();
                var intList = numString.Select(digit => int.Parse(digit.ToString()));

                var sum = 0;
                foreach (var num in intList)
                {
                    sum += num * num;
                }

                results.Add(sum);
            }
            return results;
        }



    }
}
