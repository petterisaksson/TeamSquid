using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YH_Admin.Model;

namespace YH_AdminTest
{
    [TestClass]
    public class TestClassCourse
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void TestToString()
        {
            ClassCourse cc = new ClassCourse(1, 2, 3, new DateTime(2016, 01, 01), new DateTime(2016,02,02));
            string expected = $"ClassCourseId: 1; CourseId: 1; ClassId: 2; 20160101; 20160202";

            var actual = $"ClassCourseId: 1; CourseId: 1; ClassId: 2; 20160101; 20160202";
            Assert.AreEqual(expected, actual);
        }
    }
}
