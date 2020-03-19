using System;

namespace Mapper
{
    public enum RangeType
    {
        OpenOpen,
        CloseClose,
        OpenClose,
        CloseOpen
    }
    public class ValueRange
    {
        public ValueRange(double max, double min, RangeType type = RangeType.CloseClose)
        {
            if (max < min)
                throw new MaxNotBiggerThanMin($"最大值{max}不大于最小值{min}");
 
            Max = max;
            Min = min;
            Type = type;
        }

        public ValueRange() { }
        public double Max { get; private set; } = 0;
        public double Min { get; private set; } = 0;
        public RangeType Type { get; set; } = RangeType.CloseClose;
        public double Coverage => NumericDistance(Min, Max);
        public static double NumericDistance(double min, double max) => Math.Abs(max - min);
        public double NumericDistanceToMin(double value)
        {
            if(!IsInRange(value))
                throw new ValueNotInRange($"转换的数值{value}超出了范围:{ToString()}");
            return NumericDistance(Min, value);
        }
        public bool IsInRange(double value)
        {
            switch (Type)
            {
                case RangeType.OpenOpen:
                    return value > Min && value < Max;
                case RangeType.CloseClose:
                    return value >= Min && value <= Max;
                case RangeType.OpenClose:
                    return value > Min && value <= Max;
                case RangeType.CloseOpen:
                    return value >= Min && value < Max;
                default:
                    throw new Exception("错误的RangeType类型");
            }
        }
        public override string ToString()
        {
            string leftMark;
            string rightMark;
            switch (Type)
            {
                case RangeType.OpenOpen:
                    leftMark = "(";
                    rightMark = ")";
                    break;
                case RangeType.CloseClose:
                    leftMark = "[";
                    rightMark = "]";
                    break;
                case RangeType.OpenClose:
                    leftMark = "(";
                    rightMark = "]";
                    break;
                case RangeType.CloseOpen:
                    leftMark = "[";
                    rightMark = ")";
                    break;
                default:
                    throw new Exception("错误的RangeType类型");
            }
            return $"{leftMark}{Min}-{Max}{rightMark}";
        }
    }
}
