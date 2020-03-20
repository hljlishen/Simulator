using Mapper;
using Rule;
using System.Text.RegularExpressions;

namespace SimView
{
    public class StringRule : IRule<string>
    {
        protected Regex Regex;
        public string RegexExpression { get => Regex.ToString(); }
        protected StringRule(string regexExpression)
        {
            Regex = new Regex(regexExpression);
        }
        public virtual string Hint { get; } = "";
        public virtual bool Pass(string input) => Regex.IsMatch(input);
    }

    public class IntStrInRange : StringRule
    {
        private ValueInterval interval;
        public IntStrInRange(ValueInterval interval) : base(@"^[+]{0,1}(\d+)$")
        {
            this.interval = interval;
        }

        public IntStrInRange(int max, int min) : this(ValueInterval.CloseClose(max, min))
        {

        }

        public override bool Pass(string input)
        {
            if (!base.Pass(input))
                return false;
            int value = int.Parse(input);
            return interval.IsInRange(value);
        }

        public override string Hint { get => $"请输入{interval.ToString()}范围内的整数";}
    }
    public class DoubleStrInRange : StringRule
    {
        private ValueInterval interval;
        public DoubleStrInRange(ValueInterval interval) : base(@"^[1-9]*[0-9]?(\.[0-9]{1,2})?$")
        {
            this.interval = interval;
        }
        public DoubleStrInRange(double max, double min) : this(ValueInterval.CloseClose(max, min))
        {

        }

        public override bool Pass(string input)
        {
            if (!base.Pass(input))
                return false;
            double value = double.Parse(input);
            return interval.IsInRange(value);
        }

        public override string Hint { get => $"请输入{interval.ToString()}范围内的浮点";}
    }
}
