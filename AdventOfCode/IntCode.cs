using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class IntCode
    {
        public static int[] Execute(IEnumerable<int> program)
        {
            var array = program.ToArray();

            for (var i = 0; i < array.Length; i+= 4)
            {
                var opCode = array[i];
                if (opCode == 99)
                {
                    break;
                }

                var op1 = array[array[i + 1]];
                var op2 = array[array[i + 2]];
                array[array[i + 3]] = opCode switch
                {
                    1 => (op1 + op2),
                    2 => (op1 * op2),
                    _ => array[array[i + 3]]
                };
            }

            return array;
        }
    }
}