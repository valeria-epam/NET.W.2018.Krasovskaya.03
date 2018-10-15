using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FindGCD.Tests
{
    [TestFixture]
    public class FindGCDTests
    {
        [Test]
        public void FindGcd()
        {
            TimeSpan time;
            int result = GCD.FindGcd(5, -25, out time);
            Assert.AreEqual(5,result);
            Assert.That(time, Is.GreaterThan(TimeSpan.Zero));
        }

        [Test]
        public void FindGcd_WithManyParams()
        {
            TimeSpan time;
            int result = GCD.FindGcd(out time, -5, 25,15,45,85,125);
            Assert.AreEqual(5, result);
            Assert.That(time, Is.GreaterThan(TimeSpan.Zero));
        }

        [Test]
        public void FindGcdStein()
        {
            TimeSpan time;
            int result = GCD.FindGcdStein(5, -25, out time);
            Assert.AreEqual(5, result);
            Assert.That(time, Is.GreaterThan(TimeSpan.Zero));
        }

        [Test]
        public void FindGcdStein_WithManyParams()
        {
            TimeSpan time;
            int result = GCD.FindGcdStein(out time, 5, 25, 15, 45, 85, 125);
            Assert.AreEqual(5, result);
            Assert.That(time, Is.GreaterThan(TimeSpan.Zero));
        }

    }
}
