﻿using System.Drawing;

namespace Mapper
{
    public class MapperDecorator : IScreenToCoordinateMapper
    {
        public MapperDecorator(IScreenToCoordinateMapper mapper)
        {
            Mapper = mapper;
        }

        protected IScreenToCoordinateMapper Mapper { get; private set; }
        public virtual ValueMapper XAxisMapper => Mapper.XAxisMapper;
        public virtual ValueMapper YAxisMapper => Mapper.YAxisMapper;
        public double ScreenLeft => Mapper.ScreenLeft;
        public double ScreenRight => Mapper.ScreenRight;
        public double ScreenTop => Mapper.ScreenTop;
        public double ScreenBottom => Mapper.ScreenBottom;
        public double CoordinateLeft => Mapper.CoordinateLeft;
        public double CoordinateRight => Mapper.CoordinateRight;
        public double CoordinateTop => Mapper.CoordinateTop;
        public double CoordinateBottom => Mapper.CoordinateBottom;
        public PointF ScreenCenter => Mapper.ScreenCenter;
        public virtual double ScreenWidth => Mapper.ScreenWidth;
        public virtual double ScreenHeight => Mapper.ScreenHeight;

        public virtual PointF GetCoordinateLocation(double screenX, double screenY) => Mapper.GetCoordinateLocation(screenX, screenY);
        public virtual double GetCoordinateX(double screenX) => Mapper.GetCoordinateX(screenX);
        public virtual double GetCoordinateY(double screenY) => Mapper.GetCoordinateY(screenY);
        public virtual PointF GetScreenLocation(double coordinateX, double coordinateY) => Mapper.GetScreenLocation(coordinateX, coordinateY);
        public virtual double GetScreenX(double coordinateX) => Mapper.GetScreenX(coordinateX);
        public virtual double GetScreenY(double coordinateY) => Mapper.GetScreenY(coordinateY);
        public virtual void SetCoordinateXRange(double xLeft, double xRight) => Mapper.SetCoordinateXRange(xLeft, xRight);
        public virtual void SetCoordinateYRange(double yTop, double yBottom) => Mapper.SetCoordinateYRange(yTop, yBottom);
        public virtual void SetScreenArea(double left, double right, double top, double bottom) => Mapper.SetScreenArea(left, right, top, bottom);
    }
}
