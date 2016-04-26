using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YH_Admin.Model;

namespace YH_AdminTest
{
    [TestClass]
    public class TestEducation
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            Education edu = new Education(1, "EducationId",  3);
            Education edu = new Education(1, "EducationId", 3); //Education vill ha 3 in variabler, första en int, andra en string och tredje en int.
            string expected = $"EducationId: 1; Name: Systemutveckling Agila Applikationsprogrammering; UserId: 2";

            var actual = edu.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
