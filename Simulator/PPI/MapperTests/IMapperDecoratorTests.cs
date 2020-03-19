using Mapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mapper.Tests
{
    [TestClass()]
    public class IMapperDecoratorTests
    {
        [TestMethod()]
        public void CenterPointTest()
        {
            var p = SquaredScreenRectDecorator.CenterPointOf(new System.Drawing.RectangleF(50, 50, 100, 100));
            Assert.AreEqual(p.X, 100);
            Assert.AreEqual(p.Y, 100);
        }

        //[TestMethod()]
        //public void FindBiggestSquareTest()
        //{
        //    var square = SquaredScreenRectDecorator.FindBiggestSquareIn(new System.Drawing.RectangleF(0, 0, 100, 120));
        //    Assert.AreEqual(square.Left, 0);
        //    Assert.AreEqual(square.Top, 10);
        //    Assert.AreEqual(square.Width, 100);
        //    Assert.AreEqual(square.Height, 100);
        //}
    }
}