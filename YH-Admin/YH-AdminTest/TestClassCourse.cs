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

        [TestMethod]
       
        public void TestGetStartDate()
        {
            //Arange
            ClassCourse gsd = new ClassCourse(1, 2, 3, new DateTime(2016,04,26), new DateTime(2016,02,02));
            string expected = "20160426";

            //Act
            var actual = gsd.GetStartDate();

            //Assert
            Assert.AreEqual(expected, actual);


        }
    }
    


}
