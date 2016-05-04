using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YH_Admin.Model;

namespace YH_AdminTest
{
    [TestClass]
    public class TestGrade
    {
        [TestMethod]
        public void TestToString()
        {
            var guid = Guid.NewGuid();
            var grade = new Grade(guid, 0, 0, "A");

            var expected = $"{guid} 0 0 A";

            var actual = grade.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
