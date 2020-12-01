using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace AdventOfCode
{
    public class Day4
    {
        public static bool CheckValid(int password)
        {
            var digits = password.ToString().Select(c => int.Parse(c.ToString())).ToArray();
            if (digits.Length != 6)
            {
                return false;
            }

            var twoMatch = false;
            var matchLength = 0;

            for (var i = 1; i < digits.Length; i++)
            {
                if (digits[i - 1] == digits[i])
                {
                    matchLength += 1;
                } else if (digits[i - 1] > digits[i])
                {
                    return false;
                }
                else
                {
                    if (matchLength == 1)
                    {
                        twoMatch = true;
                    }

                    matchLength = 0;
                }
            }

            return twoMatch || matchLength == 1;
        }

        public static int Solve()
        {
            var valid = from i in Enumerable.Range(193651, 649729 - 193651).AsParallel()
                where CheckValid(i)
                select i;
            return valid.Count();
        }
    }
}