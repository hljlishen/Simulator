using System;

namespace Mapper
{
    public class MaxNotBiggerThanMin : Exception
    {
        public MaxNotBiggerThanMin(string msg) : base(msg) { }
    }
}
