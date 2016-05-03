using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YH_Admin.Model;

namespace YH_AdminTest
{
    /// <summary>
    /// Summary description for TestGrade
    /// </summary>
    [TestClass]
    public class TestGrade
    {

        [TestMethod]
        public void TestGradeToFileString()
        {
            Grade g = new Grade(300, 100, 23, "A");
            string expected = "300 100 23 A";

            string actual = g.ToFileString();

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestGradeToFileString1()
        {
            Grade g = new Grade(300, 100, 23, "5");
            string expected = "300 100 23 5";

            string actual = g.ToFileString();

            Assert.AreEqual(expected, actual);
        }
    }
}
