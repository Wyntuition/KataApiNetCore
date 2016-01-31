using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KataApiAspNet5
{
    public class RomanNumeralService
    {
        public static IEnumerable<string> ConvertNumbers(int[] arabicNumbers)
        {
            var convertedNumbers = new List<string>();
            for (int i = 0; i < arabicNumbers.Length; i++)
            {
                var romanNumeral = new RomanNumeral(arabicNumbers[i]);
                convertedNumbers.Add(romanNumeral.ToString());
            }

            return convertedNumbers;
        }

        //public static string ToRoman(int arabicNumber)
        //{
        //    var romanNumeral = List<string>;

        //    if (arabicNumber < 1)
        //        return "0";

        //    if (arabicNumber > 1000)
        //    {
        //        romanNumeral.Add("M");
        //    }

        //    if (arabicNumber > 499 && arabicNumber < 1000)
        //    {
        //        romanNumeral.Add("D");
        //    }

        //    if (arabicNumber < 4)
        //    {
        //        for (int i = 0; i < arabicNumber; i++)
        //        {
        //            romanNumeral.Add("I");
        //        }
        //    }
            
        //    switch (arabicNumber)
        //    {
        //        case 1:
        //            return "I";
        //    }   
        //}
    }
}
