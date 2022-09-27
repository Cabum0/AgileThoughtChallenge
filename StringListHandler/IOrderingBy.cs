using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace StringListHandler
{
    public interface IOrderingBy
    {
        public IList Position(IList<string> names, IList<int> order);
        public Tuple<int, int, int> Validation(ref IList<string> names, ref IList<int> order);
    }
}
