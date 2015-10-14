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
            array = ResizeArrayToLeft(ref array, 1);
            array[0] = newValue;
            return array;
        }

        public byte[] ResizeArrayToLeft(ref byte[] oldArray, int diff)
        {
            var newArray = new byte[oldArray.Length + diff];
            for (var i = diff; i < newArray.Length; i++)
                newArray[i] = oldArray[i-diff];            
            return newArray;
        }
        public byte[] ResizeArrayToRight(ref byte[] oldArray, int diff)
        {
            var newArray = new byte[oldArray.Length + diff];
            for (var i = 0; i < oldArray.Length; i++)
                newArray[i] = oldArray[i];
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

        public byte GetElementPosition(byte[] number, int pos)
        {
            if (number.Length <= pos)
                return 0;
            return number[number.Length - 1 - pos];
        }

        public int CompareLenghtArray(int lengthX, int lengthY)
        {
            var result = 0;
            result = lengthX <= lengthY ? lengthY : lengthX;
            return result;
        }           
               
        public byte[] OrOperator(byte[] firstBytes, byte[] secondBytes)
        {
            var result = new byte[0];
            var lengthResult = CompareLenghtArray(firstBytes.Length,secondBytes.Length);
            for (var i = 0; i < lengthResult; i++)        
                 result = AddToArray(ref result, Or(GetElementPosition(firstBytes,i), GetElementPosition(secondBytes,i)));
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
            var lengthResult = CompareLenghtArray(firstBytes.Length, secondBytes.Length);
            for (var i = 0; i < lengthResult; i++)
                result = AddToArray(ref result, And(GetElementPosition(firstBytes, i), GetElementPosition(secondBytes, i)));
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
            return (byte)(number == 0 ? 1 : 0);
        }

        public byte[] XorOperator(byte[] firstBytes, byte[] secondBytes)
        {
            var result = new byte[0];
            var lengthResult = CompareLenghtArray(firstBytes.Length, secondBytes.Length);
            for (var i = 0; i < lengthResult; i++)
                result = AddToArray(ref result, Xor(GetElementPosition(firstBytes, i), GetElementPosition(secondBytes, i)));
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
            for (var i = 0; i < count; i++)
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
            for (var i = 0; i < count; i++)
                number = LeftHandShiftByOne(number);
            return number;
        }

        public bool LessThanBytes(byte[] firstBytes, byte[] secondBytes)
        {
            
            var length = CompareLenghtArray(firstBytes.Length, secondBytes.Length);
            for (var i = length - 1; i >= 0; i--)
            {
                if (GetElementPosition(firstBytes,i) < GetElementPosition(secondBytes,i))
                {
                    return true;
                }
                if (GetElementPosition(firstBytes, i) > GetElementPosition(secondBytes, i))
                {
                    return false;
                }                
            }
            return true;
        }

        public byte[] AddBaseBytes(byte[] firstBytes, byte[] secondBytes, int baseX)
        {
            var result = new byte[0];
            byte rest=0;
            var lengthResult = CompareLenghtArray(firstBytes.Length, secondBytes.Length);
            for (var i = 0; i < lengthResult; i++)
            {
                var add = GetElementPosition(firstBytes, i) + GetElementPosition(secondBytes, i)+rest;
                if (add >= baseX)
                {
                    rest = ConvertToBase(add, baseX)[0];
                    result = AddToArray(ref result, ConvertToBase(add, baseX)[1]);
                }
                else
                {
                    rest = 0;
                    result = AddToArray(ref result, (byte)add);
                }                
            }
            if (rest == 1)
            {
                result=AddToArray(ref result, rest);
            }
            return result;
        }

        public byte[] DeductBaseByte(byte[] firstBytes, byte[] secondBytes, int baseX)
        {
            var result = new byte[0];
            byte imprumut = 0;
            var lengthResult = CompareLenghtArray(firstBytes.Length, secondBytes.Length);
            for (var i = 0; i < lengthResult; i++)
            {
                var deductRezult = GetElementPosition(firstBytes, i) - GetElementPosition(secondBytes, i) - imprumut;
                if (GetElementPosition(firstBytes, i) < GetElementPosition(secondBytes, i))
                {
                    deductRezult =baseX + deductRezult;
                    result = AddToArray(ref result, (byte)deductRezult);
                    imprumut = 1;
                }
                else
                {
                    imprumut = 0;
                    result = AddToArray(ref result, (byte)deductRezult);
                }               
            }
            return result;
        }
        
        public byte[] MultiplyBaseByte(byte[] firstBytes, byte[] secondBytes, int baseX)
        {
            var result = new byte[0];
            
            byte rest = 0;
            for (var i = 0; i < secondBytes.Length; i++)
            {
                var partialResult = new byte[0];
                for (var j = 0; j < firstBytes.Length; j++)
                {
                    
                    var multiplyResult = GetElementPosition(secondBytes, i)*GetElementPosition(firstBytes, j) + rest;
                    if (multiplyResult > baseX)
                    {
                        rest = ConvertToBase(multiplyResult, baseX)[0];
                        partialResult = AddToArray(ref partialResult, ConvertToBase(multiplyResult, baseX)[1]);
                    }
                    else
                    {
                        rest = 0;
                        partialResult = AddToArray(ref partialResult, (byte) multiplyResult);
                    }
                }
                partialResult = ResizeArrayToRight(ref partialResult, i);
                partialResult = ResizeArrayToLeft(ref partialResult, secondBytes.Length - i - 1);

                result = AddBaseBytes(result, partialResult, baseX);
            }
            return result;
        }
    }
}
