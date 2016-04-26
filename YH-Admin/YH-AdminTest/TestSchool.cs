using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YH_Admin.Model;
using System.IO;
using System.Collections.Generic;

namespace YH_AdminTest
{
    [TestClass]
    public class TestSchool
    {
        [TestMethod]
        public void TestGetEducations()
        {
            var expectedList = new List<Education>() { new Education(1, "Webutveckling Agila Webprogrammering", 1) };

            School school = new School();
            string soluPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            school.LoadData(Path.Combine(soluPath, "YH-Admin"));
            var actualList = school.GetEducations(1);

            Console.WriteLine(expectedList[0]);
            Console.WriteLine(actualList[0]);

            CollectionAssert.AreEqual(expectedList, actualList);
        }
    }
}
