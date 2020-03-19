using Mapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Mapper.Tests
{
    [TestClass()]
    public class ValueMapperTests
    {
        [TestMethod()]
        public void MapToValue1Test()
        {
            var map = new ValueMapper(500, 100, 200, 0);
            Assert.AreEqual(300, map.MapToValue1(100));
            Assert.AreEqual(400, map.MapToValue1(150));
            Assert.AreEqual(100, map.MapToValue1(0));
            Assert.AreEqual(500, map.MapToValue1(200));

            map = new ValueMapper(100, 200, 0, -100);
            #region 区域外的值是否抛出异常
            try
            {
                Assert.AreEqual(300, map.MapToValue1(100));
                Assert.Fail();
            }
            catch (Exception err)
            {
                Assert.IsInstanceOfType(err, typeof(ValueNotInRange));
            }
            #endregion
            Assert.AreEqual(150, map.MapToValue1(-50));
            Assert.AreEqual(175, map.MapToValue1(-75));
            Assert.AreEqual(110, map.MapToValue1(-10));
            Assert.AreEqual(100, map.MapToValue1(0));
            Assert.AreEqual(200, map.MapToValue1(-100));
        }

        [TestMethod()]
        public void MapToValue2Test()
        {
            var map = new ValueMapper(500, 100, 200, 0);
            Assert.AreEqual(100, map.MapToValue2(300));
            Assert.AreEqual(150, map.MapToValue2(400));
            Assert.AreEqual(0, map.MapToValue2(100));
            Assert.AreEqual(200, map.MapToValue2(500));

            Assert.AreEqual(500, map.Value1Left);
            Assert.AreEqual(100, map.Value1Right);
            Assert.AreEqual(200, map.Value2Left);
            Assert.AreEqual(0, map.Value2Right);

            map = new ValueMapper(100, 200, 0, -100);
            Assert.AreEqual(100, map.Value1Left);
            Assert.AreEqual(200, map.Value1Right);
            Assert.AreEqual(0, map.Value2Left);
            Assert.AreEqual(-100, map.Value2Right);
            #region 区域外的值是否抛出异常
            try
            {
                Assert.AreEqual(100, map.MapToValue2(300));
                Assert.Fail();
            }
            catch (Exception err)
            {
                Assert.IsInstanceOfType(err, typeof(ValueNotInRange));
            }
            #endregion
            Assert.AreEqual(-50, map.MapToValue2(150));
            Assert.AreEqual(-75, map.MapToValue2(175));
            Assert.AreEqual(-10, map.MapToValue2(110));
            Assert.AreEqual(0, map.MapToValue2(100));
            Assert.AreEqual(-100, map.MapToValue2(200));
        }

        [TestMethod()]
        public void SetRange1Test()
        {
            var map = new ValueMapper(100, 500, 200, 0);
            Assert.AreEqual(100, map.MapToValue2(300));
            Assert.AreEqual(50, map.MapToValue2(400));
            Assert.AreEqual(200, map.MapToValue2(100));
            Assert.AreEqual(0, map.MapToValue2(500));

            map.SetRange1(-200, 0);
            Assert.AreEqual(-200, map.Value1Left);
            Assert.AreEqual(0, map.Value1Right);
            Assert.AreEqual(200, map.Value2Left);
            Assert.AreEqual(0, map.Value2Right);
            #region 区域外的值是否抛出异常
            try
            {
                Assert.AreEqual(100, map.MapToValue2(300));
                Assert.Fail();
            }
            catch (Exception err)
            {
                Assert.IsInstanceOfType(err, typeof(ValueNotInRange));
            }
            #endregion
            Assert.AreEqual(50, map.MapToValue2(-50));
            Assert.AreEqual(100, map.MapToValue2(-100));
            Assert.AreEqual(90, map.MapToValue2(-90));
            Assert.AreEqual(200, map.MapToValue2(-200));
            Assert.AreEqual(0, map.MapToValue2(-0));

            map.SetRange1(600, 200);
            Assert.AreEqual(600, map.Value1Left);
            Assert.AreEqual(200, map.Value1Right);
            Assert.AreEqual(200, map.Value2Left);
            Assert.AreEqual(0, map.Value2Right);
            Assert.AreEqual(0, map.MapToValue2(200));
            Assert.AreEqual(200, map.MapToValue2(600));
            Assert.AreEqual(50, map.MapToValue2(300));
            Assert.AreEqual(100, map.MapToValue2(400));
            Assert.AreEqual(150, map.MapToValue2(500));

            #region 区域外的值是否抛出异常
            try
            {
                Assert.AreEqual(100, map.MapToValue2(199.99));
                Assert.Fail();
            }
            catch (Exception err)
            {
                Assert.IsInstanceOfType(err, typeof(ValueNotInRange));
            }
            #endregion

            #region 区域外的值是否抛出异常
            try
            {
                Assert.AreEqual(100, map.MapToValue2(600.1));
                Assert.Fail();
            }
            catch (Exception err)
            {
                Assert.IsInstanceOfType(err, typeof(ValueNotInRange));
            }
            #endregion
        }

        [TestMethod()]
        public void SetRange2Test()
        {
            var map = new ValueMapper(100, 500, 200, 0);
            Assert.AreEqual(100, map.MapToValue2(300));
            Assert.AreEqual(50, map.MapToValue2(400));
            Assert.AreEqual(200, map.MapToValue2(100));
            Assert.AreEqual(0, map.MapToValue2(500));

            map.SetRange2(-200, 0);
            Assert.AreEqual(100, map.Value1Left);
            Assert.AreEqual(500, map.Value1Right);
            Assert.AreEqual(-200, map.Value2Left);
            Assert.AreEqual(0, map.Value2Right);
            Assert.AreEqual(200, map.MapToValue1(-150));
            Assert.AreEqual(450, map.MapToValue1(-25));

            #region 区域外的值是否抛出异常
            try
            {
                Assert.AreEqual(100, map.MapToValue1(0.001));
                Assert.Fail();
            }
            catch (Exception err)
            {
                Assert.IsInstanceOfType(err, typeof(ValueNotInRange));
            }
            #endregion

            #region 区域外的值是否抛出异常
            try
            {
                Assert.AreEqual(100, map.MapToValue2(-200.01));
                Assert.Fail();
            }
            catch (Exception err)
            {
                Assert.IsInstanceOfType(err, typeof(ValueNotInRange));
            }
            #endregion
        }
    }
}