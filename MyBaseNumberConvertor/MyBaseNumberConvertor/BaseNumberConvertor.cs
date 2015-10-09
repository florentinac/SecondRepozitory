using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MyBaseNumberConvertor
{
    public class BaseNumberConvertor
    {
        public byte[] ConvertToBase(int number, int baseX)
        {
            var result = new byte[8];
            int index = 7;
            
                while (number > 0)
                {
                    var remainder = number % baseX;
                    number = number/baseX;
                    result[index--] = (byte)(remainder);
                }
            
            return result;
        }

        public int ConvertFromBase(string numberDigits, int baseX)
        {
            var result = 0;
            for (var i = 0; i < numberDigits.Length; i++)
                result = result + (int)(int.Parse(numberDigits[i].ToString())*Math.Pow(baseX, numberDigits.Length-i-1));
            return result;
        }
    }
}
