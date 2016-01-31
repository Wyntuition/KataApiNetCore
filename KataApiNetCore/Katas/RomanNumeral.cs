using System;

namespace KataApiAspNet5
{
    public class RomanNumeral
    {
        private int number;

        public RomanNumeral(int number)
        {
            this.number = number;
        }

        public RomanNumeral(string number)
        {
            this.number = int.Parse(number);
        }

        public override string ToString()
        {
            if (this.number > 3000)
                return "";

            var result = "";
            
            var thousands = this.number / 1000;
            result += Times(thousands, "M");

            var hundreds = this.number / 100 % 10;
            result += Times(hundreds, "C", "D", "M");

            var tens = this.number / 10 % 10;
            result += Times(tens, "X", "L", "C");

            var ones = this.number % 10;
            result += Times(ones, "I", "V", "X");

            return result;
        }

        private string Times(int number, string character)
        {
            var result = "";
            for (int i = 0; i < number; i++)
            {
                result += character;
            }
            return result;
        }

        private string Times(int number, string onesChar, string fivesChar, string tensChar)
        {
            switch (number)
            {
                case 0:
                    return "";
                case 1:
                case 2:
                case 3:
                    return Times(number, onesChar);
                case 4:
                    return onesChar + fivesChar;
                case 5:
                case 6:
                case 7:
                case 8:
                    return fivesChar + Times(number - 5, onesChar);
                case 9:
                    return onesChar + tensChar;
                default:
                    throw new ArgumentException("Numbers only");
            }
        }
    }
}
