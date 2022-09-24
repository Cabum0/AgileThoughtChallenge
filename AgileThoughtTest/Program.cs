using StringListHandler;
using System;
using System.Collections;

namespace AgileThoughtTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IList result = OrderingBy.Position(new string[]{
                "Sonia Maria Wood Dempster",
                "Laruen Ana Eagles Beneke",
                "Dorothy Rose Wong Dewitt",
                "Sandra Linda Dodge Holder"
            }, new int[] { 4, 2, 3, 1 });

            foreach (var s in result)
                Console.WriteLine(s);
        }
    }
}
