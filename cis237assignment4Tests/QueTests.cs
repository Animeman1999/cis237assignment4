using Microsoft.VisualStudio.TestTools.UnitTesting;
using cis237assignment4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cis237assignment3;

namespace cis237assignment4.Tests
{
    [TestClass()]
    public class QueTests
    {
        [TestMethod()]
        public void EnqueueTest()
        {
            Protocol testProtocol1 = new Protocol("Nevo-Titanium", "Protocol", "Green", 100);
            Que<Protocol> testProtocolStac = new Que<Protocol>();
            testProtocolStac.Enqueue(testProtocol1);
            int testSize = testProtocolStac.Size;
            Protocol testProtocol2 = new Protocol("Nevo-Titanium", "Protocol", "Blue", 200);
            testProtocolStac.Enqueue(testProtocol2);
            int testSize2 = testProtocolStac.Size;
            Protocol testProtocol3 = new Protocol("Nevo-Titanium", "Protocol", "Red", 300);
            testProtocolStac.Enqueue(testProtocol3);
            int testSize3 = testProtocolStac.Size;

            Assert.AreEqual(1, testSize);
            Assert.AreEqual(2, testSize2);
            Assert.AreEqual(3, testSize3);
        }

        [TestMethod()]
        public void DequeueTest()
        {
            Protocol testProtocol1 = new Protocol("Nevo-Titanium", "Protocol", "Green", 100);
            Que<Protocol> testProtocolStac = new Que<Protocol>();
            testProtocolStac.Enqueue(testProtocol1);
            Protocol testProtocol2 = new Protocol("Nevo-Titanium", "Protocol", "Blue", 200);
            testProtocolStac.Enqueue(testProtocol2);
            Protocol testProtocol3 = new Protocol("Nevo-Titanium", "Protocol", "Red", 300);
            testProtocolStac.Enqueue(testProtocol3);

            Protocol actualProtocol1 = testProtocolStac.Dequeue();
            Protocol actualProtocol2 = testProtocolStac.Dequeue();
            Protocol actualProtocol3 = testProtocolStac.Dequeue();

            Assert.AreEqual(testProtocol1, actualProtocol1);
            Assert.AreEqual(testProtocol2, actualProtocol2);
            Assert.AreEqual(testProtocol3, actualProtocol3);
        }
    }
}