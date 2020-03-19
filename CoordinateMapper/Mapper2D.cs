using System;

namespace Mapper
{
    public class ScreenToCoordinateMapper
    {
        public ValueMapper XAxisMapper { get; private set; }
        public ValueMapper YAxisMapper { get; private set; }
        public ScreenToCoordinateMapper(ValueMapper xAxis, ValueMapper yAxis)
        {
            if (xAxis == null || yAxis == null)
                throw new Exception("映射器为null");
            XAxisMapper = xAxis;
            YAxisMapper = yAxis;
        }

        public ScreenToCoordinateMapper(double screenXMax, double screenXMin, double coordinateXMax, double coordinateXMin,
                                        double screenYMax, double screenYMin, double coordinateYMax, double coordinateYMin)
        {
            XAxisMapper = new ValueMapper(screenXMax, screenXMin, coordinateXMax, coordinateXMin);
            YAxisMapper = new ValueMapper(screenYMax, screenYMin, coordinateYMax, coordinateYMin);
        }

        public double GetScreenX(double coordinateX) => XAxisMapper.MapToValue1(coordinateX);
        public double GetScreenY(double coordinateY) => YAxisMapper.MapToValue1(coordinateY);
        public double GetCoordinateX(double screenX) => XAxisMapper.MapToValue2(screenX);
        public double GetCoordinateY(double screenY) => YAxisMapper.MapToValue2(screenY);

        public void SetScreenXRange(double max, double min)
        {
            XAxisMapper = new ValueMapper(max, min, XAxisMapper.Value2Max, XAxisMapper.Value2Min);
        }

        public void SetScreenYRange(double max, double min)
        {
            YAxisMapper = new ValueMapper(max, min, YAxisMapper.Value2Max, YAxisMapper.Value2Min);
        }

        public void SetCoordinateXRange(double max, double min)
        {
            XAxisMapper = new ValueMapper(XAxisMapper.Value1Max, XAxisMapper.Value1Min, max, min);
        }

        public void SetCoordinateYRange(double max, double min)
        {
            YAxisMapper = new ValueMapper(YAxisMapper.Value1Max, YAxisMapper.Value1Min, max, min);
        }
    }
}
