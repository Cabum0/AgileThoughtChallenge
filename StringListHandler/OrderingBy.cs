using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StringListHandler
{
    public class OrderingBy : IOrderingBy
    {
        /// <summary>
        /// This method will re-arrange the order of strings within an array
        /// </summary>
        /// <param name="names">array with a collection of strings</param>
        /// <param name="order">array with the desired order of the strings</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// <p><paramref name="names"/> is null. </p>
        /// <p><paramref name="order"/> is null. </p>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the string array has more elements than the order array or
        /// Thrown when the string array has fewer elements than the order array or
        /// Thrown when the smallest value cannot be equal to or less than zero
        /// </exception>
        public IList Position(IList<string> names, IList<int> order)
        {
            _ = Validation(ref names, ref order);

            IList result = new List<object>();

            foreach (var s in order)
                result.Add(names[s - 1]);

            return result;
        }

        public Tuple<int, int, int> Validation(ref IList<string> names, ref IList<int> order)
        {
            if (names == null)
                throw new ArgumentNullException("The string array cannot be null.");
            if (order == null)
                throw new ArgumentNullException("The order array cannot be null.");

            int Count = names.Count;
            int minvalue = order.Min();
            int maxvalue = order.Max();

            if (Count > maxvalue)
                throw new ArgumentException("The string array has more elements than the order array.");
            if (Count < maxvalue)
                throw new ArgumentException("The string array has fewer elements than the order array.");
            if (minvalue <= 0)
                throw new ArgumentException("The smallest value cannot be equal to or less than zero.");

            return new Tuple<int, int, int>(Count, minvalue, maxvalue);
        }
    }
}
