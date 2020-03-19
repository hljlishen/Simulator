using Mapper;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PPI
{
    public class PPIDisplay
    {
        public event Action<double, double> DmeStateChanged;
        private Bitmap Background = null;
        public double Range
        {
            get => range;
            set
            {
                range = value;
                mapper.SetCoordinateXRange(-range, range);
                mapper.SetCoordinateYRange(range, -range);
                state.Update(mapper.ScreenCenter);
                DrawBackground();
                Canvas.Refresh();
            }
        }
        public uint DistanceMarkerCount
        {
            get => distanceMarkerCount;
            set
            {
                distanceMarkerCount = value;
                DrawBackground();
                Canvas.Refresh();
            }
        }
        public PPIDisplay(PictureBox canvas, IScreenToCoordinateMapper mapper)
        {
            Canvas = canvas;
            Canvas.Paint += Canvas_Paint;
            canvas.SizeChanged += Canvas_SizeChanged;
            Canvas.MouseMove += Canvas_MouseMove;
            Canvas.MouseDown += Canvas_MouseDown;
            Canvas.MouseUp += Canvas_MouseUp;
            this.mapper = mapper;
            mapper.SetScreenArea(0, canvas.Size.Width, 0, canvas.Size.Height);
            mapper.SetCoordinateXRange(-range, range);
            mapper.SetCoordinateYRange(range, -range);
            state = new CoordinateState(mapper);
            DrawBackground();
        }

        private void DrawBackground()
        {
            if (Canvas.Width == 0 || Canvas.Height == 0)
                return;
            Background?.Dispose();
            Background = new Bitmap(Canvas.Width, Canvas.Height);

            using (Graphics g = Graphics.FromImage(Background))
            {
                InitializeGraphics(g);
                DrawBackground(g);
            }
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e) => mouseDown = false;

        private void Canvas_MouseDown(object sender, MouseEventArgs e) => mouseDown = true;

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouseDown)
                return;
            if (e.X <= mapper.ScreenLeft + 3 || e.X >= mapper.ScreenRight - 3 || e.Y <= mapper.ScreenTop + 3 || e.Y >= mapper.ScreenBottom - 3)
                return;
            try
            {
                state.Update(e.Location);
                DmeStateChanged?.Invoke(state.Azimuth, state.Distance);
                Canvas.Refresh();
            }
            catch
            {
            }
        }

        private void Canvas_SizeChanged(object sender, EventArgs e)
        {
            mapper.SetScreenArea(0, Canvas.Width, 0, Canvas.Height);
            state.UpdateScreenLocation();
            DrawBackground();
            Canvas.Refresh();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            var newBitmap = new Bitmap(Background);
            using (Graphics graphics = Graphics.FromImage(newBitmap))
            {
                InitializeGraphics(graphics);
                DrawTarget(graphics);
            }

            Canvas.Image?.Dispose();
            Canvas.Image = newBitmap;
        }

        private static void InitializeGraphics(Graphics graphics)
        {
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
        }

        private void DrawBackground(Graphics graphics)
        {
            graphics.Clear(Color.Black);
            var disStep = Range / (DistanceMarkerCount + 1);
            var center = mapper.ScreenCenter;
            //graphics.FillRectangle(new SolidBrush(Color.Black), new RectangleF((float)mapper.ScreenLeft, (float)mapper.ScreenTop, (float)mapper.ScreenWidth, (float)mapper.ScreenHeight));
            for (int i = 1; i <= DistanceMarkerCount + 1; i++)
            {
                var dis = disStep * i;
                var x = mapper.GetScreenX(dis);
                var r = Math.Abs(x - center.X);
                var rect = new RectangleF((float)(center.X - r), (float)(center.Y - r), (float)(r * 2), (float)(r * 2));
                graphics.DrawEllipse(new Pen(Color.Green, 1), rect);

                graphics.DrawString(dis.ToString("0.0"), new Font("宋体", 12), new SolidBrush(Color.Gray), new Point((int)center.X, (int)(center.Y - r + 5)));
            }

            var p = new Pen(Color.White, 1);
            graphics.DrawLine(p, new Point((int)mapper.ScreenLeft, (int)center.Y), new Point((int)mapper.ScreenRight, (int)center.Y));
            graphics.DrawLine(p, new Point((int)center.X, (int)mapper.ScreenTop), new Point((int)center.X, (int)mapper.ScreenBottom));
        }

        private void DrawTarget(Graphics graphics)
        {
            Pen p = new Pen(Color.Red, 1f);
            var target = state.GetCoordinate();
            var point = state.ScreenLocation;
            //var point = mapper.GetScreenLocation(target.X, target.Y);
            var center = mapper.ScreenCenter;
            var xPoint = new PointF(point.X, center.Y);
            var yPoint = new PointF(center.X, point.Y);
            var xmPoint = new PointF(point.X, center.Y - (center.Y - point.Y) / 2);
            var ymPoint = new PointF(center.X + (point.X - center.X) / 2, point.Y);
            var dmPoint = new PointF(center.X + (point.X - center.X) / 2, center.Y - (center.Y - point.Y) / 2);
            graphics.DrawLine(p, point, center);
            graphics.DrawLine(p, point, xPoint);
            graphics.DrawLine(p, point, yPoint);
            Font font = new Font("宋体", 12);
            SolidBrush brush = new SolidBrush(Color.Yellow);
            graphics.DrawString(target.X.ToString("0"), font, brush, ymPoint);
            graphics.DrawString((target.Y).ToString("0"), font, brush, xmPoint);
            graphics.DrawString(state.Distance.ToString("0"), font, brush, dmPoint);
            graphics.FillEllipse(new SolidBrush(Color.Red), new RectangleF(point.X - 4, point.Y - 4, 8, 8));

            #region 画弧线
            var arcR = Math.Min(Math.Abs(point.X - center.X), Math.Abs(point.Y - center.Y)) / 3;
            var angle = state.Azimuth;
            var left = center.X - arcR;
            var top = center.Y - arcR;
            Rectangle arcRect = new Rectangle((int)left, (int)top, (int)arcR * 2, ((int)arcR * 2));

            var centerAngle = DegreeToRadian(angle / 2);
            var centerPoint = new PointF((float)(arcR * Math.Sin(centerAngle) + center.X), (float)(center.Y - arcR * Math.Cos(centerAngle)) - 5);
            if (arcR > 0 && arcRect.Width > 0 && arcRect.Height > 0)
            {
                graphics.DrawArc(p, arcRect, -90, (float)angle);
                graphics.DrawString($"{angle.ToString("0.0")}°", font, brush, centerPoint);
            }
            #endregion
        }

        public static double DegreeToRadian(double degree) => degree * Math.PI / 180;

        public void SetDmeState(double az, double dis)
        {
            state.Azimuth = az;
            state.Distance = dis;
            state.Update();
        }

        public PictureBox Canvas { get; set; }
        private IScreenToCoordinateMapper mapper;
        private uint distanceMarkerCount = 5;
        private double range = 10000;
        private bool mouseDown = false;
        public double Az
        {
            get => state.Azimuth;
            set
            {
                state.Azimuth = value;
                state.Update();
            }
        }
        public double Distance
        {
            get => state.Distance;
            set
            {
                state.Distance = value;
                state.Update();
            }
        }
        //private PointF target = new PointF();
        private CoordinateState state;

        class CoordinateState
        {
            public double Distance = 0;
            public double Azimuth = 0;
            public PointF screenLocation;
            public PointF CoordinateLocation;
            public IScreenToCoordinateMapper mapper = null;

            public CoordinateState(IScreenToCoordinateMapper mapper)
            {
                this.mapper = mapper;
                screenLocation = mapper.ScreenCenter;
            }

            public void Update(PointF screenLocation)
            {
                this.screenLocation = screenLocation;
                var center = mapper.ScreenCenter;
                CoordinateLocation = GetCoordinate();
                Distance = Math.Sqrt(Math.Pow(CoordinateLocation.X, 2) + Math.Pow(CoordinateLocation.Y, 2));
                Azimuth = 90 - RadianToDegree(Math.Atan2(center.Y - screenLocation.Y, screenLocation.X - center.X));
                if (Azimuth < 0)
                    Azimuth += 360;
            }

            public void Update()
            {
                CoordinateLocation.X = (float)(Distance * Math.Sin(DegreeToRadian(Azimuth)));
                CoordinateLocation.Y = (float)(Distance * Math.Cos(DegreeToRadian(Azimuth)));
                screenLocation = mapper.GetScreenLocation(coordinateX: CoordinateLocation.X, coordinateY: CoordinateLocation.Y);
            }

            public static double RadianToDegree(double radian) => radian * 180 / Math.PI;
            public static double DegreeToRadian(double degree) => degree * Math.PI / 180;

            public PointF ScreenLocation => screenLocation;

            public PointF GetCoordinate() => mapper.GetCoordinateLocation(screenLocation.X, screenLocation.Y);

            public void UpdateScreenLocation() => screenLocation = mapper.GetScreenLocation(CoordinateLocation.X, CoordinateLocation.Y);
        }
    }
}
