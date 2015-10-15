using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
            return resultReverse;
        }
        public byte[] AddToArray(ref byte[] array, byte newValue)
        {
            array = ResizeArrayAndShiftRight(array, 1);
            array[0] = newValue;
            return array;
        }

        public byte[] ResizeArrayAndShiftRight(byte[] oldArray, int newSize)
        {
            var newArray = new byte[oldArray.Length + newSize];
            for (var i = newSize; i < newArray.Length; i++)
                newArray[i] = oldArray[i- newSize];            
            return newArray;
        }

        public byte[] ResizeArrayAndShiftLeft(byte[] oldArray, int newSize)
        {
            var newArray = new byte[oldArray.Length + newSize];
            for (var i = 0; i < oldArray.Length; i++)
                newArray[i] = oldArray[i];
            return newArray;
        }

        public byte[] ReverseArray(byte[] oldArray)
        {
            var newArray = new byte[oldArray.Length];           
            for (var i = oldArray.Length - 1; i >= 0; i--)
            {
                newArray[oldArray.Length-1-i] = oldArray[i];              
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

        public byte GetElementFromPosition(byte[] number, int pos)
        {
            return (byte)(number.Length <= pos ? 0 : number[number.Length - 1 - pos]);
        }

        public int MaxValue(int lengthX, int lengthY)
        {                    
            return lengthX <= lengthY ? lengthY : lengthX;
        }           
               
        public byte[] OrOperator(byte[] firstBytes, byte[] secondBytes)
        {
            var result = new byte[0];
            var lengthResult = MaxValue(firstBytes.Length,secondBytes.Length);
            for (var i = 0; i < lengthResult; i++)        
                 result = AddToArray(ref result, Or(GetElementFromPosition(firstBytes,i), GetElementFromPosition(secondBytes,i)));
            return result;
        }

        public byte Or(byte firstBytes, byte secondBytes)
        {                      
            return (byte)((firstBytes == 0 && secondBytes == 0) ? 0 : 1);
        }

        public byte[] AndOperator(byte[] firstBytes, byte[] secondBytes)
        {
            var result = new byte[0];
            var lengthResult = MaxValue(firstBytes.Length, secondBytes.Length);
            for (var i = 0; i < lengthResult; i++)
                result = AddToArray(ref result, And(GetElementFromPosition(firstBytes, i), GetElementFromPosition(secondBytes, i)));
            return result;
        }

        public byte And(byte firstBytes, byte secondBytes)
        {
            return (byte) ((firstBytes == 0 || secondBytes == 0) ? 0 : 1);
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
            return (byte)(number == 0 ? 1 : 0);
        }

        public byte[] XorOperator(byte[] firstBytes, byte[] secondBytes)
        {
            var result = new byte[0];
            var lengthResult = MaxValue(firstBytes.Length, secondBytes.Length);
            for (var i = 0; i < lengthResult; i++)
                result = AddToArray(ref result, Xor(GetElementFromPosition(firstBytes, i), GetElementFromPosition(secondBytes, i)));
            return result;
        }

        public byte Xor(byte firstBytes, byte secondBytes)
        {            
            return (byte)(((firstBytes == 0 && secondBytes == 0) || (firstBytes == 1 && secondBytes == 1)) ? 1 : 0);
        }

        public byte[] RightHandShift(byte[] number, int count)
        {
            var result = new byte[number.Length];
                for (var i = count; i <= number.Length - 1; i++)
                {
                    result[i] = number[i - count];
                }                         
            return result;
        }
       
        public byte[] LeftHandShift(byte[] number, int count)
        {
            var result = new byte[number.Length];
            for (var i = 0; i < number.Length - count; i++)
            {
                result[i] = number[i + count];
            }          
            return result;
        }
        

        public bool LessThanBytes(byte[] firstBytes, byte[] secondBytes)
        {
            
            var length = MaxValue(firstBytes.Length, secondBytes.Length);
            for (var i = length - 1; i >= 0; i--)
            {
                if (GetElementFromPosition(firstBytes,i) < GetElementFromPosition(secondBytes,i))
                {
                    return true;
                }
                if (GetElementFromPosition(firstBytes, i) > GetElementFromPosition(secondBytes, i))
                {
                    return false;
                }                
            }
            return false;
        }

        public byte[] AdditionBaseBytesArray(byte[] firstBytes, byte[] secondBytes, int baseX)
        {
            var result = new byte[0];
            byte rest=0;
            var lengthResult = MaxValue(firstBytes.Length, secondBytes.Length);
            for (var i = 0; i < lengthResult; i++)
            {
                var add = GetElementFromPosition(firstBytes, i) + GetElementFromPosition(secondBytes, i)+rest;
                rest = (byte)(add/baseX);
                result = AddToArray(ref result, (byte) (add % baseX));   
            }
            if (rest > 0)
            {
                result=AddToArray(ref result, rest);
            }
            return result;
        }

        public byte[] DeductBaseByteArray(byte[] firstBytes, byte[] secondBytes, int baseX)
        {
            var result = new byte[0];
            byte imprumut = 0;
            var lengthResult = MaxValue(firstBytes.Length, secondBytes.Length);
            for (var i = 0; i < lengthResult; i++)
            {
                var deductResult = GetElementFromPosition(firstBytes, i) - GetElementFromPosition(secondBytes, i) - imprumut;
                if (GetElementFromPosition(firstBytes, i) < GetElementFromPosition(secondBytes, i))
                {
                    deductResult =baseX + deductResult;
                    result = AddToArray(ref result, (byte)deductResult);
                    imprumut = 1;
                }
                else
                {
                    imprumut = 0;
                    result = AddToArray(ref result, (byte)deductResult);
                }               
            }
            return result;
        }
        public byte[] DeductBaseNumber(byte[] firstBytes, byte[] secondBytes, int baseX)
        {
            var result = new byte[0];
            byte remainder = 0;
            var lengthResult = MaxValue(firstBytes.Length, secondBytes.Length);
            for (var i = 0; i < lengthResult; i++)
            {
                    var deductResult = (baseX+GetElementFromPosition(firstBytes, i) - GetElementFromPosition(secondBytes, i) - remainder) % baseX;
                    result = AddToArray(ref result, (byte)deductResult);
                    remainder = (byte)((baseX+GetElementFromPosition(firstBytes, i) - GetElementFromPosition(secondBytes, i) - remainder) / baseX);
                    remainder = (byte)(remainder == 0 ? 1 : 0);
            }
            return result;
        }

        public byte[] MultiplyBaseBytesArray(byte[] first, byte[] second, int baseX)
        {
            var result = new byte[0];
            var length = ConvertFromBase(second, baseX);
            for (var i = 0; i < length; i++)
            {
                result = AdditionBaseBytesArray(first, result, baseX);
            }
            return result;
        }

        public byte[] DivisionBaseBytesArray(ref byte[] first, byte[] second, int baseX)
        {          
            var index = 0;
            
            for (var i = 0; i < 255; i++)
            {
                first = DeductBaseNumber(first, second, baseX);
                var boolean = LessThanBytes(first, second);
                index++;
                if (boolean)
                    break;
            }
            first = ConvertToBase(index, baseX);
            return first;
        }

    }
}
