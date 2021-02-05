// Copyright 2021 John L. Swartzentruber
namespace BigNumbers
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1 || !int.TryParse(args[0], out var digits)) {
                digits = 321;
            }

            Console.WriteLine($"Sum of the digits of N, where N = 9 + 99 + 999 + .. + 99...999, with the last term in the sum containing {digits} occurrences of the digit '9': {Integram.PatternDigitSum(digits)}");
        }
    }
}
 