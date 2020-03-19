using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mapper.Tests
{
    [TestClass()]
    public class ScreenToCoordinateMapperTests
    {
        [TestMethod()]
        public void SetScreenAreaTest()
        {
            IScreenToCoordinateMapper m = new ScreenToCoordinateMapper(0, 1000, -1000, 1000, 0, 1000, 1000, -1000);
            Assert.AreEqual(m.GetCoordinateX(500), 0);
            Assert.AreEqual(m.GetCoordinateX(750), 500);
            Assert.AreEqual(m.GetCoordinateY(500), 0);
            Assert.AreEqual(m.GetCoordinateY(750), -500);
            Assert.AreEqual(m.GetCoordinateY(0), 1000);
            Assert.AreEqual(m.GetCoordinateY(1000), -1000);

            ////m.SetScreenArea(new System.Drawing.RectangleF(0, 0, 2000, 2000));
            //m.setScreenXRange()
            //Assert.AreEqual(m.GetCoordinateX(1000), 0);
            //Assert.AreEqual(m.GetCoordinateX(1500), 500);
            //Assert.AreEqual(m.GetCoordinateY(1000), 0);
            //Assert.AreEqual(m.GetCoordinateY(1500), -500);

            ////m.SetScreenArea(new System.Drawing.RectangleF(1000, 1000, 1000, 1000));
            //Assert.AreEqual(m.GetCoordinateX(1000), -1000);
            //Assert.AreEqual(m.GetCoordinateX(1500), 0);
            //Assert.AreEqual(m.GetCoordinateY(1000), 1000);
            //Assert.AreEqual(m.GetCoordinateY(1500), 0);

            ////m = new ScreenToCoordinateMapper(1000, 0, 2000, 0, 1000, 0, 0, -2000);
            //m = new YAxisReversedDecorator(m);
            //Assert.AreEqual(m.GetCoordinateX(500), 1000);
            //Assert.AreEqual(m.GetCoordinateY(500), -1000);
            //Assert.AreEqual(m.GetScreenY(-1000), 500);
            //Assert.AreEqual(m.GetScreenY(-500), 250);
            //Assert.AreEqual(m.GetScreenY(-2000), 1000);
            //Assert.AreEqual(m.GetScreenY(0), 0);
        }

        [TestMethod()]
        public void SetScreenXRangeTest()
        {
            IScreenToCoordinateMapper m = new ScreenToCoordinateMapper(0, 1000, -1000, 1000, 0, 1000, 1000, -1000);
            Assert.AreEqual(m.GetCoordinateX(500), 0);
            Assert.AreEqual(m.GetCoordinateX(750), 500);
            Assert.AreEqual(m.GetCoordinateY(500), 0);
            Assert.AreEqual(m.GetCoordinateY(750), -500);
            Assert.AreEqual(m.GetCoordinateY(0), 1000);
            Assert.AreEqual(m.GetCoordinateY(1000), -1000);

            ////m.SetScreenArea(new System.Drawing.RectangleF(0, 0, 2000, 2000));
            //m.SetScreenXRange(0, 2000);
            m.SetScreenArea(0, 2000, 0, 1000);
            Assert.AreEqual(m.GetCoordinateX(1000), 0);
            Assert.AreEqual(m.GetCoordinateX(1500), 500);
            Assert.AreEqual(m.GetCoordinateY(1000), -1000);
            Assert.AreEqual(m.GetCoordinateY(750), -500);

            //m.SetScreenXRange(2000, 0);
            m.SetScreenArea(2000, 0, 0, 1000);
            Assert.AreEqual(m.GetCoordinateX(1000), 0);
            Assert.AreEqual(m.GetCoordinateX(1500), -500);
            Assert.AreEqual(m.GetCoordinateY(1000), -1000);
            Assert.AreEqual(m.GetCoordinateY(750), -500);
        }
    }
}