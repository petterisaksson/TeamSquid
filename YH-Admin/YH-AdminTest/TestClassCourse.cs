using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YH_Admin.Model;

namespace YH_AdminTest
{
    [TestClass]
    public class TestClassCourse
    {
        [TestMethod]
        public void GetStartDate()
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
