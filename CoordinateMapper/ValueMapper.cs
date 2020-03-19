using System;

namespace Mapper
{
    public class ValueMapper
    {
        public ValueMapper(double value1Max, double value1Min, double value2Max, double value2Min)
        {
            if (!(value1Max > value1Min))
                throw new MaxNotBiggerThanMin($"最大值{value1Max}不大于最小值{value1Min}");
            if (!(value2Max > value2Min))
                throw new MaxNotBiggerThanMin($"最大值{value2Max}不大于最小值{value2Min}");

            this.value1Max = value1Max;
            this.value1Min = value1Min;
            this.value2Max = value2Max;
            this.value2Min = value2Min;
            CalculateRatos();
        }

        private void CalculateRatos()
        {
            var v1Dis = NumericDistance(Value1Min, Value1Max);
            var v2Dis = NumericDistance(Value2Min, Value2Max);
            Value2ToValue1Rato = v2Dis / v1Dis;
            Value1ToValue2Rato = v1Dis / v2Dis;
        }

        public double Value1Max
        {
            get
            {
                return value1Max;
            }
            set
            {
                value1Max = value;
                CalculateRatos();
            }
        }
        private double value1Max;

        public double Value1Min
        {
            get
            {
                return value1Min;
            }
            set
            {
                value1Min = value;
                CalculateRatos();
            }
        }
        private double value1Min;

        public double Value2Max
        {
            get
            {
                return value2Max;
            }
            set
            {
                value2Max = value;
                CalculateRatos();
            }
        }
        private double value2Max;

        public double Value2Min
        {
            get
            {
                return value2Min;
            }
            set
            {
                value2Min = value;
                CalculateRatos();
            }
        }
        private double value2Min;

        private double Value2ToValue1Rato;
        private double Value1ToValue2Rato;

        private static double NumericDistance(double min, double max) => Math.Abs(max - min);

        public double MapToValue1(double value2)
        {
            if (value2 < Value2Min || value2 > Value2Max)
                throw new ValueNotInRange($"转换的数值{value2}超出了范围:{Value2Min} - {Value2Max}");
            var value2Dis = NumericDistance(Value2Min, value2);
            return value2Dis * Value1ToValue2Rato + Value1Min;
        }

        public double MapToValue2(double value1)
        {
            if (value1 < Value1Min || value1 > Value1Max)
                throw new ValueNotInRange($"转换的数值{value1}超出了范围:{Value1Min} - {Value1Max}");
            var value1Dis = NumericDistance(Value1Min, value1);
            return value1Dis * Value2ToValue1Rato + Value2Min;
        }
    }

    public class MaxNotBiggerThanMin : Exception
    {
        public MaxNotBiggerThanMin(string msg) : base(msg) { }
    }

    public class ValueNotInRange : Exception
    {
        public ValueNotInRange(string msg) : base(msg) { }
    }
}
