using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBaseNumberConvertor
{
    public class BaseNumberConvertor
    {
        public byte[] ConvertToBase(int number, int baseX, int lenght)
        {
            var result = new byte[lenght];
            int index = lenght;

            while (number > 0)
            {
                var remainder = number % baseX;
                number = number / baseX;
                result[--index] = (byte)(remainder);
            }

            return result;
        }
        public byte[] Add(int number, int lenght)
        {
            var result = new byte[lenght];
            result[--lenght] = (byte)number;
            return result;
        }

        public int ConvertFromBase(string numberDigits, int baseX)
        {
            var result = 0;
            for (var i = 0; i < numberDigits.Length; i++)
                result = result + (int)(int.Parse(numberDigits[i].ToString()) * Math.Pow(baseX, numberDigits.Length - i - 1));
            return result;
        }

        public int ConvertFromBase(byte[] numberDigits, int baseX)
        {
            var result = 0;
            for (var i = 0; i < numberDigits.Length; i++)
                result = result + (int)(numberDigits[i] * Math.Pow(baseX, numberDigits.Length - i - 1));
            return result;
        }
        public byte[] AndOperator(byte[] firstBytes, byte[] secondBytes)
        {
            var rezult = new byte[firstBytes.Length];
            for (var i = 0; i < firstBytes.Length; i++)
                if (firstBytes[i] == 0 && secondBytes[i] == 0)
                    rezult[i] = 0;
                else rezult[i] = 1;
            return rezult;
        }
        public byte[] OrOperator(byte[] firstBytes, byte[] secondBytes)
        {
            var rezult = new byte[firstBytes.Length];
            for (var i = 0; i < firstBytes.Length; i++)
                if (firstBytes[i] == 0 || secondBytes[i] == 0)
                    rezult[i] = 0;
                else rezult[i] = 1;
            return rezult;
        }
    }
}
