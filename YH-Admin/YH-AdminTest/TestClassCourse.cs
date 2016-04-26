using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YH_Admin.Model;

namespace YH_AdminTest
{
    [TestClass]
    public class TestClassCourse
    {
        [TestMethod]
        public void TestGetEndDate()
        {
            ClassCourse cc = new ClassCourse(0, 0, 0, new DateTime(2012, 3, 11), new DateTime(2013, 4, 12));
            string expected = "20130412";

            string actual = cc.GetEndDate();

            Assert.AreEqual(expected, actual);
        }
    }
}
