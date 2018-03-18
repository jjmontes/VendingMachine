using NUnit.Framework;
using System.Linq;
using VendingMachine.Domain;

namespace VendingMachine.Tests
{
    [TestFixture]
    public class MachineTests
    {
        [Test]
        public void PayWith100_Cost10_Returns50_20_20()
        {
            var machine = new Machine();

            var change = machine.Buy(10).PayWith(100).GetChange();

            Assert.AreEqual(2, change.Count());
            Assert.AreEqual(0, change.CountFromBill(100));
            Assert.AreEqual(1, change.CountFromBill(50));
            Assert.AreEqual(2, change.CountFromBill(20));
            Assert.AreEqual(0, change.CountFromBill(10));
            Assert.AreEqual(0, change.CountFromBill(5));
        }

        [Test]
        public void PayWith100_Cost20_Returns50_20_10()
        {
            var machine = new Machine();

            var change = machine.Buy(20).PayWith(100).GetChange();

            Assert.AreEqual(3, change.Count());
            Assert.AreEqual(0, change.CountFromBill(100));
            Assert.AreEqual(1, change.CountFromBill(50));
            Assert.AreEqual(1, change.CountFromBill(20));
            Assert.AreEqual(1, change.CountFromBill(10));
            Assert.AreEqual(0, change.CountFromBill(5));
        }

    }
}
