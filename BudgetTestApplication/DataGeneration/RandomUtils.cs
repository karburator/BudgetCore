using System;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace BudgetTestApplication.DataGeneration
{
    public static class RandomUtils
    {
        private static readonly Random Rnd = new Random();
        public static string NumberedString(int length)
        {
            var allowedChars = "0123456789";
            var builder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                var index = Rnd.Next(0, allowedChars.Length - 1);
                builder.Append(allowedChars[index]);
            }

            return builder.ToString();
        }

        public static int PositiveNumber(int maxVal = Int32.MaxValue)
        {
            return Rnd.Next(0, maxVal);
        }

        public static int Number(int minVal, int maxVal)
        {
            return Rnd.Next(minVal, maxVal);
        }
    }
}