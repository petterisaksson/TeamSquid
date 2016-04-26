using System;
using System.Runtime.InteropServices;
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

        [TestMethod]
        public void TestToString()
        {
            ClassCourse cc = new ClassCourse(1, 2, 3, new DateTime(2016, 01, 01), new DateTime(2016,02,02));
            string expected = $"ClassCourseId: 1; CourseId: 1; ClassId: 2; 20160101; 20160202";

            var actual = $"ClassCourseId: 1; CourseId: 1; ClassId: 2; 20160101; 20160202";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsFinished()
        {
            var cc = new ClassCourse(1, 2, 3, new DateTime(2016, 01, 01), new DateTime(2016, 02, 02));
            string expected = cc.GetEndDate();

            var actual = cc.GetEndDate();

            Assert.AreEqual(expected, actual);
        }





    }
}
