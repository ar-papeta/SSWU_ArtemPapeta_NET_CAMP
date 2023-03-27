using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tensor
{
    internal static class TensorValidator
    {
        public static void ValidateDimensionsLength(int[] dimentions)
        {
            foreach (var d in dimentions)
            {
                if(d < 1)
                {
                    throw new Exception("Dimention length can not be less then 1");
                }
            }
        }

        public static void ValidateIndex(int[] dimensions, int index)
        {
            var maxIndex = 1;
            foreach (var d in dimensions)
            {
                maxIndex *= d;
            }
            if(maxIndex <= index)
            {
                throw new IndexOutOfRangeException("Item with index do not exist");
            }   
        }

        public static void ValidateElementsCount(int maxLength, int count)
        {
            if(maxLength < count)
            {
                throw new Exception($"Dimentions is not enought for initial data. Expected max count {maxLength} but init {count}");
            }
        }
    }
}
