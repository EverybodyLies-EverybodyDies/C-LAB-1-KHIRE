using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SectorApp;

namespace SectorApp.Tests
{
    [TestClass]
    public class SectorTests
    {
        [TestMethod]
        public void Constructor_WithValidValues_CreatesSector()
        {
            var s = new Sector(5, 60);

            Assert.AreEqual(5, s.Radius);
            Assert.AreEqual(60, s.AngleDegrees);
        }
       
        [TestMethod]
        public void DefaultConstructor_SetsDefaultValues()
        {
           
            var s = new Sector();

           
            Assert.AreEqual(1.0, s.Radius);
            Assert.AreEqual(90.0, s.AngleDegrees);
        }
         
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_WithNegativeRadius_ThrowsException()
        {
            
            var s = new Sector(-2, 60);
        }
         
        [TestMethod]
        public void Area_WithValidValues_ReturnsCorrectResult()
        {
           
            var s = new Sector(5, 90);

           
            double area = s.Area();

            
            double expected = Math.PI * 5 * 5 * 90 / 360;
            Assert.AreEqual(expected, area, 1e-9);
        }
         
        [TestMethod]
        public void ArcLength_WithValidValues_ReturnsCorrectResult()
        {
           
            var s = new Sector(10, 180);

            
            double length = s.ArcLength();

           
            double expected = 2 * Math.PI * 10 * 180 / 360;
            Assert.AreEqual(expected, length, 1e-9);
        }
         
        [TestMethod]
        public void CompareByArea_SmallerSector_ReturnsMinusOne()
        {
         
            var small = new Sector(3, 60);
            var large = new Sector(6, 60);

           
            int result = small.CompareByArea(large);

            
            Assert.AreEqual(-1, result);
        }
         
        [TestMethod]
        public void Equals_TwoIdenticalSectors_ReturnsTrue()
        {
           
            var s1 = new Sector(4, 120);
            var s2 = new Sector(4, 120);

            
            bool result = s1.Equals(s2);

       
            Assert.IsTrue(result);
        }
         
        [TestMethod]
        public void ToString_ReturnsCorrectFormat()
        {
      
            var s = new Sector(2.5, 45);

            
            string result = s.ToString();

          
            Assert.AreEqual("Sector(Radius = 2,5, Angle = 45°)", result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_WithZeroRadius_ThrowsException()
        {
         
            var s = new Sector(0, 45);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_WithAngleGreaterThan360_ThrowsException()
        {
           
            var s = new Sector(5, 400);
        }

    }
}
