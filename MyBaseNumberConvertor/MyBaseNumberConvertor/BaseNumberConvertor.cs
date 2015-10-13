using System;
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
            
            var resultReverse=new byte[0];
            while (number > 0)
            {
                var remainder = number % baseX;
                number = number / baseX;
                resultReverse = AddToArray(ref resultReverse, (byte)remainder);
            }
            var result = ReverseArray(ref resultReverse);
            return result;
        }
        public byte[] AddToArray(ref byte[] array, byte newValue)
        {
            array = ResizeArray(ref array, 1);
            array[array.Length-1] = newValue;
            return array;
        }

        public byte[] ResizeArray(ref byte[] oldArray, int diff)
        {
            var newArray = new byte[oldArray.Length + diff];
            for (var i = 0; i < oldArray.Length; i++)
                newArray[i] = oldArray[i];
            //Array.Copy(oldArray,0,newArray,0,newArray.Length-1);
            return newArray;
        }

        public byte[] ReverseArray(ref byte[] oldArray)
        {
            var newArray = new byte[oldArray.Length];
            var index = 0;
            for (var i = oldArray.Length - 1; i >= 0; i--)
            {
                newArray[index] = oldArray[i];
                index++;
            }
            return newArray;
        }


        public int ConvertFromBase(byte[] numberDigits, int baseX)
        {
            var result = 0;
            for (var i = 0; i < numberDigits.Length; i++)
                result = result + (int)(numberDigits[i] * Math.Pow(baseX, numberDigits.Length - i - 1));
            return result;
        }

        //public byte[,] ProceessByteArray(byte[] firstBytes, byte[] secondBytes)
        //{
        //    if (firstBytes.Length < secondBytes.Length)
        //        firstBytes = ResizeArray(ref firstBytes, secondBytes.Length - firstBytes.Length);
        //    else if (firstBytes.Length > secondBytes.Length)
        //    {
        //        secondBytes = ResizeArray(ref secondBytes, firstBytes.Length - secondBytes.Length);
        //    }
        //    var array = new byte[,] { { firstBytes},{secondBytes}};
        //    return array;
        //}


        public byte[] OrOperator(byte[] firstBytes, byte[] secondBytes)
        {
            var result = new byte[0];
            if (firstBytes.Length < secondBytes.Length)
                firstBytes = ResizeArray(ref firstBytes, secondBytes.Length-firstBytes.Length);
            else if(firstBytes.Length > secondBytes.Length)
            {
                secondBytes = ResizeArray(ref secondBytes,firstBytes.Length-secondBytes.Length);
            }
            for (var i = 0; i < secondBytes.Length; i++)        
                 result = AddToArray(ref result, Or(firstBytes[i], secondBytes[i]));
            return result;
        }

        public byte Or(byte firstBytes, byte secondBytes)
        {
            
            byte result;
            if (firstBytes == 0 && secondBytes == 0)
                result = 0;
            else result = 1;
            return result;
        }

        public byte[] AndOperator(byte[] firstBytes, byte[] secondBytes)
        {
            var result = new byte[0];
            if (firstBytes.Length < secondBytes.Length)
                firstBytes = ResizeArray(ref firstBytes, secondBytes.Length - firstBytes.Length);
            else if (firstBytes.Length > secondBytes.Length)
            {
                secondBytes = ResizeArray(ref secondBytes, firstBytes.Length - secondBytes.Length);
            }
            for (var i = 0; i < secondBytes.Length; i++)
                result = AddToArray(ref result, And(firstBytes[i], secondBytes[i]));
            return result;
        }

        public byte And(byte firstBytes, byte secondBytes)
        {
            byte result;
            if (firstBytes == 0 || secondBytes == 0)
                result = 0;
            else result = 1;
            return result;
        }

        public byte[] NotOnArray(byte[] number)
        {
            var result = new byte[number.Length];
            for (var i = 0; i < number.Length; i++)
            {
                result[i]=Not(number[i]);
            }
            return result;
        }

        public byte Not(byte number)
        {

            byte result;

            if (number == 0)
                result = 1;
            else result = 0;

            return result;

        }

        public byte[] XorOperator(byte[] firstBytes, byte[] secondBytes)
        {
            var result = new byte[0];
            if (firstBytes.Length < secondBytes.Length)
                firstBytes = ResizeArray(ref firstBytes, secondBytes.Length - firstBytes.Length);
            else if (firstBytes.Length > secondBytes.Length)
            {
                secondBytes = ResizeArray(ref secondBytes, firstBytes.Length - secondBytes.Length);
            }
            for (var i = 0; i < secondBytes.Length; i++)
                result = AddToArray(ref result, Xor(firstBytes[i], secondBytes[i]));
            return result;
        }

        public byte Xor(byte firstBytes, byte secondBytes)
        {
            byte result;
            if ((firstBytes == 0 && secondBytes == 0) || (firstBytes == 1 && secondBytes == 1))
                result = 1;
            else result = 0;
            return result;
        }

        public byte[] RightHandShiftByOne(byte[] number)
        {
            var result = new byte[number.Length];
                for (var i = 1; i <= number.Length - 1; i++)
                {
                    result[i] = number[i - 1];
                }
                result[0] = number[number.Length - 1];
           
            return result;
        }

        public byte[] RightHandShift(byte[] number, int count)
        {
            for (int i = 0; i < count; i++)
                number = RightHandShiftByOne(number);
            return number;
        }

        public byte[] LeftHandShiftByOne(byte[] number)
        {
            var result = new byte[number.Length];
            for (var i = 0; i < number.Length - 1; i++)
            {
                result[i] = number[i + 1];
            }
            result[number.Length - 1] = number[0];
            return result;
        }

        public byte[] LeftHandShift(byte[] number, int count)
        {
            for (int i = 0; i < count; i++)
                number = LeftHandShiftByOne(number);
            return number;
        }

        public byte[] AddBinarNumber(byte[] firstBytes, byte[] secondBytes)
        {
            var result = new byte[0];
            var transport = 0;
            if (firstBytes.Length < secondBytes.Length)
                firstBytes = ResizeArray(ref firstBytes, secondBytes.Length - firstBytes.Length);
            else if (firstBytes.Length > secondBytes.Length)
            {
                secondBytes = ResizeArray(ref secondBytes, firstBytes.Length - secondBytes.Length);
            }
            for (int i = firstBytes.Length - 1; i >= 0; i--)
            {
                
                if ((firstBytes[i] + secondBytes[i] + transport) > 1)
                {
                    result = AddToArray(ref result, (byte) (0));
                    transport = 1;
                }
                else
                {
                    result = AddToArray(ref result, (byte) (firstBytes[i] + secondBytes[i] + transport));
                    transport = 0;
                }
            }
            return result;
        }
    }
}
