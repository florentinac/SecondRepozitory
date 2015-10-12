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
            if (firstBytes.Length == secondBytes.Length)
            {
                for (var i = 0; i < firstBytes.Length; i++)
                    if (firstBytes[i] == 0 && secondBytes[i] == 0)
                        rezult[i] = 0;
                    else rezult[i] = 1;
            }
            else
            {
                throw new ArgumentException();
            }
            return rezult;
        }

        public byte[] OrOperator(byte[] firstBytes, byte[] secondBytes)
        {
            var result = new byte[firstBytes.Length];
            if (firstBytes.Length == secondBytes.Length)
            {
                
                for (var i = 0; i < firstBytes.Length; i++)
                    if (firstBytes[i] == 0 || secondBytes[i] == 0)
                        result[i] = 0;
                    else result[i] = 1;
            }
            else
            {
                throw new ArgumentException();
            }

            return result;
        }

        public byte[] Not(byte[] number)
        {
            var rezult = new byte[number.Length];
            for (var i = 0; i < number.Length; i++)
            {
                if (number[i] == 0)
                    rezult[i] = 1;
                else rezult[i] = 0;
            }
            return rezult;
        }
        public byte[] XorOperator(byte[] firstBytes, byte[] secondBytes)
        {
            var rezult = new byte[firstBytes.Length];
            if (firstBytes.Length == secondBytes.Length)
            {
                for (var i = 0; i < firstBytes.Length; i++)
                    if ((firstBytes[i] == 0 && secondBytes[i] == 0) || (firstBytes[i] == 1 && secondBytes[i] == 1))
                        rezult[i] = 1;
                    else rezult[i] = 0;
            }
            else
            {
                throw new ArgumentException();
            }
            return rezult;
        }

        public byte[] RightHandShift(byte[] number, int count)
        {
            var result = new byte[number.Length];
            for (var i = 1; i <= number.Length - 1; i++)
            {
                result[i] = number[i-1];
            }
            result[0] = number[number.Length - count];
            return result;
        }

        public byte[] LeftHandShift(byte[] number, int count)
        {
            var result = new byte[number.Length];
            for (var i = 0; i < number.Length - 1; i++)
            {
                result[i] = number[i + count];
            }
            result[number.Length - 1] = number[0];
            return result;
        }
    }
}
