using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YH_Admin.Model;

namespace YH_AdminTest
{
    [TestClass]
    public class TestGetStudents1
    {
        [TestMethod]
        public void TestGetStudents1()
        {
            SchoolClass n = new SchoolClass(1, "name", 2, new DateTime(2013,09,01), new DateTime(2015,05,30));
            string expected = $"classId: 0; Name: SU13; DateTime: 20130901 20150530";

            var actual = n.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
