// Copyright 2021 John L. Swartzentruber
namespace BigNumbers
{
    public class Integram
    {
        /// <summary>
        /// Sums up the digits from the result of adding
        /// 9 + 99 + 999 + 9...9 where the last number has maxNines (see below) 9s in it
        /// </summary>
        /// <param name="maxNines">Number of 9s in final number</param>
        /// <returns>Sum of the digits</returns>
        public static int BruteForceDigitSum(int maxNines)
        {
            var number = new BigNumber();
            var sum = new BigNumber();

            for (int i = 1; i <= maxNines; ++i)
            {
                number.Prefix(9);
                sum += number;
            }

            return sum.SumDigits();
        }

        public static int PatternDigitSum(int maxNines)
        {
            int p = 1;
            while (maxNines > p)
            {
                p = p * 10 + 1;
            }

            int digits = p.ToString().Length;

            int diff = (p * 10) - maxNines;

            int digitSum = 0;

            // Count sum of digits in the diff
            foreach (var c in diff.ToString())
            {
                digitSum += int.Parse(c.ToString());
            }

            return digitSum + maxNines - digits;
        }
    }
}
