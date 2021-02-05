// Copyright 2021 John L. Swartzentruber
namespace BigNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BigNumber
    {
        // index 0 is the ones place. I.e., each value is multiplied by 10^index
        private List<short> digits = new List<short>();

        public BigNumber()
        {
        }

        public BigNumber(string s)
        {
            for (int index = s.Length - 1; index >= 0; --index)
            {
                if (short.TryParse(s[index].ToString(), out var digit)) {
                    this.digits.Add(digit);
                }
            }
        }

        static public BigNumber operator +(BigNumber lhs, BigNumber rhs)
        {
            var result = new BigNumber();

            int maxSize = Math.Max(lhs.digits.Count, rhs.digits.Count);
            int carry = 0;
            for (int index = 0; index < maxSize; ++index)
            {
                int sum = lhs.GetDigit(index) + rhs.GetDigit(index) + carry;
                int digit = sum % 10;
                carry = sum / 10;

                result.Prefix(digit);
            }

            if (carry > 0)
            {
                result.Prefix(carry);
            }

            return result;
        }

        public override string ToString() 
        {
            var result = new StringBuilder(this.digits.Count);

            for (int index = this.digits.Count - 1; index >= 0; --index)
            {
                result.Append(this.digits[index].ToString());
            }

            return result.ToString();
        }

        public void Prefix(int digit)
        {
            if (digit >= 0 && digit <= 9)
            {
                this.digits.Add((short)digit);
            }
        }

        public int SumDigits()
        {
            return this.digits.Select(s => (int)s).Sum();
        }

        private short GetDigit(int index)
        {
            if (index < this.digits.Count)
            {
                return this.digits[index];
            }

            return 0;
        }
    }
}
