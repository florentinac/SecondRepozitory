using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MyBaseNumberConvertor
{
    public delegate byte DelegateOperator(byte first, byte second);
    public class BaseNumberConvertor
    {
        public byte[] AdditionBaseBytesArray(byte[] firstBytes, byte[] secondBytes, int baseX)
        {
            var result = new byte[0];
            byte rest = 0;
            var lengthResult = MaxValue(firstBytes.Length, secondBytes.Length);
            for (var i = 0; i < lengthResult; i++)
            {
                var add = GetElementFromPosition(firstBytes, i) + GetElementFromPosition(secondBytes, i) + rest;
                rest = (byte)(add / baseX);
                result = AddToArray(ref result, (byte)(add % baseX));
            }
            if (rest > 0)
            {
                result = AddToArray(ref result, rest);
            }
            return result;
        }

        public byte[] AddToArray(ref byte[] array, byte newValue)
        {
            array = ResizeArrayAndShiftRight(array, 1);
            array[0] = newValue;
            return array;
        }       

        public byte[] LogicalOperator(byte[] first, byte[] second, DelegateOperator delegateOperator)
        {
            var result = new byte[0];
            var lengthResult = MaxValue(first.Length, second.Length);
            for (var i = 0; i < lengthResult; i++)
                result = AddToArray(ref result, delegateOperator(GetElementFromPosition(first, i), GetElementFromPosition(second, i)));
            return result;           
        }

        public byte[] AndOperator(byte[] first, byte[] second)
        {           
            return LogicalOperator(first,second,(a,b) => (byte)((a == 0 || b == 0) ? 0 : 1));
        }

        public int ConvertFromBase(byte[] numberDigits, int baseX)
        {
            var result = 0;
            for (var i = 0; i < numberDigits.Length; i++)
                result = result + (int)(numberDigits[i] * Math.Pow(baseX, numberDigits.Length - i - 1));
            return result;
        }

        public byte[] ConvertToBase(int number, int baseX)
        {
            
            var resultReverse=new byte[0];
            if (number == 0)
            {
                resultReverse = AddToArray(ref resultReverse, (byte) 0);
                return  resultReverse;
            }
            while (number > 0)
            {
                var remainder = number % baseX;
                number = number / baseX;
                resultReverse = AddToArray(ref resultReverse, (byte)remainder);
            }       
            return resultReverse;
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
                    deductResult = baseX + deductResult;
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
            if (LessThan(firstBytes, secondBytes))
            {
                result = AddToArray(ref result, (byte)0);
                return result;
            }
            for (var i = 0; i < lengthResult; i++)
            {
                var difference = baseX + GetElementFromPosition(firstBytes, i) - GetElementFromPosition(secondBytes, i) - remainder;
                result = AddToArray(ref result, (byte)(difference % baseX));
                remainder = (byte)(difference / baseX);
                remainder = (byte)(remainder == 0 ? 1 : 0);
            }
            return result;
        }

        public byte[] DivisionBaseBytesArray(byte[] first, byte[] second, int baseX)
        {
            var difference = first;
            var index = 0;
            var boolean = false;

            while (boolean != true)
            {
                boolean = LessThan(difference, second);
                index = boolean ? index : index + 1;
                difference = DeductBaseNumber(difference, second, baseX);
            }
            var result = ConvertToBase(index, baseX);
            return result;
        }

        public bool Equal(byte[] first, byte[] second)
        {
            return (LessThan(first, second) == false) && (LessThan(second, first) == false);
        }

        public byte GetElementFromPosition(byte[] number, int pos)
        {
            return (byte)(number.Length <= pos ? 0 : number[number.Length - 1 - pos]);
        }

        public bool GraterThan(byte[] first, byte[] second)
        {
            return LessThan(second, first);
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

        public bool LessThan(byte[] first, byte[] second)
        {

            var length = MaxValue(first.Length, second.Length);
            for (var i = length - 1; i >= 0; i--)
            {
                if (GetElementFromPosition(first, i) < GetElementFromPosition(second, i))
                {
                    return true;
                }
                if (GetElementFromPosition(first, i) > GetElementFromPosition(second, i))
                {
                    return false;
                }
            }
            return false;
        }

        public int MaxValue(int x, int y)
        {
            return x >= y ? x : y;
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

        public byte Not(byte number)
        {
            return (byte)(number == 0 ? 1 : 0);
        }

        public bool NotEqual(byte[] first, byte[] second)
        {
            return !Equal(first, second);
        }

        public byte[] NotOnArray(byte[] number)
        {
            var result = new byte[number.Length];
            for (var i = 0; i < number.Length; i++)
            {
                result[i] = Not(number[i]);
            }
            return result;
        }       

        public byte[] OrOperator(byte[] first, byte[] second)
        {          
            return LogicalOperator(first,second,(a,b)=> (byte)((a == 0 && b == 0) ? 0 : 1));
        }

        public byte[] ResizeArray(byte[] oldArray, int difference)
        {
            var newArray = new byte[oldArray.Length + difference];
            for (var i = 0; i < oldArray.Length; i++)
                newArray[i] = oldArray[i];
            return newArray;
        }

        public byte[] ResizeArrayAndShiftRight(byte[] oldArray, int difference)
        {           
            var newArray = ResizeArray(oldArray, difference);
            newArray = RightHandShift(newArray, difference);
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
        public byte[] RightHandShift(byte[] number, int count)
        {
            var result = new byte[number.Length];
            for (var i = count; i <= number.Length - 1; i++)
            {
                result[i] = number[i - count];
            }
            return result;
        }      

        public byte[] XorOperator(byte[] first, byte[] second)
        {      
            return LogicalOperator(first,second,(a,b)=> (byte)(((a == 0 && b == 0) || (a == 1 && b == 1)) ? 0 : 1));
        }
    }
}
