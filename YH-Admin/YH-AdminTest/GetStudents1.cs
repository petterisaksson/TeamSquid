using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YH_Admin.Model;

namespace YH_AdminTest
{
    [TestClass]
    public class GetStudents1
    {
        [TestMethod]
        public void TestMethod1()
        {
            SchoolClass n = new SchoolClass(1, "name", 2, new DateTime(2013,09,01), new DateTime(2015,05,30));
            string expected = $"classId: 0 SU13 0 20130901 20150530"

        }
    }
}
