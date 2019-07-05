using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleDistanceMatrix.Extensions
{
    public static class StringExtensions
    {
        public static bool IsEmpty(this string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }
        public static bool IsNotEmpty(this string input) => !IsEmpty(input);
    }
}
