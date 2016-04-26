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
        public void TestGetClasses()
        {
            //Arrangeare
            School sc = new School();
            string soluPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            sc.LoadData(Path.Combine(soluPath, "YH-Admin"));

            List<SchoolClass> schoolClassListExpected = new List<SchoolClass>();
            SchoolClass scc = new SchoolClass(0, "SU13", 0, new DateTime(2013, 09, 01), new DateTime(2015, 05, 30));
            schoolClassListExpected.Add(new SchoolClass(0, "SU13", 0, new DateTime(2013, 09, 01), new DateTime(2015, 05, 30)));
            schoolClassListExpected.Add(new SchoolClass(1, "SU14", 0, new DateTime(2014, 09, 01), new DateTime(2016, 05, 30)));
            schoolClassListExpected.Add(new SchoolClass(2, "SU15", 0, new DateTime(2015, 09, 01), new DateTime(2017, 05, 30)));

            //Act
            List<SchoolClass> schoolClassListActual = sc.GetClasses(0);

            //Assert
            CollectionAssert.AreEqual(schoolClassListExpected, schoolClassListActual);
        }

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
