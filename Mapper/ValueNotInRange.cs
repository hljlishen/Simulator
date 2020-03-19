using System;

namespace Mapper
{
    public class ValueNotInRange : Exception
    {
        public ValueNotInRange(string msg) : base(msg) { }
    }
}
